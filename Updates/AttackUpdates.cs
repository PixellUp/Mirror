using GTANetworkAPI;
using Mirror.Events.ActualEvents;

using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Updates
{
    public class AttackUpdates : Script
    {
        public static AttackEvent AttackEvent = new AttackEvent();

        DateTime TickTime = DateTime.Now.AddMilliseconds(500); // 1/2 Second -> 0.5s
        readonly int Maxtick = 20; // 20s

        [ServerEvent(Event.Update)]
        public void UpdateAttack()
        {
            if (DateTime.Compare(DateTime.Now, TickTime) <= 0)
                return;

            TickTime = DateTime.Now.AddMilliseconds(500);

            Client[] players = NAPI.Pools.GetAllPlayers().ToArray();
            
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] == null)
                    continue;

                UpdatePlayerTicks(players[i]);
            }
        }

        /// <summary>
        /// Check if the player is reaches the tick threshold and reset it.
        /// </summary>
        /// <param name="client"></param>
        private void UpdatePlayerTicks(Client client)
        {
            if (client == null)
                return;

            if (!client.HasData("Tick"))
                client.SetData("Tick", 0);

            int currentTick = client.GetData("Tick");

            if (currentTick + 1 > Maxtick)
                currentTick = 1;

            client.SetData("Tick", currentTick + 1);

            if (!client.HasData("Mirror_Attack"))
                return;

            if (client.GetData("Mirror_Attack") == null)
                return;

            bool isAttackReady = Weapons.IsWeaponTickReady(client.CurrentWeapon.ToString(), currentTick);

            if (!isAttackReady)
                return;

            AttackEvent.Trigger(client, client.GetData("Mirror_Attack") as Client, client.CurrentWeapon.ToString());
        }
    }
}
