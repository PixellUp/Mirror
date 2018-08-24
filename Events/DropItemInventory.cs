using GTANetworkAPI;
using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public static class DropItemInventory
    {
        public static void Event(Client client, params object[] args)
        {
            if (args[1] == null)
                return;

            Inventory.RemoveItemFromInventory(client, Convert.ToInt32(args[1]));
            GetInventory.Event(client, "");
        }
    }
}
