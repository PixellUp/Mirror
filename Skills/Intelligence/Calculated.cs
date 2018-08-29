using GTANetworkAPI;
using Mirror.Events;
using Mirror.Levels;
using Mirror.Models;
using Mirror.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Skills.Intelligence
{
    public class Calculated : Script
    {
        private readonly string VariableName = "IsCalculatedReady";
        private readonly string Notification = "Notification";

        public Calculated()
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

            if (levelRanks.Calculated <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = LevelRankCooldowns.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, VariableName, SkillCooldowns.Calculated);

            if (!levelRankCooldowns.IsCalculatedReady)
            {
                client.SetData(VariableName + Notification, false);
                return;
            }

            if (client.GetData(VariableName + Notification))
                return;

            client.SetData(VariableName + Notification, true);
            client.SendNotification("~b~Calculated~n~~w~First shot will hit with 100% accuracy.");
        }
    }
}
