using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events.ActualEvents
{
    public class DeathEvent
    {
        public delegate void DeathEventHandler(object source, Client client, Client killer);

        public event DeathEventHandler DeathEventTrigger;

        public void Trigger(Client client, Client killer)
        {
            TriggerDeathEvent(client, killer);
        }

        protected virtual void TriggerDeathEvent(Client client, Client killer)
        {
            DeathEventTrigger?.Invoke(this, client, killer);
        }
    }
}
