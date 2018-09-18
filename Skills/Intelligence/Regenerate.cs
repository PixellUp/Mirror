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
using Mirror.Globals;

namespace Mirror.Skills.Intelligence
{
    // Requires : Script to hook into the event at runtime.
    public class Regenerate : Script
    {
        public Regenerate()
        {
            RankEvents.PassiveEvent.PassiveEventTrigger += CheckPassive;
        }

        private void CheckPassive(object source, Client client)
        {
            if (!(client.GetData(EntityData.Account) is Account account))
                return;

            LevelRanks levelRanks = account.GetLevelRanks();

            if (levelRanks.Regenerate <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = AccountUtil.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, "IsRegenerateReady", SkillCooldowns.Regenerate);

            if (!levelRankCooldowns.IsRegenerateReady)
                return;

            levelRankCooldowns.IsRegenerateReady = false;

            if (client.Health >= 95)
                return;

            client.SendNotification("~b~Regenerate ~w~You feel a bit healthier.");
            client.Health += levelRanks.Regenerate;
        }
    }
}
