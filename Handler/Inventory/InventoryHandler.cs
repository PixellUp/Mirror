using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Utility;
using Mirror.Classes.Models;
using Mirror.Globals;

namespace Mirror.Handler
{
    public static class InventoryHandler
    {
        public static List<DroppedItem> DroppedItems = new List<DroppedItem>();

        /// <summary>
        /// Use the item if it has a specific effect available for it.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="uniqueID"></param>
        public static void UseItem(Client client, int uniqueID)
        {
            Account account = AccountUtil.RetrieveAccount(client);
            InventoryItem[] inventoryItems = account.GetAllItems();
            int index = GetIndexFromUniqueID(inventoryItems, uniqueID);

            if (index == -1 || account.IsDead)
                return;

            bool itemFound = UseItemEffect(client, inventoryItems[index]);

            if (!itemFound)
            {
                Utilities.PlaySoundFrontend(client, "ERROR", "HUD_FRONTEND_DEFAULT_SOUNDSET");
                Utilities.PushBrowserEvent(client, BrowserData.Inventory_Item_Has_No_Use);
                return;
            }

            inventoryItems[index].StackCount -= 1;

            if (inventoryItems[index].StackCount <= 0)
                inventoryItems[index] = null;

            SaveInventory(client, GetInventoryJson(inventoryItems));
            Utilities.PushBrowserEvent(client, BrowserData.Inventory_Used_Item);
            Utilities.PlaySoundFrontend(client, "PIN_BUTTON", "ATM_SOUNDS");
        }

        /// <summary>
        /// Get the index of the item's location from a unique id.
        /// </summary>
        /// <param name="inventoryItems"></param>
        /// <param name="uniqueID"></param>
        /// <returns></returns>
        public static int GetIndexFromUniqueID(InventoryItem[] inventoryItems ,int uniqueID)
        {
            int index = -1;

            for (int i = 0; i < inventoryItems.Length; i++)
            {
                if (inventoryItems[i] == null)
                    continue;

                if (inventoryItems[i].UniqueID != uniqueID)
                    continue;

                index = i;
                break;
            }

            return index;
        }

        /// <summary>
        /// Get the index based on the name of the item. Accounts for null checks.
        /// </summary>
        /// <param name="inventoryItems"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public static int GetIndexFromName(InventoryItem[] inventoryItems, string itemName)
        {
            int index = -1;

            for (int i = 0; i < inventoryItems.Length; i++)
            {
                if (inventoryItems[i] == null)
                    continue;

                if (inventoryItems[i].Name.ToLower() != itemName.ToLower())
                    continue;

                index = i;
                break;
            }

            return index;
        }

        public static bool UseItemEffect(Client client, InventoryItem item)
        {
            // Check for weapon names first.
            if (Array.IndexOf(WeaponNamesData.Weapons, item.Name.ToLower()) >= 0)
                return ItemHandler.Weapon(client, item.Name);

            // Handle Outfit
            if (item.Name.ToLower().Contains("topoutfit"))
            {
                ItemHandler.TopOutfit(client, item);
                return true;
            }

            switch (item.Name.ToLower())
            {
                case "medkit":
                    return ItemHandler.Heal(client, +25);
                case "armor":
                    return ItemHandler.Armor(client, +5);
                case "coffee":
                    ItemHandler.RestoreStats(client);
                    return true;
                case "burger":
                    return ItemHandler.Heal(client, +3);
                case "soda":
                    return ItemHandler.Heal(client, +5);
                case "beer":
                    ItemHandler.Drunk(client, 20);
                    return ItemHandler.Heal(client, -5);
                case "fish":
                    return ItemHandler.Heal(client, +8);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Completely burns an item from the inventory. Stacks are taken into account.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public static bool BurnItemFromInventory(Client client, string itemName)
        {
            Account account = AccountUtil.RetrieveAccount(client);
            InventoryItem[] inventoryItems = account.GetAllItems();

            int index = GetIndexFromName(inventoryItems, itemName);

            if (index == -1)
                return false;

            Utilities.PlaySoundFrontend(client, "PIN_BUTTON", "ATM_SOUNDS");

            inventoryItems[index].StackCount -= 1;

            if (inventoryItems[index].StackCount <= 0)
                inventoryItems[index] = null;

            SaveInventory(client, GetInventoryJson(inventoryItems));
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
            AddItemToInventory(client, droppedItem.Name, droppedItem.StackCount, droppedItem.Item);
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
            account.Inventory = jsonInventory;
            Account.PlayerUpdateEvent.Trigger(client, account);
            SendInventoryLocally(client);
        }

        /// <summary>
        /// Send the player's inventory as a JSON string locally.
        /// </summary>
        /// <param name="client"></param>
        public static void SendInventoryLocally(Client client)
        {
            client.TriggerEvent("Recieve_Inventory", AccountUtil.RetrieveAccount(client).Inventory);
            Utilities.PushBrowserEvent(client, BrowserData.Inventory_Update_Data);
        }

        /// <summary>
        /// Add a new item to the player's inventory.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="itemName"></param>
        /// <param name="amount"></param>
        public static void AddItemToInventory(Client client, string itemName, int amount, InventoryItem specificItem = null)
        {
            Account account = AccountUtil.RetrieveAccount(client);
            int option = 0;
            bool foundOpenSlot = false;

            if (account.IsDead)
                return;

            InventoryItem invItem = new InventoryItem
            {
                ID = 0,
                Name = itemName,
                StackCount = amount
            };

            // Use the item provided instead if it is provided.
            if (specificItem != null)
                invItem = specificItem;

            // Grab the player inventory.
            InventoryItem[] inventoryItems = account.GetAllItems();

            // Check if player even has an inventory.
            if (inventoryItems.Length <= 0)
            {
                inventoryItems = new InventoryItem[27];
                inventoryItems[option] = invItem;
                SaveInventory(client, GetInventoryJson(inventoryItems));
                SendInventoryLocally(client);
                Utilities.PlaySoundFrontend(client, "PICK_UP", "HUD_FRONTEND_DEFAULT_SOUNDSET");
                return;
            }

            // Check if item type already exists and if it does stack it and finish.
            foreach (InventoryItem item in inventoryItems)
            {
                if (item == null)
                    continue;

                if (item.Name.ToLower() == invItem.Name.ToLower() && item.IsStackable)
                {
                    item.StackCount += amount;
                    SaveInventory(client, GetInventoryJson(inventoryItems));
                    SendInventoryLocally(client);
                    Utilities.PlaySoundFrontend(client, "PICK_UP", "HUD_FRONTEND_DEFAULT_SOUNDSET");
                    return;
                }
            }

            // If the item does not exist we'll add it to the inventory now and find an open slot.
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
                client.SendNotification("Your inventory is full.");
                Utilities.PlaySoundFrontend(client, "ERROR", "HUD_FRONTEND_DEFAULT_SOUNDSET");
                return;
            }

            invItem.ID = option;
            inventoryItems[option] = invItem;
            SaveInventory(client, GetInventoryJson(inventoryItems));
            SendInventoryLocally(client);
            Utilities.PlaySoundFrontend(client, "PICK_UP", "HUD_FRONTEND_DEFAULT_SOUNDSET");
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

            int index = GetIndexFromUniqueID(inventoryItems, uniqueID);

            if (index == -1 || account.IsDead)
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
