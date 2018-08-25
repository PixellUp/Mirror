﻿using GTANetworkAPI;
using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public static class CarEvents
    {
        // these can probably be done with shared data. Will rewrite soonish.


        /// <summary>
        /// Close all of the doors for the target vehicle for players that are in range.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="arguments"></param>
        public static void CloseDoors(Client client, params object[] arguments)
        {
            if (arguments[1] == null)
                return;

            Vehicle vehicle = arguments[1] as Vehicle;

            if (client.Position.DistanceTo2D(vehicle.Position) > 5)
                return;

            List<Client> targets = NAPI.Player.GetPlayersInRadiusOfPlayer(100, client);

            foreach (Client target in targets)
            {
                target.TriggerEvent("eventCloseDoors", vehicle);
            }
        }

        /// <summary>
        /// Open the target door for players in range.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="arguments"></param>
        public static void OpenDoor(Client client, params object[] arguments)
        {
            if (arguments[1] == null)
                return;

            if (arguments[2] == null)
                return;

            Vehicle vehicle = arguments[1] as Vehicle;
            int doorNumber = Convert.ToInt32(arguments[2]);

            if (client.Position.DistanceTo2D(vehicle.Position) > 5)
                return;

            if (client.VehicleSeat != -1)
                return;

            List<Client> targets = NAPI.Player.GetPlayersInRadiusOfPlayer(100, client);

            foreach (Client target in targets)
            {
                target.TriggerEvent("eventOpenDoor", vehicle, doorNumber);
            }
        }

        /// <summary>
        /// Pick lock a vehicle door.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="arguments"></param>
        public static void PicklockDoor(Client client, params object[] arguments)
        {
            if (arguments[1] == null)
                return;

            Vehicle vehicle = arguments[1] as Vehicle;

            if (client.Position.DistanceTo2D(vehicle.Position) > 5)
                return;

            if (!vehicle.Locked)
                return;

            if (Talent.Skillcheck.CheckIntelligence(client, 15, -1))
            {
                vehicle.Locked = false;
            }
            else
            {
                Skills skills = client.GetData("Mirror_Skills") as Skills;
                skills.PushScoresLocally(client);
            }
        }

        /// <summary>
        /// Toggle the engine for the vehicle.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="arguments"></param>
        public static void ToggleEngine(Client client, params object[] arguments)
        {
            if (arguments[1] == null)
                return;

            Vehicle vehicle = arguments[1] as Vehicle;

            if (client.VehicleSeat != -1)
                return;

            if (vehicle.EngineStatus)
            {
                vehicle.EngineStatus = false;
                client.TriggerEvent("eventCreatePlayerNotification", $"Engine Off");
            }
            else
            {
                vehicle.EngineStatus = true;
                client.TriggerEvent("eventCreatePlayerNotification", $"Engine On");
            }
        }

        /// <summary>
        /// Toggle the lights for the target vehicle.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="arguments"></param>
        public static void ToggleLights(Client client, params object[] arguments)
        {
            if (arguments[1] == null)
                return;

            Vehicle vehicle = arguments[1] as Vehicle;

            if (client.VehicleSeat != -1)
                return;

            if (!vehicle.HasData("Headlights"))
                vehicle.SetData("Headlights", true);

            if (Convert.ToBoolean(vehicle.GetData("Headlights")))
            {
                List<Client> targets = NAPI.Player.GetPlayersInRadiusOfPlayer(25, client);
                foreach (Client target in targets)
                {
                    target.TriggerEvent("eventToggleLights", vehicle.Handle, 0);
                    client.TriggerEvent("eventCreatePlayerNotification", $"Lights Off");
                }
                vehicle.SetData("Headlights", false);
            }
            else
            {
                List<Client> targets = NAPI.Player.GetPlayersInRadiusOfPlayer(25, client);
                foreach (Client target in targets)
                {
                    target.TriggerEvent("eventToggleLights", vehicle.Handle, 1);
                    client.TriggerEvent("eventCreatePlayerNotification", $"Lights On");
                }
                vehicle.SetData("Headlights", true);
            }

        }

        /// <summary>
        /// Toggle the lock for the vehicle.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="arguments"></param>
        public static void ToggleLock(Client client, params object[] arguments)
        {
            if (!client.IsInVehicle)
                return;

            if (client.VehicleSeat != -1)
                return;

            client.Vehicle.Locked = !client.Vehicle.Locked;
            if (client.Vehicle.Locked)
            {
                client.TriggerEvent("eventCreatePlayerNotification", $"Locked");
            } else {
                client.TriggerEvent("eventCreatePlayerNotification", $"Unlocked");
            }

        }
    }
}
