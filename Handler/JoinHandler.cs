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

            client.Position = new Vector3(Settings.Settings.SpawnX, Settings.Settings.SpawnY, Settings.Settings.SpawnZ);
            client.TriggerEvent("Freeze", client.Handle, true);
            client.TriggerEvent("Disable", true);
            client.Dimension = 999;
            client.Transparency = 0;
        }
    }
}
