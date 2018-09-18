using GTANetworkAPI;
using Mirror.Events;
using Mirror.Levels;

using Mirror.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Classes.Static;
using Mirror.Classes.Models;
using Mirror.Classes.Static.StaticEvents;
using Mirror.Globals;

namespace Mirror.Skills.Strength
{
    public class Smash : Script
    {
        private readonly string VariableName = "IsSmashReady";
        private readonly string Notification = "Notification";

        public Smash()
        {
            RankEvents.PassiveEvent.PassiveEventTrigger += CheckPassive;
        }

        private void CheckPassive(object source, Client client)
        {
            if (!client.HasData(VariableName + Notification))
                client.SetData(VariableName + Notification, false);

            if (!(client.GetData(EntityData.Account) is Account account))
                return;

            LevelRanks levelRanks = account.GetLevelRanks();

            if (levelRanks.Smash <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = AccountUtil.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, VariableName, SkillCooldowns.Smash - (levelRanks.Smash * 7));

            if (!levelRankCooldowns.IsSmashReady)
            {
                client.SetData(VariableName + Notification, false);
                return;
            }

            if (client.GetData(VariableName + Notification))
                return;

            client.SetData(VariableName + Notification, true);
            client.SendChatMessage("~r~Smash ~w~You're able to break a window again.");
        }

        public static void Use(Client client, Vehicle vehicle)
        {
            if (!vehicle.Exists)
                return;

            LevelRankCooldowns cooldowns = AccountUtil.GetCooldowns(client);
            LevelRanks ranks = AccountUtil.GetLevelRanks(client);

            if (!cooldowns.IsSmashReady || ranks.Smash <= 0)
                return;

            if (client.Position.DistanceTo2D(vehicle.Position) > 2.5)
                return;

            if (!vehicle.Locked)
                return;

            cooldowns.IsSmashReady = false;

            bool didPlayerSucceed = Skillcheck.SkillCheckPlayer(client, Skillcheck.Skills.strength, new Random().Next(15, 28), clientModifier: ranks.Smash, impact: -1);

            if (!didPlayerSucceed)
            {
                client.SendNotification("You try to smash the vehicle window but end up hurting your fist.");
                return;
            }

            vehicle.Locked = false;
            client.SendNotification("You successfully smash the vehicle window.");
            Utilities.BreakVehicleWindow(client, vehicle);
        }
    }
}
