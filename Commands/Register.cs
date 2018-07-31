using GTANetworkAPI;
using LiteDbWrapper;
using Mirror.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Encryption = BCrypt;

namespace Mirror.Commands
{
    public class Register : Script
    {
        [Command("register")]
        public void CmdRegister(Client client, string username, string password)
        {
            if (username.Length <= 4)
            {
                client.SendChatMessage("~r~ Username not long enough.");
                return;
            }

            if (!Utility.Utility.IsNameRoleplayFormat(username))
            {
                client.SendChatMessage("~r~ Name is in incorrect format.");
                return;
            }

            if (Utility.Utility.DoesUsernameExist(username))
            {
                client.SendChatMessage("~r~ Name already exists.");
                return;
            }

            if (password.Length <= 4)
            {
                client.SendChatMessage("~r~ Password not long enough.");
                return;
            }

            string salt = Encryption.BCryptHelper.GenerateSalt();
            string hash = Encryption.BCryptHelper.HashPassword(password, salt);

            Account account = new Account
            {
                Name = username,
                Password = hash
            };

            Database.Upsert(account); // Insert into Database.
            account.SetupAccountData(); // Insert New Clothing / Appearance Collections.
            client.SendChatMessage($"~g~ Your account has been registered. ~w~{username}");
        }
    }
}
