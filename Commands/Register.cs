using GTANetworkAPI;
using LiteDbWrapper;
using Mirror.Models;
using Mirror.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using Encryption = BCrypt;

namespace Mirror.Commands
{
    public class Register : Script
    {
        [Command("register", Description = "/register Username Player_Name Password")]
        public void CmdRegister(Client client, string username, string playerName, string password)
        {
            if (username == null)
                return;

            if (playerName == null)
                return;

            if (password == null)
                return;

            if (username.Length <= 4)
            {
                client.SendChatMessage(Exceptions.AccountUsernameNotLongEnough);
                return;
            }

            if (!Utility.Utility.IsNameRoleplayFormat(playerName))
            {
                client.SendChatMessage(Exceptions.AccountPlayerNameIncorrectFormat);
                return;
            }

            if (Utility.Utility.DoesFieldExistInAccounts("Name", playerName))
            {
                client.SendChatMessage(Exceptions.AccountAlreadyExists);
                return;
            }

            if (Utility.Utility.DoesFieldExistInAccounts("Username", username))
            {
                client.SendChatMessage(Exceptions.AccountAlreadyExists);
                return;
            }

            if (password.Length <= 6)
            {
                client.SendChatMessage(Exceptions.AccountPasswordNotLongEnough);
                return;
            }

            Account account = new Account();
            account.Create(client, username, playerName, password);

            // SETUP CLOTHING AFTER THIS
            //account.SetupAccountData(); // Insert New Clothing / Appearance Collections.
            
        }
    }
}
