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

namespace Mirror.Skills.Charisma
{
    public class Fakeout : Script
    {
        private readonly string VariableName = "IsFakeoutReady";
        private readonly string Notification = "Notification";

        public Fakeout()
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

            if (levelRanks.Fakeout <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = AccountUtil.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, VariableName, SkillCooldowns.Fakeout - (levelRanks.Fakeout * 5));

            if (!levelRankCooldowns.IsFakeoutReady)
            {
                client.SetData(VariableName + Notification, false);
                return;
            }

            if (client.GetData(VariableName + Notification))
                return;

            client.SetData(VariableName + Notification, true);
            client.SendChatMessage("~o~Fakeout ~w~You are able to skip an objective completely again.");
        }
    }
}
