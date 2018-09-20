using GTANetworkAPI;
using Mirror.Classes.Static;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Classes.Models;

namespace Mirror.Classes.Static.StaticEvents
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

            Console.WriteLine("HELLO!?");

            if (!AccountUtil.CompareAccountPassword(username, password))
            {
                client.TriggerEvent("Splash_Error_Handler", Exceptions.LoginAccountCredentialsInvalid);
                return;
            }

            Account account = AccountUtil.RetrieveAccountByUsername(username);

            if (account == null)
            {
                client.Kick(Exceptions.LoginNullException);
                return;
            }

            if (account.IsAccountLoggedIn())
            {
                client.TriggerEvent("Splash_Error_Handler", Exceptions.LoginAccountAlreadyLoggedIn);
                return;
            }

            if (account.Banned)
            {
                client.Kick(Exceptions.LoginAccountIsBanned);
                return;
            }

            

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

            string username = args[1].ToString().ToLower();
            string password = args[2].ToString();
            string characterName = args[3].ToString();

            if (username.Length < 5)
            {
                client.TriggerEvent("Splash_Error_Handler", "Username not long enough.");
                return;
            }

            if (!Utilities.IsNameRoleplayFormat(characterName))
            {
                client.TriggerEvent("Splash_Error_Handler", Exceptions.AccountPlayerNameIncorrectFormat);
                return;
            }

            if (Utilities.DoesFieldExistInAccounts("Name", characterName))
            {
                client.TriggerEvent("Splash_Error_Handler", Exceptions.AccountAlreadyExists);
                return;
            }

            if (Utilities.DoesFieldExistInAccounts("Username", username.ToLower()))
            {
                client.TriggerEvent("Splash_Error_Handler", Exceptions.AccountAlreadyExists);
                return;
            }

            if (password.Length < 5)
            {
                client.TriggerEvent("Splash_Error_Handler", Exceptions.AccountPasswordNotLongEnough);
                return;
            }

            client.TriggerEvent("Splash_Error_Handler", "Welcome to the server!");

            Account account = new Account();
            account.Create(client, username, characterName, password);

            ForceLogin(client, username);
        }

        public static void ForceLogin(Client client, string username)
        {
            Account account = AccountUtil.RetrieveAccountByUsername(username);

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

            // Attach the account to the player under the Dataset of EntityData.Account;
            account.Attach(client);
        }
    }
}
