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
    // Increased Health
    public class Brute : Script
    {
        private readonly string VariableName = "IsBruteReady";
        private readonly string Notification = "Notification";

        public Brute()
        {
            RankEvents.PassiveEvent.PassiveEventTrigger += CheckPassive;
        }

        public void CheckPassive(object source, Client client)
        {
            if (!client.HasData(VariableName + Notification))
                client.SetData(VariableName + Notification, false);

            if (!(client.GetData("Mirror_Account") is Account account))
                return;

            LevelRanks levelRanks = account.GetLevelRanks();

            if (levelRanks.Brute <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = AccountUtil.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, VariableName, SkillCooldowns.Brute);

            if (!levelRankCooldowns.IsBruteReady)
            {
                client.SetData(VariableName + Notification, false);
                return;
            }

            levelRankCooldowns.IsBruteReady = false;

            if (client.Armor >= levelRanks.Brute)
                return;

            if (!client.GetData(VariableName + Notification))
            {
                client.SetData(VariableName + Notification, true);
                client.SendChatMessage("~r~Brute ~w~You feel your skin tighten.");
                client.Armor = levelRanks.Brute;
            }
        }
    }
}
