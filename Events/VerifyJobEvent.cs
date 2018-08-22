using GTANetworkAPI;
using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public static class VerifyJobEvent
    {
        public static void Event(Client client, params object[] args)
        {
            if (!(client.GetData("Mission_Active") is Mission mission))
                return;

            if (mission.Objectives.Count <= 0)
                return;

            Objective objective = mission.Objectives.Peek();

            if (client.Position.DistanceTo2D(objective.GetLocation()) <= objective.Radius)
            {
                mission.Objectives.Dequeue();
                mission.UpdateObjectives();
            }
        }
    }
}
