using GTANetworkAPI;
using Newtonsoft.Json;
using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Handler
{
    public static class InventoryHandler
    {
        public static List<DroppedItem> DroppedItems = new List<DroppedItem>();

        public static void UseItem(Client client, int index)
        {
            if (!(client.GetData("Mirror_Account") is Account account))
                return;

            InventoryItem[] inventoryItems = GetInventoryArray(account.Inventory);

            if (inventoryItems[index] == null)
                return;

            string inventoryJson = "";

            bool itemFound = UseItemEffect(client, inventoryItems[index].Name.ToLower());

            if (!itemFound)
            {
                client.SendChatMessage("That item doesn't seem to have any effect.");
                return;
            }

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

        public static bool UseItemEffect(Client client, string name)
        {
            switch (name)
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
                case "pistol50":
                    ItemHandler.Weapon(client, name);
                    return true;
                default:
                    return false;
            }
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
            DroppedItem droppedItem = null;
            foreach (DroppedItem item in DroppedItems)
            {
                if (item == null)
                    continue;

                if (item.Position.DistanceTo2D(client.Position) > 3)
                    continue;

                if (item.SpawnedObject.Value != handle)
                    continue;

                droppedItem = item;
                DroppedItems.Remove(droppedItem);
                break;
            }

            if (droppedItem == null)
                return;

            droppedItem.PickupItem();
            AddItemToInventory(client, droppedItem.Name, droppedItem.StackCount);
        }

        /// <summary>
        /// Get a Json string based on the inventory array.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string GetInventoryJson(InventoryItem[] items)
        {
            return JsonConvert.SerializeObject(items);
        }

        /// <summary>
        /// Get an Array based on the inventory json string.
        /// </summary>
        /// <param name="jsonInventory"></param>
        /// <returns></returns>
        public static InventoryItem[] GetInventoryArray(string jsonInventory)
        {
            return JsonConvert.DeserializeObject<InventoryItem[]>(jsonInventory);
        }

        /// <summary>
        /// Get the client's inventory. Returns "" if unavailable.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static string GetInventory(Client client)
        {
            if (!(client.GetData("Mirror_Account") is Account account))
                return "";

            return account.Inventory;
        }

        /// <summary>
        /// Save the player's inventory.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="jsonInventory"></param>
        public static void SaveInventory(Client client, string jsonInventory)
        {
            if (!(client.GetData("Mirror_Account") is Account account))
                return;

            client.TriggerEvent("Recieve_Inventory", jsonInventory);
            account.Inventory = jsonInventory;
            account.Update();
        }

        /// <summary>
        /// Add a new item to the player's inventory.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="itemName"></param>
        /// <param name="amount"></param>
        public static void AddItemToInventory(Client client, string itemName, int amount)
        {
            string inventoryJson = "";
            int option = 0;
            bool foundOpenSlot = false;

            if (!(client.GetData("Mirror_Account") is Account account))
                return;

            // If item does not exist. Create a new item.
            InventoryItem invItem = new InventoryItem
            {
                ID = 0,
                Name = itemName,
                StackCount = amount
            };

            // Grab the player inventory.
            InventoryItem[] inventoryItems = GetInventoryArray(account.Inventory);

            // Check if player even has an inventory.
            if (inventoryItems == null)
            {
                inventoryItems = new InventoryItem[27];
                inventoryItems[option] = invItem;
                inventoryJson = GetInventoryJson(inventoryItems);
                SaveInventory(client, inventoryJson);
                client.TriggerEvent("PlaySoundFrontend", "TOGGLE_ON", "HUD_FRONTEND_DEFAULT_SOUNDSET");
                return;
            }

            // Check if item type already exists.
            foreach (InventoryItem item in inventoryItems)
            {
                if (item == null)
                    continue;

                if (item.Name.ToLower() == itemName.ToLower())
                {
                    item.StackCount += amount;
                    inventoryJson = GetInventoryJson(inventoryItems);
                    SaveInventory(client, inventoryJson);
                    client.TriggerEvent("Recieve_Inventory", inventoryJson);
                    client.TriggerEvent("PlaySoundFrontend", "TOGGLE_ON", "HUD_FRONTEND_DEFAULT_SOUNDSET");
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

            client.TriggerEvent("PlaySoundFrontend", "TOGGLE_ON", "HUD_FRONTEND_DEFAULT_SOUNDSET");
            client.TriggerEvent("Recieve_Inventory", inventoryJson);
        }

        /// <summary>
        /// Remove an item from the player's inventory based on the index position.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="index"></param>
        public static void RemoveItemFromInventory(Client client, int index, bool allItems)
        {
            if (!(client.GetData("Mirror_Account") is Account account))
                return;

            InventoryItem[] inventoryItems = GetInventoryArray(account.Inventory);

            if (inventoryItems[index] == null)
                return;

            string inventoryJson = "";

            if (allItems || inventoryItems[index].StackCount <= 1)
            {
                AddDroppedItemToGround(client, inventoryItems[index]);
                inventoryItems[index] = null;
                inventoryJson = GetInventoryJson(inventoryItems);
                SaveInventory(client, inventoryJson);
                client.TriggerEvent("PlaySoundFrontend", "CANCEL", "HUD_FRONTEND_DEFAULT_SOUNDSET");
                return;
            }

            inventoryItems[index].StackCount -= 1;
            inventoryJson = GetInventoryJson(inventoryItems);
            SaveInventory(client, inventoryJson);

            InventoryItem item = new InventoryItem()
            {
                ID = inventoryItems[index].ID,
                Name = inventoryItems[index].Name,
                StackCount = 1
            };
            client.TriggerEvent("PlaySoundFrontend", "CANCEL", "HUD_FRONTEND_DEFAULT_SOUNDSET");
            AddDroppedItemToGround(client, item);
            return;
        }
    }
}
