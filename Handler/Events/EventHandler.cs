using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Classes.Static.StaticEvents;

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
                    LoginEvents.Login(client, arguments);
                    return;
                case "Register":
                    LoginEvents.Register(client, arguments);
                    return;
                // Car Events
                case "ToggleEngine":
                    CarEvents.ToggleEngine(client, arguments);
                    return;
                case "ToggleLights":
                    CarEvents.ToggleLights(client, arguments);
                    return;
                case "OpenDoor":
                    CarEvents.OpenDoor(client, arguments);
                    return;
                case "CloseDoors":
                    CarEvents.CloseDoors(client, arguments);
                    return;
                case "PicklockVehicle":
                    CarEvents.PicklockDoor(client, arguments);
                    return;
                case "ToggleLock":
                    CarEvents.ToggleLock(client, arguments);
                    return;
                // Player Actions
                case "AttackPlayer":
                    PlayerEvents.AttackPlayer(client, arguments);
                    return;
                case "CancelAttack":
                    PlayerEvents.CancelAttack(client);
                    return;
                // Appearance Events
                case "PushAppearanceChanges":
                    AppearanceEvents.PushAppearanceChanges(client, arguments);
                    return;
                case "RequestFace":
                    AppearanceEvents.GetAppearance(client);
                    return;
                // Mission Events
                case "Mission_Framework_Verify":
                    VerifyMissionFramework.Event(client, arguments);
                    return;
                // Inventory Events
                case "Get_Inventory":
                    InventoryEvents.SyncInventory(client);
                    return;
                case "Drop_Item_Inventory":
                    InventoryEvents.DropItem(client, arguments);
                    return;
                case "Use_Item_Inventory":
                    InventoryEvents.UseItem(client, arguments);
                    return;
                case "Pickup_Item_Inventory":
                    InventoryEvents.PickupItem(client, arguments);
                    return;
                case "Unequip_Weapon":
                    InventoryEvents.UnequipWeapon(client);
                    return;
                case "Skilltree_Contribute_Point":
                    RankEvents.AllocateRankPoint(client, arguments);
                    return;
                // Job Events
                case "Start_Job":
                    JobEvents.StartJob(client, arguments);
                    return;
                // Skill Events
                case "Skill_Event":
                    SkillEvents.ParseSkillEvent(client, arguments);
                    return;
            }
            
        }
    }
}
