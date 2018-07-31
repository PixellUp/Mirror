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

            if (!vehicle.HasData("Headlights"))
                vehicle.SetData("Headlights", true);

            if (vehicle.GetData("Headlights"))
            {
                NAPI.ClientEvent.TriggerClientEventInRange(client.Position, 50f, "ClientTasks", "ToggleLights", vehicle, false);
            } else  {
                NAPI.ClientEvent.TriggerClientEventInRange(client.Position, 50f, "ClientTasks", "ToggleLights", vehicle, true);
                
            }
        }
    }
}
