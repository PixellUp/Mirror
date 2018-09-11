using GTANetworkAPI;
using Mirror.Events;
using Mirror.Levels;
using Mirror.Models;
using Mirror.Settings;
using System;
using System.Collections.Generic;
using System.Text;

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

            if (!(client.GetData("Mirror_Account") is Account account))
                return;

            LevelRanks levelRanks = account.GetLevelRanks();

            if (levelRanks.Concentrate <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = AccountUtilities.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, VariableName, SkillCooldowns.Concentrate);

            if (!levelRankCooldowns.IsConcentrateReady)
            {
                client.SetData(VariableName + Notification, false);
                return;
            }

            if (client.GetData(VariableName + Notification))
                return;

            client.SetData(VariableName + Notification, true);
            client.SendChatMessage("~g~Concentrate ~w~Your next shot will do double damage.");
        }
    }
}
