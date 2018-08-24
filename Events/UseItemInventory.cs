using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public static class UseItemInventory
    {
        public static void Event(Client client, params object[] args)
        {
            if (args[1] == null)
                return;





            GetInventory.Event(client, "");
        }
    }
}
