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

            client.SendChatMessage($"You picked up a {droppedItem.Name}");
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
            if (!(client.GetData("Mirror_Account") is Account account))
                return;

            InventoryItem[] inventoryItems = GetInventoryArray(account.Inventory);

            InventoryItem invItem = new InventoryItem
            {
                ID = 0,
                Name = itemName,
                StackCount = 1
            };

            int option = 0;
            bool foundOpenSlot = false;
            string inventoryJson = "";

            if (inventoryItems == null)
            {
                inventoryItems = new InventoryItem[27];
                inventoryItems[option] = invItem;
                inventoryJson = GetInventoryJson(inventoryItems);
                SaveInventory(client, inventoryJson);
                return;
            }

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

            client.TriggerEvent("Recieve_Inventory", inventoryJson);
        }

        /// <summary>
        /// Remove an item from the player's inventory based on the index position.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="index"></param>
        public static void RemoveItemFromInventory(Client client, int index)
        {
            if (!(client.GetData("Mirror_Account") is Account account))
                return;

            InventoryItem[] inventoryItems = GetInventoryArray(account.Inventory);

            if (inventoryItems[index] == null)
                return;

            AddDroppedItemToGround(client, inventoryItems[index]);

            client.SendChatMessage($"Dropped -> {inventoryItems[index].Name}");

            inventoryItems[index] = null;

            string inventoryJson = GetInventoryJson(inventoryItems);
            SaveInventory(client, inventoryJson);
        }
    }
}
