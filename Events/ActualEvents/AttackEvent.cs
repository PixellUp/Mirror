using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events.ActualEvents
{
    public class AttackEvent
    {
        public delegate void AttackEventHandler(object source, Client client);

        public event AttackEventHandler AttackEventTrigger;

        public void Trigger(Client client)
        {
            TriggerAttackEvent(client);
        }

        protected virtual void TriggerAttackEvent(Client client)
        {
            AttackEventTrigger?.Invoke(this, client);
        }
    }
}
