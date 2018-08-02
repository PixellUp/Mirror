using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace Mirror.Events
{
    public static class OpenDoor
    {  
        public static void Event(Client client, params object[] arguments)
        {
            Vehicle vehicle = arguments[1] as Vehicle;
            int doorNumber = Convert.ToInt32(arguments[2]);

            if (client.Position.DistanceTo2D(vehicle.Position) > 5)
                return;

            if (client.VehicleSeat != -1)
                return;

            List<Client> targets = NAPI.Player.GetPlayersInRadiusOfPlayer(25, client);

            foreach (Client target in targets)
            {
                target.TriggerEvent("OpenDoor", vehicle, doorNumber);
            }
        }
    }
}
