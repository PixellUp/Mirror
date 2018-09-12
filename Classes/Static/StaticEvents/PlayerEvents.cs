using System;
using System.Collections.Generic;
using System.Text;

using GTANetworkAPI;
using Dice = Mirror.Skills.Utility;
using Mirror.Skills;

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
            client.SetData("Mirror_Attack", target);






            /*
            if (client.Position.DistanceTo2D(target.Position) > 5)
                return;

            if (target.IsInVehicle)
                return;

            if (!client.HasData("LastAttack"))
                client.SetData("LastAttack", DateTime.UtcNow.Millisecond);

            if ((Int32)client.GetData("LastAttack") + 2500 > DateTime.UtcNow.Millisecond)
                return;

            client.SetData("LastAttack", DateTime.UtcNow.Millisecond);

            if (Skillcheck.SkillCheckPlayers(client, target, Skillcheck.Skills.strength))
            {
                int damage = Dice.RollDamage(10, 0);
                //target.SendChatMessage($"You were attacked by {client.Name} and he hit you.");
                target.TriggerEvent("eventLastDamage", damage);
                client.TriggerEvent("eventTargetDamage", damage);
                //client.SendChatMessage($"You attacked {target.Name} and hit him.");
                target.Health -= damage;
                return;
            }

            target.TriggerEvent("eventLastDamage", 0);
            client.TriggerEvent("eventTargetDamage", 0);
            */
        }

        public static void CancelAttack(Client client)
        {
            client.SetData("Mirror_Attack", null);
        }
    }
}
