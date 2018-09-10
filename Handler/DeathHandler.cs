using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Events.ActualEvents;
using Mirror.Models;
using Newtonsoft.Json;

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
            
            client.TriggerEvent("eventForceRagdoll", client.Handle, 20000);

            
            Client[] players = NAPI.Pools.GetAllPlayers().ToArray();

            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].Position.DistanceTo2D(client.Position) <= 50)
                    players[i].TriggerEvent("eventForceRagdoll", client.Handle, 20000);
            }

            Account account = client.GetData("Mirror_Account");
            account.IsDead = true;
            Account.PlayerUpdateEvent.Trigger(client, account);

            DateTime deathTime = DateTime.Now;
            client.SetData("Death_Time", deathTime);

            NAPI.Task.Run(() =>
            {
                if (!account.IsDead)
                    return;

                if (client.GetData("Death_Time") != deathTime)
                    return;

                client.StopAnimation();
                Vector3 hospLoc = new Vector3(360, -585, 28);
                account.Armor = 0;
                account.Health = 50;
                account.LastPosition = JsonConvert.SerializeObject(new Vector3(hospLoc.X, hospLoc.Y, hospLoc.Z));
                account.IsDead = false;
                double taxAmount = account.TaxOnDeath();
                account.OfflineUpdate();

                if (!client.Exists)
                    return;

                client.SendChatMessage($"~w~You paid ~r~${taxAmount} ~w~in hospital fees.");
                client.Position = hospLoc;
                Account.PlayerUpdateEvent.Trigger(client, account);
            }, 20000);
        }
    }
}
