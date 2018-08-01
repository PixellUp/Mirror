using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Commands
{
    public class Sandbox : Script
    {
        [Command("cv")]
        public void CreateVehicle(Client client, string value)
        {
            VehicleHash veh = (VehicleHash)Enum.Parse(typeof(VehicleHash), value);
            Vehicle newVeh = NAPI.Vehicle.CreateVehicle(veh, client.Position.Around(5), 0, 45, 45, "TESTING", 255, false, true);
        }

        [Command("time")]
        public void SetTime(Client client, int hour)
        {
            NAPI.World.SetTime(hour, 0, 0);
        }
    }
}
