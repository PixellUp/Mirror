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

            if (!(client.GetData(EntityData.Account) is Account account))
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

        public static void Use(Client client, Client target)
        {
            if (!target.Exists)
                return;

            LevelRankCooldowns cooldowns = AccountUtil.GetCooldowns(client);
            LevelRanks ranks = AccountUtil.GetLevelRanks(client);

            if (!cooldowns.IsIntimidateReady || ranks.Intimidate <= 0)
                return;

            if (client.Position.DistanceTo2D(target.Position) > 4)
                return;

            cooldowns.IsIntimidateReady = false;
            Utilities.ForcePlayerCower(target, ranks.Intimidate * 1000);
            client.SendChatMessage($"~r~Intimidate ~w~You look quite intimidating and ~o~{target.Name}~w~ has noticed.");
            target.SendChatMessage($"~r~Intimidate ~o~{client.Name} ~w~looks very intimidating you cower in fear.");
        }
    }
}
