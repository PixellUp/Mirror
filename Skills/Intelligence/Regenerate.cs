using GTANetworkAPI;
using Mirror.Events;
using Mirror.Events.ActualEvents;
using Mirror.Levels;
using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
            if (!(client.GetData("Mirror_Account") is Account account))
                return;

            LevelRanks levelRanks = account.GetLevelRanks();

            if (levelRanks.Regenerate <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = LevelRankCooldowns.GetCooldowns(client);

            if (!levelRankCooldowns.IsRegenerateReady)
            {
                levelRankCooldowns.UpdateCooldownTime(client, "IsRegenerateReady", 30);
                return;
            }

            if (client.Health >= 100)
                return;

            client.SendNotification("~r~Regenerate~n~~w~You feel a bit healthier.");
            client.Health += levelRanks.Regenerate;
        }
    }
}
