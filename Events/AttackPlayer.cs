using GTANetworkAPI;
using Mirror.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mirror.Events
{
    public static class AttackPlayer
    {
        public static void Event(Client client, params object[] arguments)
        {
            Client target = arguments[1] as Client;

            if (client.Position.DistanceTo2D(target.Position) > 5)
                return;

            if (target.IsInVehicle)
                return;

            Account acc = Account.RetrieveAccount(client);
            acc.isAttacking = true;

            if (Talent.Skillcheck.CheckStrAgainstOpponent(client, target))
            {
                target.SendChatMessage($"You were attacked by {client.Name} and he hit you.");
                client.SendChatMessage($"You attacked {target.Name} and hit him.");
                target.Health -= 5;
            }
        }
    }
}
