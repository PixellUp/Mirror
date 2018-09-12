using GTANetworkAPI;
using Mirror.Classes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.ObjectiveTypes
{
    public static class Drive
    {
        public static bool Event(Client client, Mission mission, Objective objective)
        {
            if (client.Position.DistanceTo2D(objective.GetLocation()) > objective.Radius)
                return false;

            if (client.VehicleSeat != -1)
                return false;

            if (!client.IsInVehicle)
                return false;

            mission.UpdateObjectives();
            return true;
        }
    }
}
