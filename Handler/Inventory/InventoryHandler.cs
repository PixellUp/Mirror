using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Classes.Static;
using Mirror.Classes.Models;
using Mirror.Classes.Readonly;

namespace Mirror.Handler
{
    public static class InventoryHandler
    {
        public static List<DroppedItem> DroppedItems = new List<DroppedItem>();

        public static void UseItem(Client client, int index)
        {
            Account account = AccountUtil.RetrieveAccount(client);
            InventoryItem[] inventoryItems = account.GetAllItems();

            if (inventoryItems[index] == null)
                return;

            string inventoryJson = "";

            InventoryItem item = inventoryItems[index];

            bool itemFound = UseItemEffect(client, inventoryItems[index].Name.ToLower(), item);

            if (!itemFound)
                return;

            client.TriggerEvent("PlaySoundFrontend", "PIN_BUTTON", "ATM_SOUNDS");

            if (inventoryItems[index].StackCount <= 1)
            {
                inventoryItems[index] = null;
                inventoryJson = GetInventoryJson(inventoryItems);
                SaveInventory(client, inventoryJson);
                return;
            }

            inventoryItems[index].StackCount -= 1;
            inventoryJson = GetInventoryJson(inventoryItems);
            SaveInventory(client, inventoryJson);
            return;
        }

        public static bool UseItemEffect(Client client, string name, InventoryItem item)
        {
            // Check for weapon names first.
            if (Array.IndexOf(WeaponNames.Weapons, name.ToLower()) >= 0)
            {
                return ItemHandler.Weapon(client, name);
            }

            // Handle Outfit
            if (name.ToLower().Contains("topoutfit"))
            {
                ItemHandler.TopOutfit(client, item);
                return true;
            }

            switch (name.ToLower())
            {
                case "medkit":
                    ItemHandler.Heal(client, +25);
                    return true;
                case "armor":
                    ItemHandler.Armor(client, +5);
                    return true;
                case "coffee":
                    ItemHandler.RestoreStats(client);
                    return true;
                case "burger":
                    ItemHandler.Heal(client, +3);
                    return true;
                case "soda":
                    ItemHandler.Heal(client, +5);
                    return true;
                case "beer":
                    ItemHandler.Heal(client, -5);
                    ItemHandler.Drunk(client, 20);
                    return true;
                case "fish":
                    ItemHandler.Heal(client, +8);
                    return true;
                default:
                    return false;
            }
        }

