using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public class AttackEvent
    {
        public delegate void AttackEventHandler(object source, Client client, Client target, string weaponName);

        public event AttackEventHandler AttackEventTrigger;

        public void Trigger(Client client, Client target, string weaponName)
        {
            TriggerAttackEvent(client, target, weaponName);
        }

        protected virtual void TriggerAttackEvent(Client client, Client target, string weaponName)
        {
            AttackEventTrigger?.Invoke(this, client, target, weaponName);
        }
    }
}
