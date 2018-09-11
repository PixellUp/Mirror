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
    public class Persuasion : Script
    {
        private readonly string VariableName = "IsPersuasionReady";
        private readonly string Notification = "Notification";

        public Persuasion()
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

            if (levelRanks.Persuasion <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = AccountUtilities.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, VariableName, SkillCooldowns.Persuasion);

            if (!levelRankCooldowns.IsPersuasionReady)
            {
                client.SetData(VariableName + Notification, false);
                return;
            }

            if (client.GetData(VariableName + Notification))
                return;

            client.SetData(VariableName + Notification, true);
            client.SendChatMessage("~o~Persuasion ~w~Next time someone questions you, you'll sound very persuasive.");
        }
    }
}
