using GTANetworkAPI;
using Mirror.Models;
using Mirror.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public static class LoginEvents
    {
        public static void Login(Client client, params object[] args)
        {
            if (args[1] == null)
                return;

            if (args[2] == null)
                return;

            string username = args[1].ToString();
            string password = args[2].ToString();

            if (!AccountUtilities.CompareAccountPassword(username, password))
            {
                client.SendChatMessage(Exceptions.LoginAccountCredentialsInvalid);
                return;
            }

            Account account = AccountUtilities.RetrieveAccountByUsername(username);

            if (account == null)
            {
                client.Kick(Exceptions.LoginNullException);
                return;
            }

            if (account.IsAccountLoggedIn())
            {
                client.SendChatMessage(Exceptions.LoginAccountAlreadyLoggedIn);
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

        public static void Register(Client client, params object[] args)
        {
            if (args[1] == null)
                return;

            if (args[2] == null)
                return;

            if (args[3] == null)
                return;

            string username = args[1].ToString();
            string password = args[2].ToString();
            string characterName = args[3].ToString();

            if (username.Length <= 4)
            {
                client.SendChatMessage(Exceptions.AccountUsernameNotLongEnough);
                return;
            }

            if (!Utilities.IsNameRoleplayFormat(characterName))
            {
                client.SendChatMessage(Exceptions.AccountPlayerNameIncorrectFormat);
                return;
            }

            if (Utilities.DoesFieldExistInAccounts("Name", characterName))
            {
                client.SendChatMessage(Exceptions.AccountAlreadyExists);
                return;
            }

            if (Utilities.DoesFieldExistInAccounts("Username", username))
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
            account.Create(client, username, characterName, password);

            ForceLogin(client, username);
        }

        public static void ForceLogin(Client client, string username)
        {
            Account account = AccountUtilities.RetrieveAccountByUsername(username);

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
