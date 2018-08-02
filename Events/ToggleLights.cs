using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace Mirror.Events
{
    public static class ToggleLights
    {  
        public static void Event(Client client, params object[] arguments)
        {
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
                    target.TriggerEvent("ToggleLights", vehicle.Handle, 0);
                    client.TriggerEvent("ArpgNotification", $"Lights Off");
                }
                vehicle.SetData("Headlights", false);
            } else {
                List<Client> targets = NAPI.Player.GetPlayersInRadiusOfPlayer(25, client);
                foreach (Client target in targets)
                {
                    target.TriggerEvent("ToggleLights", vehicle.Handle, 1);
                    client.TriggerEvent("ArpgNotification", $"Lights On");
                }
                vehicle.SetData("Headlights", true);
            }
            
        }
    }
}
