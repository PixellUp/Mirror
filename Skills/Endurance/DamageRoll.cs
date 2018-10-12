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
using System.Threading.Tasks;
using Mirror.Utility;

namespace Mirror.Skills.Endurance
{
    public class DamageRoll : Script
    {
        private readonly string VariableName = "IsDamageRollReady";
        private readonly string Notification = "Notification";

        public DamageRoll()
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

            if (levelRanks.DamageRoll <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = AccountUtil.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, VariableName, SkillCooldowns.HighJump);

            if (!levelRankCooldowns.IsDamageRollReady)
            {
                client.SetData(VariableName + Notification, false);
                return;
            }

            if (client.GetData(VariableName + Notification))
                return;

            client.SetData(VariableName + Notification, true);
            client.SendNotification("~g~Damage Roll ~w~Your next hit will have a higher damage roll.");
        }

        public static int Use(Client client)
        {
            int damageRollBonus = 0;

            if (!client.Exists)
                return damageRollBonus;

            LevelRankCooldowns cooldowns = AccountUtil.GetCooldowns(client);
            LevelRanks ranks = AccountUtil.GetLevelRanks(client);

            if (ranks.DamageRoll <= 0)
                return damageRollBonus;

            if (!cooldowns.IsDamageRollReady)
                return damageRollBonus;

            damageRollBonus = ranks.DamageRoll / 2;

            cooldowns.IsDamageRollReady = false;
            client.SendNotification("Your shot hit for a little more damage.");
            return damageRollBonus;
        }
    }
}
