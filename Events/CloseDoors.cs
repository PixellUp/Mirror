using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public static class CloseDoors
    {
        public static void Event(Client client, params object[] arguments)
        {
            Vehicle vehicle = arguments[1] as Vehicle;

            if (client.Position.DistanceTo2D(vehicle.Position) > 5)
                return;

            List<Client> targets = NAPI.Player.GetPlayersInRadiusOfPlayer(25, client);

            foreach (Client target in targets)
            {
                target.TriggerEvent("CloseDoors", vehicle);
            }
        }
    }
}
