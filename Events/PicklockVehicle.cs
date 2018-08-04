using GTANetworkAPI;
using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public static class PicklockVehicle
    {
        public static void Event(Client client, params object[] arguments)
        {
            Vehicle vehicle = arguments[1] as Vehicle;

            if (client.Position.DistanceTo2D(vehicle.Position) > 5)
                return;

            if (!vehicle.Locked)
                return;

            if (Talent.Skillcheck.CheckIntelligence(client, 15, -1))
            {
                vehicle.Locked = false;
            } else {
                Skills skills = client.GetData("Mirror_Skills") as Skills;
                skills.PushScoresLocally(client);
            }
        }
    }
}
