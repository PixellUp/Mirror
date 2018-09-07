using GTANetworkAPI;
using Mirror.Commands;
using Mirror.Events;
using Mirror.Models;
using Newtonsoft.Json;
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
            Console.WriteLine($"{client.Name} has joined the server.");

            if (client.HasData("Mirror_Account"))
                return;

            client.Position = new Vector3(Settings.Settings.SpawnX, Settings.Settings.SpawnY, Settings.Settings.SpawnZ + 0.2);
            //client.TriggerEvent("eventFreeze", client.Handle, true);
            client.TriggerEvent("eventDisable", true);
            client.Dimension = 0;
            client.Transparency = 255;

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
        }
    }
}
