using GTANetworkAPI;
using Encryption = BCrypt;
using System;
using System.Collections.Generic;
using System.Text;
using LiteDbWrapper;
using Mirror.Classes;

namespace Mirror.Commands
{
    public class Login : Script
    {
        [Command("login")]
        public void CmdLogin(Client client, string username, string password)
        {
            if (client.HasData("LoggedIn"))
                return;

            if (Utility.Utility.CheckIfLoggedIn(username))
            {
                client.SendChatMessage("~r~That account is already logged in.");
                return;
            }

            bool passwordCorrect = Encryption.BCryptHelper.CheckPassword(password, Database.Get<Account>("Name", username).Password);

            if (!passwordCorrect)
            {
                client.SendChatMessage("~r~Incorrect Password.");
                return;
            }

            client.SendChatMessage($"~g~ Welcome ~w~{username}, ~g~loading account details...");
            client.SetData("Account", Database.Get<Account>("Name", username));
            client.SetData("LoggedIn", true);
        }
    }
}
