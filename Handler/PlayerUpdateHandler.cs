using GTANetworkAPI;
using Mirror.Database;
using Mirror.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Handler
{
    public class PlayerUpdateHandler : Script
    {
        public PlayerUpdateHandler()
        {
            Account.PlayerUpdateEvent.PlayerUpdateTrigger += HandlePlayerUpdate;
        }

        private void HandlePlayerUpdate(object source, Client client, Account account)
        {
            // Save the player's last position.
            account.LastPosition = JsonConvert.SerializeObject(client.Position);
            account.Health = client.Health;
            account.Armor = client.Armor;

            Clothing clothing = DatabaseUtilities.GetById<Clothing>(account.UserID);
            clothing.Update();

            Appearance appearance = DatabaseUtilities.GetById<Appearance>(account.UserID);
            appearance.Update();

            client.TriggerEvent("eventRecieveRanks", account.LevelRanks);
            client.TriggerEvent("eventUpdateCurrency", Convert.ToSingle(account.Money));

            DatabaseUtilities.UpdateData(account);
        }
    }
}
