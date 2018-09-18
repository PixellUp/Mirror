using GTANetworkAPI;
using Mirror.Classes.Models;
using Mirror.Globals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Handler
{
    public class DisconnectionHandler : Script
    {
        [ServerEvent(Event.PlayerDisconnected)]
        public void PlayerDisconnectEvent(Client client, DisconnectionType type, string reason)
        {
            if (!client.HasData(EntityData.Account))
                return;

            Account account = client.GetData(EntityData.Account);
            Account.PlayerUpdateEvent.Trigger(client, account);
        }
    }
}
