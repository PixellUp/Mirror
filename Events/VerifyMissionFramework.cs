using GTANetworkAPI;

using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public static class VerifyMissionFramework
    {
        public static void Event(Client client, params object[] args)
        {
            if (!(client.GetData("Mission_Active") is Mission mission))
                return;

            if (mission.Objectives.Count <= 0)
                return;

            Objective objective = mission.Objectives.Peek();

            switch(objective.Type)
            {
                case "Capture":
                    ObjectiveTypes.Capture.Event(client, mission, objective);
                    return;
                case "Drive":
                    ObjectiveTypes.Drive.Event(client, mission, objective);
                    return;
                case "Deliver Car":
                    ObjectiveTypes.DeliverCar.Event(client, mission, objective);
                    return;
                case "Retrieve Car":
                    ObjectiveTypes.RetrieveCar.Event(client, mission, objective);
                    return;
            }
        }
    }
}
