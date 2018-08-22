using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Models
{
    public class Mission
    {
        public List<NetHandle> ActivePlayers { get; set; } = new List<NetHandle>();
        public Queue<Objective> Objectives { get; set; } = new Queue<Objective>();
        public List<Objective> FinishedObjectives { get; set; } = new List<Objective>();

        // Get all the Active Objectives so we can use it for our mission builder.
        public Objective[] GetObjectives()
        {
            return Objectives.ToArray();
        }

        // Get all the Active Players so we can use it for our mission builder.
        public NetHandle[] GetActivePlayers()
        {
            return ActivePlayers.ToArray();
        }

        public bool UpdateObjectives()
        {
            Objective clearedObjective = Objectives.Dequeue();

            if (!FinishedObjectives.Contains(clearedObjective))
                FinishedObjectives.Add(clearedObjective);

            if (GetObjectives().Length <= 0)
            {
                CleanupMission();

                for (int i = 0; i < ActivePlayers.Count; i++)
                {
                    NAPI.Player.GetPlayerFromHandle(ActivePlayers[i]).TriggerEvent("eventCreatePlayerNotification", $"Objective Complete");
                    NAPI.ClientEvent.TriggerClientEvent(NAPI.Player.GetPlayerFromHandle(ActivePlayers[i]), "MissionInfo", "Mission_Active_Objectives", "");
                }
                return true;
            }


            string activeObjectives = JsonConvert.SerializeObject(GetObjectives());
            for (int i = 0; i < ActivePlayers.Count; i++)
            {
                NAPI.ClientEvent.TriggerClientEvent(NAPI.Player.GetPlayerFromHandle(ActivePlayers[i]), "MissionInfo", "Mission_Active_Objectives", activeObjectives);
                NAPI.Player.GetPlayerFromHandle(ActivePlayers[i]).TriggerEvent("eventCreatePlayerNotification", $"Objective Complete");

            }

            return true;
        }

        public void CleanupMission()
        {
            if (FinishedObjectives.Count <= 0)
                return;

            FinishedObjectives.ForEach((objective) =>
            {
                // Delete Vehicles
                if (objective.RequiredVehicles.Length > 0)
                {
                    for (int i = 0; i < objective.RequiredVehicles.Length; i++)
                    {
                        NAPI.Entity.DeleteEntity(objective.RequiredVehicles[i]);
                    }
                }
                       
            });
        }

        /// <summary>
        /// Add the player to the Active Players list for the Mission.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool AddActivePlayer(Client client)
        {
            if (client.HasData("Mission_Active"))
            {
                client.SendChatMessage("You must leave your current mission to join a new one. /leavemission");
                return false;
            }

            if (ActivePlayers.Contains(client))
                return false;

            ActivePlayers.Add(client);
            client.SetData("Mission_Active", this);

            string activePlayers = JsonConvert.SerializeObject(GetActivePlayers());
            string activeObjectives = JsonConvert.SerializeObject(GetObjectives());

            for (int i = 0; i < ActivePlayers.Count; i++)
            {
                NAPI.ClientEvent.TriggerClientEvent(NAPI.Player.GetPlayerFromHandle(ActivePlayers[i]), "MissionInfo", "Mission_Active_Players", activePlayers);
                NAPI.ClientEvent.TriggerClientEvent(NAPI.Player.GetPlayerFromHandle(ActivePlayers[i]), "MissionInfo", "Mission_Active_Objectives", activeObjectives);
            }

            return true;
        }

        /// <summary>
        /// Remove the player from the Active Players list for the Mission.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool RemoveActivePlayer(Client client)
        {
            if (!ActivePlayers.Contains(client))
                return false;

            ActivePlayers.Remove(client);
            client.ResetData("Mission_Active");
            NAPI.ClientEvent.TriggerClientEvent(client, "MissionInfo", "Mission_Active_Players", "");
            NAPI.ClientEvent.TriggerClientEvent(client, "MissionInfo", "Mission_Active_Objectives", "");

            string activePlayers = JsonConvert.SerializeObject(GetActivePlayers());

            for (int i = 0; i < ActivePlayers.Count; i++)
                NAPI.ClientEvent.TriggerClientEvent(NAPI.Player.GetPlayerFromHandle(ActivePlayers[i]), "MissionInfo", "Mission_Active_Players", activePlayers);

            if (ActivePlayers.Count <= 0)
                CleanupMission();

            return true;
        }
    }
}
