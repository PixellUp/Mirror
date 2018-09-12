using GTANetworkAPI;
using Mirror.Classes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public class PlayerUpdateEvent
    {
        public delegate void PlayerUpdateEventHandler(object source, Client client, Account account);

        public event PlayerUpdateEventHandler PlayerUpdateTrigger;

        public void Trigger(Client client, Account account)
        {
            TriggerUpdateEvent(client, account);
        }

        protected virtual void TriggerUpdateEvent(Client client, Account account)
        {
            PlayerUpdateTrigger?.Invoke(this, client, account);
        }
    }
}
