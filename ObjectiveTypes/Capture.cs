using GTANetworkAPI;
using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.ObjectiveTypes
{
    public static class Capture
    {
        public static bool Event(Client client, Mission mission, Objective objective)
        {
            if (client.Position.DistanceTo2D(objective.GetLocation()) > objective.Radius)
                return false;

            mission.UpdateObjectives();
            return true;
        }
    }
}
