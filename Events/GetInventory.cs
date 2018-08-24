using GTANetworkAPI;
using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public static class GetInventory
    {
        public static void Event(Client client, params object[] args)
        {
            string json = Inventory.GetInventory(client);
            client.TriggerEvent("Recieve_Inventory", json);
        }
    }
}
