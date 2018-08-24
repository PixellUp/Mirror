using GTANetworkAPI;
using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public static class PickupItemInventory
    {
        public static void Event(Client client, params object[] args)
        {
            if (args[1] == null)
                return;

            bool matched = false;

            for (int i = 0; i < Inventory.DroppedItems.Count; i++)
            {
                if (Inventory.DroppedItems[i].SpawnedObject == null)
                    continue;

                if (Inventory.DroppedItems[i].SpawnedObject.Value == Convert.ToInt32(args[1]))
                {
                    matched = true;
                    break;
                }
            }

            if (!matched)
                return;

            Inventory.RemoveDroppedItemFromGround(client);
        }
    }
}
