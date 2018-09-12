using GTANetworkAPI;

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
            if (!client.HasData("Mirror_Account"))
                return;

            Account account = client.GetData("Mirror_Account");
            Account.PlayerUpdateEvent.Trigger(client, account);
        }
    }
}
