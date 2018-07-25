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
            bool passwordCorrect = Encryption.BCryptHelper.CheckPassword(password, Database.Get<Account>("Name", username).Password);

            if (!passwordCorrect)
            {
                client.SendChatMessage("~r~Incorrect Password.");
                return;
            }

            client.SendChatMessage($"~g~ Welcome ~w~{username}, ~g~loading account details...");
            LoadAccount(client, username);
        }

        private void LoadAccount(Client client, string username)
        {
            Account acc = Database.Get<Account>("Name", username);
            acc.LoadAccountData(client);

            acc.Appearance = Database.GetById<Appearance>(acc.ID);
            acc.Appearance.LoadAppearanceData(client);

            acc.Clothing = Database.GetById<Clothing>(acc.ID);
            acc.Clothing.LoadClothingData(client);
        }
    }
}
