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

namespace Mirror.Skills.Strength
{
    public class Intimidate : Script
    {
        private readonly string VariableName = "IsIntimidateReady";
        private readonly string Notification = "Notification";

        public Intimidate()
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

            if (levelRanks.Intimidate <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = AccountUtil.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, VariableName, SkillCooldowns.Intimidate);

            if (!levelRankCooldowns.IsIntimidateReady)
            {
                client.SetData(VariableName + Notification, false);
                return;
            }

            if (client.GetData(VariableName + Notification))
                return;

            client.SetData(VariableName + Notification, true);
            client.SendChatMessage("~r~Intimidate ~w~You're able to intimidate others again.");
        }
    }
}
