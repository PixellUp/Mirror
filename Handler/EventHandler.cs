using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Handler
{
    public class EventHandler : Script
    {
        [RemoteEvent("EventHandler")]
        public void Handler(Client client, params object[] arguments)
        {
            if (arguments.Length <= 0)
                return;

            // First argument will always be the event name.
            string eventName = arguments[0] as string;
            
            switch(eventName)
            {
                case "ToggleEngine":
                    Events.ToggleEngine.Event(client, arguments);
                    return;
                case "ToggleLights":
                    Events.ToggleLights.Event(client, arguments);
                    return;
                case "OpenDoor":
                    Events.OpenDoor.Event(client, arguments);
                    return;
                case "CloseDoors":
                    Events.CloseDoors.Event(client, arguments);
                    return;
                case "AttackPlayer":
                    Events.AttackPlayer.Event(client, arguments);
                    return;
                case "StopAttacking":
                    Events.StopAttacking.Event(client);
                    return;
                case "ToggleLock":
                    Events.ToggleLock.Event(client, arguments);
                    return;
                case "PicklockVehicle":
                    Events.PicklockVehicle.Event(client, arguments);
                    return;
                case "PushAppearanceChanges":
                    Events.PushAppearanceChanges.Event(client, arguments);
                    return;
                case "RequestFace":
                    Events.RequestFace.Event(client, arguments);
                    Console.WriteLine("Hello!");
                    return;
            }
            
        }
    }
}
