using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public static class ToggleEngine
    {
        public static void Event(Client client, params object[] arguments) {
            Vehicle vehicle = arguments[1] as Vehicle;

            if (vehicle.EngineStatus)
            {
                vehicle.EngineStatus = false;
            } else {
                vehicle.EngineStatus = true;
            }
        }

    }
}
