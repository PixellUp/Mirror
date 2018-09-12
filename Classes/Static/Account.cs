﻿using Encryption = BCrypt;
using GTANetworkAPI;
using Mirror.Classes;
using Mirror.Levels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Classes.Models;

namespace Mirror.Classes.Static
{
    public static class AccountUtil
    {
        /// <summary>
        /// Retrieve an account by their Username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static Account RetrieveAccountByUsername(string username)
        {
            return Database.Get<Account>("Username", username);
        }

        /// <summary>
        /// Uses GetData to simply retrieve the account.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static Account RetrieveAccount(Client client)
        {
            return client.GetData("Mirror_Account") as Account;
        }

        /// <summary>
        /// Check if a password matches.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CompareAccountPassword(string username, string password)
        {
            bool passwordCorrect = Encryption.BCryptHelper.CheckPassword(password, Database.Get<Account>("Username", username).Password);
            return passwordCorrect;
        }

        /// <summary>
        /// Check if the player has account attached to them.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool IsAccountReady(Client client) => client.HasData("Mirror_Account") ? true : false;

        /// <summary>
        /// Updates the client's account.
        /// </summary>
        /// <param name="client"></param>
        public static void UpdateAccount(Client client) => Account.PlayerUpdateEvent.Trigger(client, (Account)RetrieveAccount(client));

        /// <summary>
        /// Update the player's account with a new serialized JSON string for LevelRanks.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="levelRanks"></param>
        public static void UpdateLevelRanks(Client client, LevelRanks levelRanks)
        {
            RetrieveAccount(client).LevelRanks = JsonConvert.SerializeObject(levelRanks);
            UpdateAccount(client);
            UpdateLevelSystemLocally(client);
        }

        /// <summary>
        /// Update the player's local game with the required information for the Level System.
        /// </summary>
        /// <param name="client"></param>
        public static void UpdateLevelSystemLocally(Client client)
        {
            Account account = RetrieveAccount(client);
            LevelRanks levelRanks = JsonConvert.DeserializeObject<LevelRanks>(account.LevelRanks);

            int currentXP = account.CurrentExperience;
            int unallocatedPoints = levelRanks.GetUnallocatedRankPointCount(currentXP);
            int lastXP = LevelSystem.GetLastLevelExperience(currentXP);
            int nextLevelXP = LevelSystem.GetNextLevelExperience(currentXP);
            int currentLvl = LevelSystem.GetCurrentLevel(currentXP);

            client.TriggerEvent("eventRecieveRanks", account.LevelRanks);
            client.TriggerEvent("UpdateExperienceHUD", lastXP, currentXP, nextLevelXP, currentLvl, unallocatedPoints);
        }

        /// <summary>
        /// Add Experience to a Player Account
        /// </summary>
        /// <param name="client"></param>
        /// <param name="amount"></param>
        public static void AddExperience(Client client, int amount)
        {
            RetrieveAccount(client).CurrentExperience += amount;
            UpdateAccount(client);
            UpdateLevelSystemLocally(client);
        }

        /// <summary>
        /// Updates the player's money on the local side.
        /// </summary>
        /// <param name="client"></param>
        public static void UpdatePlayerMoneyLocally(Client client)
        {
            double money = RetrieveAccount(client).Money;
            client.TriggerEvent("eventUpdateCurrency", Convert.ToSingle(money));
        }

        /// <summary>
        /// Set the player's account to the value in the boolean and update it.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="isDead"></param>
        public static void SetPlayerDeath(Client client, bool isDead)
        {
            Account account = RetrieveAccount(client);
            account.IsDead = isDead;

            if (isDead)
                client.SetData("Death_Time", DateTime.Now);

            if (!isDead)
            {
                Vector3 hospLoc = new Vector3(Settings.Settings.HospitalLocation.Item1, Settings.Settings.HospitalLocation.Item2, Settings.Settings.HospitalLocation.Item3);
                client.StopAnimation();
                account.Armor = 0;
                account.Health = 50;
                account.LastPosition = JsonConvert.SerializeObject(hospLoc);
                double taxAmount = account.TaxOnDeath();

                if (!client.Exists)
                {
                    account.OfflineUpdate();
                    return;
                }

                client.SendChatMessage($"~w~You paid ~r~${taxAmount} ~w~in hospital fees.");
                client.Position = hospLoc;
            }

            UpdateAccount(client);
        }

        /// <summary>
        /// Check if the player is currently dead.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool IsPlayerDead(Client client) => RetrieveAccount(client).IsDead;

        /// <summary>
        /// Get the time of death for the player.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static DateTime GetTimeOfDeath(Client client) => (DateTime)client.GetData("Death_Time");

        /// <summary>
        /// Get the client's level ranks.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static LevelRanks GetLevelRanks(Client client) => RetrieveAccount(client).GetLevelRanks();

        /// <summary>
        /// Get the player's cool downs
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static LevelRankCooldowns GetCooldowns(Client client)
        {
            if (!client.HasData("Mirror_LevelRank_Cooldowns"))
                client.SetData("Mirror_LevelRank_Cooldowns", new LevelRankCooldowns());

            return client.GetData("Mirror_LevelRank_Cooldowns") as LevelRankCooldowns;
        }

        /// <summary>
        /// Get all of the client's items.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static InventoryItem[] GetPlayerItems(Client client) => RetrieveAccount(client).GetAllItems();
    }
}
