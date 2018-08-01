using GTANetworkAPI;
using Mirror.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public static class StopAttacking
    {
        public static void Event(Client client)
        {
            Account account = Account.RetrieveAccount(client);

            if (account == null)
                return;

            account.isAttacking = false;
        }
    }
}
