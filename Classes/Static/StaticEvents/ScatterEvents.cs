using BCrypt;
using GTANetworkAPI;
using Mirror.Classes.Models;
using Mirror.Classes.Models.Player;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes.Static.StaticEvents
{
    public static class ScatterEvents
    {   
        public static void HandleAccount(Client client, params object[] args)
        {
            if (args[1] == null)
                return;

            string json = args[1] as string;
            Scatter scatter = JsonConvert.DeserializeObject<Scatter>(json);

            if (!Utilities.DoesFieldExistInAccounts("Name", scatter.FirstName + "_" + scatter.LastName)) {
                Console.WriteLine("Registering new account.");
                RegisterAccount(client, scatter);
                return;
            }

            LoginAccount(client, scatter);
        }

        public static void LoginAccount(Client client, Scatter scatter)
        {
            Account account = Database.Get<Account>("Name", scatter.FirstName + "_" + scatter.LastName);

            if (!BCryptHelper.CheckPassword(scatter.Hash, account.GetScatter().Hash)) {
                return;
            }

            account.Attach(client);
        }

        public static void RegisterAccount(Client client, Scatter scatter)
        {
            Account account = new Account();
            account.Create(client, scatter);
        }
    }
}
