using GTANetworkAPI;
using Mirror.Events;
using Mirror.Levels;

using Mirror.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Classes.Static;
using Mirror.Classes.Models;
using Mirror.StaticEvents;
using Mirror.Globals;
using Mirror.Utility;

namespace Mirror.Skills.Endurance
{
    public class Quick : Script
    {
        private readonly string VariableName = "IsQuickReady";
        private readonly string Notification = "Notification";

        public Quick()
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

            if (levelRanks.Quick <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = AccountUtil.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, VariableName, SkillCooldowns.Quick);

            if (!levelRankCooldowns.IsQuickReady)
            {
                client.SetData(VariableName + Notification, false);
                return;
            }

            if (client.GetData(VariableName + Notification))
                return;

            client.SetData(VariableName + Notification, true);
            client.SendNotification("~g~Quick ~w~You have increased dodge chance for your next hit.");
        }

        public static int Use(Client client, int number)
        {
            LevelRankCooldowns cooldowns = AccountUtil.GetCooldowns(client);
            LevelRanks ranks = AccountUtil.GetLevelRanks(client);

            if (!cooldowns.IsQuickReady || ranks.Quick <= 0)
                return number;

            cooldowns.IsQuickReady = false;
            client.SendNotification("You used your increased dodge chance.");
            return number += ranks.Quick;
        }
    }
}
