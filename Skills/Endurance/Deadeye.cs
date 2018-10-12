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
    public class Deadeye : Script
    {
        private readonly string VariableName = "IsDeadeyeReady";
        private readonly string Notification = "Notification";

        public Deadeye()
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

            if (levelRanks.Deadeye <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = AccountUtil.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, VariableName, SkillCooldowns.Deadeye);

            if (!levelRankCooldowns.IsDeadeyeReady)
            {
                client.SetData(VariableName + Notification, false);
                return;
            }

            if (client.GetData(VariableName + Notification))
                return;

            client.SetData(VariableName + Notification, true);
            client.SendNotification("~g~Deadeye ~w~You have increased accuracy on your next shot.");
        }

        public static bool Use(Client client)
        {
            LevelRankCooldowns cooldowns = AccountUtil.GetCooldowns(client);
            LevelRanks ranks = AccountUtil.GetLevelRanks(client);

            if (!cooldowns.IsDeadeyeReady || ranks.Deadeye <= 0)
                return false;

            cooldowns.IsDeadeyeReady = false;
            client.SendNotification("Your shot had increased accuracy.");
            return true;
        }
    }
}
