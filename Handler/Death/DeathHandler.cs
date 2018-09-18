using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Mirror.Levels;
using Mirror.Classes.Static;
using Mirror.Classes.Models;
using Mirror.Events;

namespace Mirror.Handler
{
    public class DeathHandler : Script
    {
        [Flags]
        public enum AnimationFlags
        {
            Loop = 1 << 0,
            StopOnLastFrame = 1 << 1,
            OnlyAnimateUpperBody = 1 << 4,
            AllowPlayerControl = 1 << 5,
            Cancellable = 1 << 7
        }

        public static DeathEvent DeathEvent = new DeathEvent();

        public DeathHandler()
        {
            DeathEvent.DeathEventTrigger += HandleDeath;
        }

        private void HandleDeath(object source, Client client, Client killer)
        {
            NotifyPlayersOfDeath(client);
            AccountUtil.SetPlayerDeath(client, true);
            LevelRanks levelRanks = AccountUtil.GetLevelRanks(client);
            LevelRankCooldowns cooldowns = AccountUtil.GetCooldowns(client);
            DateTime timeOfDeath = AccountUtil.SetTimeOfDeath(client);

            int downerBonus = 0;

            if (levelRanks.Downer > 0 && cooldowns.IsDownerReady)
            {
                cooldowns.IsDownerReady = false;
                downerBonus = 5000 * levelRanks.Downer;
                client.SendChatMessage("~r~Downer ~w~You are using your extended downtime for dieing.");
            }

            NAPI.Task.Run(() =>
            {
                if (!AccountUtil.IsPlayerDead(client))
                    return;

                if (timeOfDeath != AccountUtil.GetTimeOfDeath(client))
                    return;

                AccountUtil.SetPlayerDeath(client, false);
            }, 30000 + downerBonus); // 30 Seconds + Bonus
        }

        private void NotifyPlayersOfDeath(Client client)
        {
            Client[] players = NAPI.Pools.GetAllPlayers().ToArray();

            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].Position.DistanceTo2D(client.Position) <= 50)
                    players[i].TriggerEvent("eventForceRagdoll", client.Handle, 20000);
            }
        }
    }
}
