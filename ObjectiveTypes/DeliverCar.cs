﻿using GTANetworkAPI;
using Mirror.Classes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.ObjectiveTypes
{
    public static class DeliverCar
    {
        public static bool Event(Client client, Mission mission, Objective objective)
        {
            if (client.Position.DistanceTo2D(objective.GetLocation()) > objective.Radius)
                return false;

            if (!client.IsInVehicle)
                return false;

            if (client.VehicleSeat != -1)
                return false;

            bool isVehicleAtLocation = false;

            for (int i = 0; i < objective.RequiredVehicles.Length; i++)
            {
                if (client.Vehicle == objective.RequiredVehicles[i])
                    isVehicleAtLocation = true;
            }

            if (!isVehicleAtLocation)
                return false;

            mission.UpdateObjectives();
            return true;
        }
    }
}
