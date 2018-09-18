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

namespace Mirror.Skills.Endurance
{
    public class Concentrate : Script
    {
        private readonly string VariableName = "IsConcentrateReady";
        private readonly string Notification = "Notification";

        public Concentrate()
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

            if (levelRanks.Concentrate <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = AccountUtil.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, VariableName, SkillCooldowns.Concentrate);

            if (!levelRankCooldowns.IsConcentrateReady)
            {
                client.SetData(VariableName + Notification, false);
                return;
            }

            if (client.GetData(VariableName + Notification))
                return;

            client.SetData(VariableName + Notification, true);
            client.SendNotification("~g~Concentrate ~w~Your next shot will do double damage.");
        }

        public static int Use(Client client, int number)
        {
            LevelRankCooldowns cooldowns = AccountUtil.GetCooldowns(client);
            LevelRanks ranks = AccountUtil.GetLevelRanks(client);

            if (!cooldowns.IsConcentrateReady || ranks.Concentrate <= 0)
                return number;

            cooldowns.IsConcentrateReady = false;
            client.SendNotification("Your shot hit for double damage.");
            return (number * 2);
        }
    }
}
