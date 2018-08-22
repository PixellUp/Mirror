using GTANetworkAPI;
using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Jobs
{
    public class Sandbox : Script
    {
        List<Vector3> jobPositions = new List<Vector3>();


        [Command("startjob")]
        public void CMDJob(Client client)
        {
            Mission mission = new Mission();

            jobPositions.ForEach((position) =>
            {
                Objective objective = new Objective
                {
                    ID = 0,
                    X = Convert.ToInt32(position.X),
                    Y = Convert.ToInt32(position.Y),
                    Z = Convert.ToInt32(17),
                    Progression = 0,
                    Radius = 3,
                    Type = "Capture"
                };
                mission.Objectives.Enqueue(objective);
            });

            mission.AddActivePlayer(client);

            jobPositions = new List<Vector3>();
        }

        [Command("examplejob")]
        public void CmdExampleJob(Client client)
        {
            Mission mission = new Mission();

            Objective objective = new Objective
            {
                ID = 0,
                X = 1,
                Y = 2,
                Z = 3,
                Progression = 0,
                Radius = 3,
                Type = "Capture"
            };
            mission.Objectives.Enqueue(objective);

            objective = new Objective
            {
                ID = 0,
                X = 1,
                Y = 2,
                Z = 3,
                Progression = 0,
                Radius = 3,
                Type = "Capture"
            };
            mission.Objectives.Enqueue(objective);

            objective = new Objective
            {
                ID = 0,
                X = 1,
                Y = 2,
                Z = 3,
                Progression = 0,
                Radius = 3,
                Type = "Capture"
            };
            mission.Objectives.Enqueue(objective);

            mission.AddActivePlayer(client);
        }

        [Command("addjobpos")]
        public void CMDAddJobPOS(Client client)
        {
            jobPositions.Add(client.Position);
            client.SendChatMessage("Added...");
        }

        [Command("addplayer")]
        public void CmdAddPlayerToMission(Client client, string playerName)
        {
            if (playerName == null)
                return;

            if (!client.HasData("Mission_Active"))
            {
                client.SendChatMessage("Not on mission currently.");
                return;
            }

            var targetPlayer = NAPI.Pools.GetAllPlayers().Find(x => x.Name.ToLower().Equals(playerName.ToLower()));

            if (targetPlayer == null)
                return;

            Mission miss =  client.GetData("Mission_Active") as Mission;
            miss.AddActivePlayer(targetPlayer);
        }
    }
}
