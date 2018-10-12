using Encryption = BCrypt;
using GTANetworkAPI;
using Mirror.Classes;
using Mirror.Levels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Classes.Models;
using Mirror.Globals;
using Mirror.Handler;

namespace Mirror.Utility
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
            return client.GetData(EntityData.Account) as Account;
        }

        /*
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
        */

        /// <summary>
        /// Check if the player has account attached to them.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool IsAccountReady(Client client) => client.HasData(EntityData.Account) ? true : false;

        /// <summary>
        /// Updates the client's account.
        /// </summary>
        /// <param name="client"></param>
        public static void UpdateAccount(Client client) => Account.PlayerUpdateEvent.Trigger(client, RetrieveAccount(client));

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
            {
                client.SetSharedData(EntitySharedData.IsPlayerDowned, true);
                DropAllWeapons(client);
            }
                
            if (!isDead)
            {
                Vector3 hospLoc = new Vector3(Settings.Settings.HospitalLocation.Item1, Settings.Settings.HospitalLocation.Item2, Settings.Settings.HospitalLocation.Item3);
                client.StopAnimation();
                account.Armor = 0;
                account.Health = 75;
                account.LastPosition = JsonConvert.SerializeObject(hospLoc);
                double taxAmount = account.TaxOnDeath();

                if (!client.Exists)
                {
                    account.OfflineUpdate();
                    return;
                }

                client.Health = 100;
                client.SetSharedData(EntitySharedData.IsPlayerDowned, false);
                client.SendChatMessage($"~w~You paid ~r~${taxAmount.ToString("N2")} ~w~in hospital fees.");
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
        public static DateTime GetTimeOfDeath(Client client)
        {
            if (!client.HasData(EntityData.DeathTime))
                client.SetData(EntityData.DeathTime, DateTime.Now);

            return client.GetData(EntityData.DeathTime);
        }

        /// <summary>
        /// Set the time of death for the player.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static DateTime SetTimeOfDeath(Client client)
        {
            DateTime timeOfDeath = DateTime.Now;
            client.SetData(EntityData.DeathTime, timeOfDeath);
            return timeOfDeath;
        }

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
            if (!client.HasData(EntityData.Cooldowns))
                client.SetData(EntityData.Cooldowns, new LevelRankCooldowns());

            return client.GetData(EntityData.Cooldowns) as LevelRankCooldowns;
        }

        /// <summary>
        /// Get all of the client's items.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static InventoryItem[] GetPlayerItems(Client client) => RetrieveAccount(client).GetAllItems();

        /// <summary>
        /// Give a player a weapon based on inventory usage. Duplicates won't get overwritten.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="hash"></param>
        public static bool AddPlayerWeapon(Client client, WeaponHash hash)
        {
            Account account = RetrieveAccount(client);

            List<WeaponHash> equipment = new List<WeaponHash>();

            if (account.Weapons != "")
                equipment = JsonConvert.DeserializeObject<List<WeaponHash>>(account.Weapons);

            if (equipment == null)
                return false;

            if (equipment.Contains(hash))
            {
                client.SendNotification("You already have that weapon equipped.");
                return false;
            }

            client.GiveWeapon(hash, 9999);
            equipment.Add(hash);
            account.Weapons = JsonConvert.SerializeObject(equipment);
            UpdateAccount(client);
            return true;
        }

        /// <summary>
        /// Remove a weapon from a player.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool RemovePlayerWeapon(Client client, WeaponHash hash)
        {
            Account account = RetrieveAccount(client);

            if (account.Weapons == "")
                return false;

            List<WeaponHash> equipment = JsonConvert.DeserializeObject<List<WeaponHash>>(account.Weapons);

            if (!equipment.Contains(hash))
                return false;

            equipment.Remove(hash);
            client.RemoveAllWeapons();

            foreach(WeaponHash existingItem in equipment)
                client.GiveWeapon(existingItem, 9999);

            account.Weapons = JsonConvert.SerializeObject(equipment);
            UpdateAccount(client);
            return true;
        }

        public static bool DoesPlayerHaveWeapon(Client client, WeaponHash hash)
        {
            Account account = RetrieveAccount(client);
            if (account.Weapons == "")
                return false;

            List<WeaponHash> equipment = JsonConvert.DeserializeObject<List<WeaponHash>>(account.Weapons);

            if (!equipment.Contains(hash))
                return false;

            return true;
        }

        /// <summary>
        /// Drop all player weapons. Mostly used by on death events.
        /// </summary>
        /// <param name="client"></param>
        public static void DropAllWeapons(Client client)
        {
            Account account = RetrieveAccount(client);

            if (account.Weapons == "")
                return;

            client.RemoveAllWeapons();
            List<WeaponHash> equipment = JsonConvert.DeserializeObject<List<WeaponHash>>(account.Weapons);
            account.Weapons = "";
            UpdateAccount(client);

            foreach (WeaponHash item in equipment)
            {
                InventoryHandler.AddDroppedItemToGround(client, new InventoryItem
                {
                    Name = item.ToString(),
                    StackCount = 1,
                    IsStackable = false
                });
            }
        }

        /// <summary>
        /// Reload the player's weapons from the account instance.
        /// </summary>
        /// <param name="client"></param>
        public static void ReloadPlayerWeapons(Client client)
        {
            Account account = RetrieveAccount(client);

            if (account.Weapons == "")
                return;

            List<WeaponHash> equipment = JsonConvert.DeserializeObject<List<WeaponHash>>(account.Weapons);

            foreach (WeaponHash existingItem in equipment)
                client.GiveWeapon(existingItem, 9999);
        }
    }
}