        public static bool BurnItemFromInventory(Client client, string itemName)
        {
            Account account = AccountUtil.RetrieveAccount(client);
            InventoryItem[] inventoryItems = account.GetAllItems();

            string inventoryJson = "";

            int index = -1;
            for (int i = 0; i < inventoryItems.Length; i++)
            {
                if (inventoryItems[i] == null)
                    continue;

                if (inventoryItems[i].Name.ToLower() == itemName.ToLower())
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
                return false;

            client.TriggerEvent("PlaySoundFrontend", "PIN_BUTTON", "ATM_SOUNDS");

            if (inventoryItems[index].StackCount <= 1)
            {
                inventoryItems[index] = null;
                inventoryJson = GetInventoryJson(inventoryItems);
                SaveInventory(client, inventoryJson);
                return true;
            }

            inventoryItems[index].StackCount -= 1;
            inventoryJson = GetInventoryJson(inventoryItems);
            SaveInventory(client, inventoryJson);
            return true;
        }


        /// <summary>
        /// Add an item to the ground from the player's inventory.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="item"></param>
        public static void AddDroppedItemToGround(Client client, InventoryItem item)
        {
            if (item == null)
                return;

            DroppedItem newItem = new DroppedItem(client, item);
            DroppedItems.Add(newItem);
        }

        /// <summary>
        /// Removes an item on the ground if the remote id matches one in the list.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="handle"></param>
        public static void RemoveDroppedItemFromGround(Client client, int handle)
        {
            DroppedItem droppedItem = DroppedItems.Find(x => x.SpawnedObject.Value == handle);

            if (droppedItem == null)
                return;

            if (droppedItem.Position.DistanceTo2D(client.Position) > 3)
                return;

            DroppedItems.Remove(droppedItem);
            droppedItem.PickupItem();
            AddItemToInventory(client, droppedItem.Name, droppedItem.StackCount);
        }

        /// <summary>
        /// Get a Json string based on the inventory array.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string GetInventoryJson(InventoryItem[] items) => JsonConvert.SerializeObject(items);

        /// <summary>
        /// Get the client's inventory. Returns "" if unavailable.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static string GetInventory(Client client) => AccountUtil.RetrieveAccount(client).Inventory;

        /// <summary>
        /// Save the player's inventory.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonInventory"></param>
        public static void SaveInventory(Client client, string jsonInventory)
        {
            Account account = AccountUtil.RetrieveAccount(client);
            client.TriggerEvent("Recieve_Inventory", jsonInventory);
            account.Inventory = jsonInventory;
            Account.PlayerUpdateEvent.Trigger(client, account);
        }

        /// <summary>
        /// Add a new item to the player's inventory.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="itemName"></param>
        /// <param name="amount"></param>
        public static void AddItemToInventory(Client client, string itemName, int amount, InventoryItem specificItem = null)
        {
            string inventoryJson = "";
            int option = 0;
            bool foundOpenSlot = false;

            Account account = AccountUtil.RetrieveAccount(client);

            // If item does not exist. Create a new item.
            InventoryItem invItem = new InventoryItem
            {
                ID = 0,
                Name = itemName,
                StackCount = amount
            };

            if (specificItem != null)
                invItem = specificItem;

            // Grab the player inventory.
            InventoryItem[] inventoryItems = account.GetAllItems();

            // Check if player even has an inventory.
            if (inventoryItems == null)
            {
                inventoryItems = new InventoryItem[27];
                inventoryItems[option] = invItem;
                inventoryJson = GetInventoryJson(inventoryItems);
                SaveInventory(client, inventoryJson);
                client.TriggerEvent("Recieve_Inventory", inventoryJson);
                Utilities.PlaySoundFrontend(client, "PICK_UP", "HUD_FRONTEND_DEFAULT_SOUNDSET");
                return;
            }

            // Check if item type already exists.
            foreach (InventoryItem item in inventoryItems)
            {
                if (item == null)
                    continue;

                if (item.Name.ToLower() == invItem.Name.ToLower())
                {
                    item.StackCount += amount;
                    inventoryJson = GetInventoryJson(inventoryItems);
                    SaveInventory(client, inventoryJson);
                    client.TriggerEvent("Recieve_Inventory", inventoryJson);
                    Utilities.PlaySoundFrontend(client, "PICK_UP", "HUD_FRONTEND_DEFAULT_SOUNDSET");
                    return;
                }
            }

            // If the item does not exist we'll ad it to the inventory now.
            for (option = 0; option < inventoryItems.Length; option++)
            {
                if (inventoryItems[option] == null)
                {
                    foundOpenSlot = true;
                    break;
                }
            }

            if (foundOpenSlot == false)
            {
                client.SendChatMessage("Your inventory is full.");
                return;
            }

            invItem.ID = option;
            inventoryItems[option] = invItem;

            inventoryJson = GetInventoryJson(inventoryItems);
            SaveInventory(client, inventoryJson);

            Utilities.PlaySoundFrontend(client, "PICK_UP", "HUD_FRONTEND_DEFAULT_SOUNDSET");
            client.TriggerEvent("Recieve_Inventory", inventoryJson);
        }

        /// <summary>
        /// Remove an item from the player's inventory based on the index position.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="index"></param>
        public static void RemoveItemFromInventory(Client client, int uniqueID, bool allItems)
        {
            Account account = AccountUtil.RetrieveAccount(client);
            InventoryItem[] inventoryItems = account.GetAllItems();
            int index = -1;

            if (inventoryItems.Length <= 0)
                return;

            index = Array.FindIndex(inventoryItems, x => x.UniqueID == uniqueID);

            if (index == -1)
                return;

            // If the player is dropping all items make sure to set the slot to null.
            if (allItems || inventoryItems[index].StackCount <= 1)
            {
                AddDroppedItemToGround(client, inventoryItems[index]);
                inventoryItems[index] = null;
            } else {
                inventoryItems[index].StackCount -= 1;
            }

            // Save the player's inventory and let them know.
            SaveInventory(client, GetInventoryJson(inventoryItems));
            Utilities.PlaySoundFrontend(client, "CANCEL", "HUD_FRONTEND_DEFAULT_SOUNDSET");

            // Not dropping all items.
            if (allItems || inventoryItems[index] == null)
                return;

            // Make a copy of the item and drop it on the ground.
            InventoryItem droppedItem = inventoryItems[index];
            droppedItem.StackCount = 1;
            AddDroppedItemToGround(client, droppedItem);
        }
    }
}
