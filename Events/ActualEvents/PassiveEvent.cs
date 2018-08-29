using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events.ActualEvents
{
    public class PassiveEvent
    {
        public delegate void PassiveEventHandler(object source, Client client);

        public event PassiveEventHandler PassiveEventTrigger;

        public void Trigger(Client client)
        {
            TriggerPassiveEvent(client);
        }

        protected virtual void TriggerPassiveEvent(Client client)
        {
            PassiveEventTrigger?.Invoke(this, client);
        }
    }
}
