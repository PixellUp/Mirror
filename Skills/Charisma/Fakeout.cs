using GTANetworkAPI;
using Mirror.Events;
using Mirror.Levels;
using Mirror.Models;
using Mirror.Settings;
using System;
using System.Collections.Generic;
using System.Text;

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

            if (!(client.GetData("Mirror_Account") is Account account))
                return;

            LevelRanks levelRanks = account.GetLevelRanks();

            if (levelRanks.Fakeout <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = LevelRankCooldowns.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, VariableName, SkillCooldowns.Fakeout - (levelRanks.Fakeout * 5));

            if (!levelRankCooldowns.IsFakeoutReady)
            {
                client.SetData(VariableName + Notification, false);
                return;
            }

            if (client.GetData(VariableName + Notification))
                return;

            client.SetData(VariableName + Notification, true);
            client.SendNotification("~o~Fakeout~n~~w~You are able to skip an objective completely again.");
        }
    }
}
