﻿using GTANetworkAPI;
using Mirror.Handler;
using Mirror.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.StaticEvents
{
    public static class InventoryEvents
    {
        /// <summary>
        /// Use an item based on the 'type' / 'name' of the item.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="args"></param>
        public static void UseItem(Client client, params object[] args)
        {
            // Unique ID
            if (args[1] == null)
                return;

            InventoryHandler.UseItem(client, Convert.ToInt32(args[1]));
        }

        /// <summary>
        /// Drop an item on the ground.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="args"></param>
        public static void DropItem(Client client, params object[] args)
        {
            // Unique ID
            if (args[1] == null)
                return;

            // Boolean to drop all.
            if (args[2] == null)
                return;

            InventoryHandler.RemoveItemFromInventory(client, Convert.ToInt32(args[1]), Convert.ToBoolean(args[2]));
            SyncInventory(client);
        }

        /// <summary>
        /// Sync the player's inventory to client-side.
        /// </summary>
        /// <param name="client"></param>
        public static void SyncInventory(Client client)
        {
            string json = InventoryHandler.GetInventory(client);
            client.TriggerEvent("Recieve_Inventory", json);
        }

        /// <summary>
        /// Pickup and item off the ground. Called from client-side.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="args"></param>
        public static void PickupItem(Client client, params object[] args)
        {
            if (args[1] == null)
                return;

            InventoryHandler.RemoveDroppedItemFromGround(client, Convert.ToInt32(args[1]));
        }

        public static void UnequipWeapon(Client client)
        {
            if (client.CurrentWeapon == WeaponHash.Unarmed)
                return;

            WeaponHash currentWeapon = client.CurrentWeapon;
            bool wasItemUnequipped = AccountUtil.RemovePlayerWeapon(client, currentWeapon);

            if (!wasItemUnequipped)
                return;

            InventoryHandler.AddItemToInventory(client, currentWeapon.ToString(), 1);
        }
    }
}
