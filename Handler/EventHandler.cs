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
                // Login System
                case "Login":
                    Events.LoginEvents.Login(client, arguments);
                    return;
                case "Register":
                    Events.LoginEvents.Register(client, arguments);
                    return;
                // Car Events
                case "ToggleEngine":
                    Events.CarEvents.ToggleEngine(client, arguments);
                    return;
                case "ToggleLights":
                    Events.CarEvents.ToggleLights(client, arguments);
                    return;
                case "OpenDoor":
                    Events.CarEvents.OpenDoor(client, arguments);
                    return;
                case "CloseDoors":
                    Events.CarEvents.CloseDoors(client, arguments);
                    return;
                case "PicklockVehicle":
                    Events.CarEvents.PicklockDoor(client, arguments);
                    return;
                case "ToggleLock":
                    Events.CarEvents.ToggleLock(client, arguments);
                    return;
                // Player Actions
                case "AttackPlayer":
                    Events.PlayerEvents.AttackPlayer(client, arguments);
                    return;
                case "CancelAttack":
                    Events.PlayerEvents.CancelAttack(client);
                    return;
                // Appearance Events
                case "PushAppearanceChanges":
                    Events.AppearanceEvents.PushAppearanceChanges(client, arguments);
                    return;
                case "RequestFace":
                    Events.AppearanceEvents.GetAppearance(client);
                    return;
                // Mission Events
                case "Mission_Framework_Verify":
                    Events.VerifyMissionFramework.Event(client, arguments);
                    return;
                // Inventory Events
                case "Get_Inventory":
                    Events.InventoryEvents.SyncInventory(client);
                    return;
                case "Drop_Item_Inventory":
                    Events.InventoryEvents.DropItem(client, arguments);
                    return;
                case "Use_Item_Inventory":
                    Events.InventoryEvents.UseItem(client, arguments);
                    return;
                case "Pickup_Item_Inventory":
                    Events.InventoryEvents.PickupItem(client, arguments);
                    return;
                case "Allocate_Rank_Point":
                    Events.RankEvents.AllocateRankPoint(client, arguments);
                    return;
                // Job Events
                case "Start_Job":
                    Events.JobEvents.StartJob(client, arguments);
                    return;
            }
            
        }
    }
}
