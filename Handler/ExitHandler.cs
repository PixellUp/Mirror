using GTANetworkAPI;
using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Handler
{
    public class ExitHandler : Script
    {
        [ServerEvent(Event.PlayerDisconnected)]
        public void PlayerDisconnectEvent(Client client)
        {
            if (!client.HasData("Mirror_Account"))
                return;

            Account account = (Account)client.GetData("Mirror_Account");

            if (account == null)
                return;

            account.IsLoggedIn = false;
            account.Update();
        }
    }
}
