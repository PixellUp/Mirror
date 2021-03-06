﻿using GTANetworkAPI;
using Mirror.Classes;
using Mirror.Classes.Models;
using Mirror.Classes.Static;
using Mirror.Utility;
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

            Clothing clothing = Database.GetById<Clothing>(account.UserID);
            clothing.Update();

            Appearance appearance = Database.GetById<Appearance>(account.UserID);
            appearance.Update();

            client.TriggerEvent("eventRecieveRanks", account.LevelRanks);
            client.TriggerEvent("eventUpdateCurrency", Convert.ToSingle(account.Money));

            Database.UpdateData(account);
        }
    }
}
