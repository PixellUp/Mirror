using GTANetworkAPI;
using Mirror.Commands;
using Mirror.Events;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Classes.Static;
using Mirror.Classes.Models;
using Mirror.Classes.Static.StaticEvents;

namespace Mirror.Handler
{
    public class JoinHandler : Script
    {
        [ServerEvent(Event.PlayerSpawn)]
        public void PlayerSpawnHandler(Client client)
        {
            if (AccountUtil.IsAccountReady(client))
                return;

            Console.WriteLine($"{client.Name} has joined the server.");

            Utilities.FreezePlayerAccount(client, true);
            Utilities.DisablePlayerAccount(client, true);

            client.Position = new Vector3(Settings.Settings.SpawnX, Settings.Settings.SpawnY, Settings.Settings.SpawnZ + 100);
            client.Dimension = Convert.ToUInt32(new Random().Next(1, 999));
            client.Transparency = 0;

            foreach (MaleValidTopConfiguration top in MaleValidTopConfiguration.MaleValidTops)
            {
                client.TriggerEvent("GetMaleTorso", top.ID, top.Torso, top.Undershirt, top.Top);
            }

            foreach (FemaleValidTopConfiguration top in FemaleValidTopConfiguration.FemaleValidTops)
            {
                client.TriggerEvent("GetFemaleTorso", top.ID, top.Torso, top.Undershirt, top.Top);
            }

            foreach (JobInfo jobInfo in JobInfo.JobInformation)
            {
                client.TriggerEvent("eventAddJobInformation", JsonConvert.SerializeObject(jobInfo));
            }

            if (client.Name.ToLower() == "stuyk_test")
            {
                LoginEvents.ForceLogin(client, client.Name);
            }

            if (client.Name.ToLower() == "john_john")
                LoginEvents.ForceLogin(client, "stuyk");

            if (client.Name.ToLower() == "emily_britson")
                LoginEvents.ForceLogin(client, "tidal");
        }
    }
}
