using System;
using System.Collections.Generic;
using System.Text;

using GTANetworkAPI;
using Dice = Mirror.Skills.Utility;
using Mirror.Skills;
using Mirror.Globals;

namespace Mirror.Classes.Static.StaticEvents
{
    public static class PlayerEvents
    {
        /// <summary>
        /// Uses the interval client-side to make attacks on a player.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="arguments"></param>
        public static void AttackPlayer(Client client, params object[] args)
        {
            if (args[1] == null)
                return;

            Client target = args[1] as Client;
            client.SetData(EntityData.Attack, target);
        }

        public static void CancelAttack(Client client)
        {
            client.SetData(EntityData.Attack, null);
        }
    }
}
