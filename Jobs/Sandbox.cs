using GTANetworkAPI;
using Mirror.Classes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Jobs
{
    public class Sandbox : Script
    {
        Dictionary<Vector3, string> jobPositions = new Dictionary<Vector3, string>();

        [Command("leavemission")]
        public void CmdLeaveMission(Client client)
        {
            if (!client.HasData("Mission_Active"))
                return;

            if (!(client.GetData("Mission_Active") is Mission mission))
                return;

            mission.RemoveActivePlayer(client);
        }

        [Command("startjob")]
        public void CMDJob(Client client)
        {
            Mission mission = new Mission();

            NetHandle vehicle = NAPI.Vehicle.CreateVehicle(VehicleHash.Baller2, new Vector3(), 0, 255, 255, "", 255, true, false);

            foreach (var element in jobPositions)
            {
                Objective objective = new Objective
                {
                    ID = 0,
                    X = Convert.ToInt32(element.Key.X),
                    Y = Convert.ToInt32(element.Key.Y),
                    Z = Convert.ToInt32(element.Key.Z),
                    Progression = 0,
                    Radius = 3,
                    Type = element.Value
                };

                if (objective.Type == "Retrieve Car")
                {
                    NAPI.Entity.SetEntityPosition(vehicle, objective.GetLocation());
                    objective.RequiredVehicles = new NetHandle[] { vehicle };
                }
                
                if (objective.Type == "Deliver Car")
                {
                    objective.RequiredVehicles = new NetHandle[] { vehicle };
                }

                mission.Objectives.Enqueue(objective);
            }

            mission.AddActivePlayer(client);

            jobPositions.Clear();
        }

        [Command("addplayer")]
        public void CmdAddPlayerToMission(Client client, string playerName)
        {
            if (playerName == null)
                return;

            if (!client.HasData("Mission_Active"))
            {
                client.SendChatMessage("Not on a mission currently.");
                return;
            }

            var targetPlayer = NAPI.Pools.GetAllPlayers().Find(x => x.Name.ToLower().Contains(playerName.ToLower()));

            if (targetPlayer == null)
                return;

            Mission miss =  client.GetData("Mission_Active") as Mission;
            if (!miss.AddActivePlayer(targetPlayer))
            {
                client.SendChatMessage("Player is already in a mission.");
            }
        }
    }
}
