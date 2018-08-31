using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events.ActualEvents
{
    public class JobEvent
    {
        public delegate void JobEventHandler(object source, Client client, string jobID);

        public event JobEventHandler JobEventTrigger;

        public void Trigger(Client client, string jobID)
        {
            TriggerPassiveEvent(client, jobID);
        }

        protected virtual void TriggerPassiveEvent(Client client, string jobID)
        {
            JobEventTrigger?.Invoke(this, client, jobID);
        }
    }
}
