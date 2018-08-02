using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public static class ToggleLock
    {
        public static void Event(Client client, params object[] arguments)
        {
            if (!client.IsInVehicle)
                return;

            if (client.VehicleSeat != -1)
                return;

            client.Vehicle.Locked = !client.Vehicle.Locked;
            if (client.Vehicle.Locked)
            {
                client.TriggerEvent("ArpgNotification", $"Locked");
            } else {
                client.TriggerEvent("ArpgNotification", $"Unlocked");
            }
            
        }
    }
}
