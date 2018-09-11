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
    public class CrowdControl : Script
    {
        private readonly string VariableName = "IsCrowdControlReady";
        private readonly string Notification = "Notification";

        public CrowdControl()
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

            if (levelRanks.CrowdControl <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = AccountUtilities.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, VariableName, SkillCooldowns.CrowdControl);

            if (!levelRankCooldowns.IsCrowdControlReady)
            {
                client.SetData(VariableName + Notification, false);
                return;
            }

            if (client.GetData(VariableName + Notification))
                return;

            client.SetData(VariableName + Notification, true);
            client.SendChatMessage("~b~CrowdControl ~w~You are able to disable a person or vehicle temporarily again.");
        }
    }
}
