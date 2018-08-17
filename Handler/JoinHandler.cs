using GTANetworkAPI;
using Mirror.Models;
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
            if (client.HasData("Mirror_Account"))
                return;

            client.Position = new Vector3(Settings.Settings.SpawnX, Settings.Settings.SpawnY, Settings.Settings.SpawnZ);
            client.TriggerEvent("eventFreeze", client.Handle, true);
            client.TriggerEvent("eventDisable", true);
            client.Dimension = 999;
            client.Transparency = 0;

            foreach (MaleValidTopConfiguration top in MaleValidTopConfiguration.MaleValidTops)
            {
                client.TriggerEvent("GetMaleTorso", top.ID, top.Torso, top.Undershirt, top.Top);
            }

            foreach (FemaleValidTopConfiguration top in FemaleValidTopConfiguration.FemaleValidTops)
            {
                client.TriggerEvent("GetFemaleTorso", top.ID, top.Torso, top.Undershirt, top.Top);
            }
        }
    }
}
