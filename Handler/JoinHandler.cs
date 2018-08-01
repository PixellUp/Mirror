using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Handler
{
    public class JoinHandler : Script
    {
        [ServerEvent(Event.PlayerSpawn)]
        public void PlayerSpawnHandler(Client client)
        {
            if (client.HasData("Account"))
                return;

            client.TriggerEvent("Freeze", client.Handle, true);
            client.TriggerEvent("Disable", true);
        }
    }
}
