using GTANetworkAPI;
using Encryption = BCrypt;
using System;
using System.Collections.Generic;
using System.Text;
using LiteDbWrapper;
using Mirror.Models;
using Mirror.Utility;

namespace Mirror.Commands
{
    public class Login : Script
    {
        [Command("login")]
        public void CmdLogin(Client client, string username, string password)
        {
            if (!Account.CompareAccountPassword(username, password))
            {
                client.SendChatMessage(Exceptions.LoginAccountCredentialsInvalid);
                return;
            }

            if (Utility.Utility.CheckIfLoggedIn(username))
            {
                client.SendChatMessage(Exceptions.LoginAccountAlreadyLoggedIn);
                return;
            }

            Account account = Account.RetrieveAccount(username);

            if (account == null)
            {
                client.Kick(Exceptions.LoginNullException);
                return;
            }

            if (account.Banned)
            {
                client.Kick(Exceptions.LoginAccountIsBanned);
                return;
            }

            client.SendChatMessage(Exceptions.LoginSuccess);
            // Attach the account to the player under the Dataset of "Mirror_Account";
            account.Attach(client);
        }
    }
}
