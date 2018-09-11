using GTANetworkAPI;
using Mirror.Levels;
using Mirror.Utility;
using Skillsheet = Mirror.Skills.Skills;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Encryption = BCrypt;
using Mirror.Events.ActualEvents;
using Mirror.Database;

namespace Mirror.Models
{
    public class Account : StandardData
    {
        public static PlayerUpdateEvent PlayerUpdateEvent = new PlayerUpdateEvent();
        public static List<Account> LoggedInAccounts = new List<Account>();

        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Age { get; set; } = 20;
        public int Health { get; set; } = 100;
        public int Armor { get; set; } = 0;
        public bool IsDead { get; set; } = false;
        public bool Banned { get; set; } = false;
        public bool NewAccount { get; set; } = true;
        public double Money { get; set; } = 0;
        public string Inventory { get; set; } = "";
        public string LastPosition { get; set; } = JsonConvert.SerializeObject(new Vector3(Settings.Settings.SpawnX, Settings.Settings.SpawnY, Settings.Settings.SpawnZ));
        public int CurrentExperience { get; set; } = 200;
        public string LevelRanks { get; set; } = JsonConvert.SerializeObject(new LevelRanks());
        public string LevelSkills { get; set; } = JsonConvert.SerializeObject(new Skillsheet());

        public void Create(Client client, string username, string playerName, string password)
        {
            string salt = Encryption.BCryptHelper.GenerateSalt();
            string hash = Encryption.BCryptHelper.HashPassword(password, salt);

            Username = username;
            Name = playerName;
            Password = hash;
            DatabaseUtilities.Upsert(this);

            // Setup UserID with Database Insert ID.
            Account acc = DatabaseUtilities.Get<Account>("Username", username);
            acc.UserID = acc.ID;
            DatabaseUtilities.UpdateData(acc);

            // Setup Clothing Data
            Clothing clothing = new Clothing();
            clothing.Create(acc.UserID);

            // Setup Appearance Data
            Appearance appearance = new Appearance();
            appearance.Create(acc.UserID);

            // Fully Registered
            client.SendChatMessage(Exceptions.AccountHasBeenRegistered);
        }

        public void Attach(Client client)
        {
            Console.WriteLine($"{client.Name} has logged in.");

            // Basic Account
            client.SetData("Mirror_Account", this);
            client.Name = Name;
            client.Health = Health;
            client.Armor = Armor;
            
            // Set Position
            Vector3 position = JsonConvert.DeserializeObject<Vector3>(LastPosition);
            NAPI.Entity.SetEntityPosition(client, position);

            // Appearance
            Appearance appearance = Appearance.RetrieveAppearance(this);
            appearance.Attach(client);
            client.SendChatMessage(Exceptions.LoginLoadedAppearance);

            // Clothing
            Clothing clothing = Clothing.RetrieveClothing(this);
            clothing.Attach(client);
            client.SendChatMessage(Exceptions.LoginLoadedClothing);

            // Skills
            Skillsheet skills = JsonConvert.DeserializeObject<Skillsheet>(LevelSkills);
            skills.Attach(client);
            client.SendChatMessage(Exceptions.LoginLoadedSkills);

            // Levels
            AccountUtilities.UpdateLevelSystemLocally(client);

            // Finish
            FinishLogin(client);
        }

        private void FinishLogin(Client client)
        {
            AccountUtilities.UpdatePlayerMoneyLocally(client);
            Utilities.FreezePlayerAccount(client, false);
            Utilities.DisablePlayerAccount(client, false);
            Utilities.LoginPlayerAccount(client, true);
            
            client.Dimension = 0;
            client.Transparency = 255;

            if (!NewAccount)
                return;

            NewAccount = false;
            Utilities.FreezePlayerAccount(client, true);

            Task task = new Task(() =>
            {
                client.SendChatMessage("Please wait... setting up appearance menu for your new account.");
                System.Threading.Thread.Sleep(1000);
                client.TriggerEvent("OpenFacialMenu");
                
            });
            task.Start();

            Utilities.FreezePlayerAccount(client, false);
            DatabaseUtilities.UpdateData(this);
        }

        /// <summary>
        /// Update the account even if they're not online.
        /// </summary>
        public void OfflineUpdate() => DatabaseUtilities.UpdateData(this);

        /// <summary>
        /// Set to true to log in the account. Set to false to log the account out.
        /// </summary>
        /// <param name="value"></param>
        public void SetAccountLoggedIn(bool value = true)
        {
            if (!LoggedInAccounts.Contains(this))
                LoggedInAccounts.Add(this);

            if (value)
                return;

            if (IsAccountLoggedIn())
                LoggedInAccounts.Remove(this);
        }

        /// <summary>
        /// Compare the Account list and try to find a username that matches the player's.
        /// </summary>
        /// <returns></returns>
        public bool IsAccountLoggedIn()
        {
            var result = LoggedInAccounts.Find(x => x.Username == Username);
            return result == null ? false : true;
        }

        public double TaxOnDeath()
        {
            double taxedDifference = 0;
            taxedDifference = Money * 0.02;
            Money -= taxedDifference;
            return taxedDifference;
        }

        /// <summary>
        /// Get the current LevelRanks of a player.
        /// </summary>
        /// <returns></returns>
        public LevelRanks GetLevelRanks() => JsonConvert.DeserializeObject<LevelRanks>(LevelRanks);

        /// <summary>
        /// Revive the player and clear any forced animations from client-side.
        /// </summary>
        /// <param name="client"></param>
        public void SetPlayerRevived(Client client)
        {
            IsDead = false;
            client.TriggerEvent("eventForceRagdoll", client.Handle, -1);

            Client[] players = NAPI.Pools.GetAllPlayers().ToArray();

            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].Position.DistanceTo2D(client.Position) <= 50)
                    players[i].TriggerEvent("eventForceRagdoll", client.Handle, -1);
            }
        }

        /// <summary>
        /// Get all of the player's items as a list.
        /// </summary>
        /// <returns></returns>
        public InventoryItem[] GetAllItems() => JsonConvert.DeserializeObject<InventoryItem[]>(Inventory);
    }

    public static class AccountUtilities
    {
        /// <summary>
        /// Retrieve an account by their Username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static Account RetrieveAccountByUsername(string username)
        {
            return DatabaseUtilities.Get<Account>("Username", username);
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
            bool passwordCorrect = Encryption.BCryptHelper.CheckPassword(password, DatabaseUtilities.Get<Account>("Username", username).Password);
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
        /// Get the player's cooldowns
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
