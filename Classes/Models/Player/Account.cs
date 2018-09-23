using GTANetworkAPI;
using Mirror.Levels;
using Mirror.Classes.Static;
using Skillsheet = Mirror.Skills.Skills;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Encryption = BCrypt;
using Mirror.Classes;
using Mirror.Events;
using Mirror.Globals;
using Mirror.Handler;
using Mirror.Classes.Models.Player;

namespace Mirror.Classes.Models
{
    public class Account : LiteDbData
    {
        public static PlayerUpdateEvent PlayerUpdateEvent = new PlayerUpdateEvent();
        public static List<Account> LoggedInAccounts = new List<Account>();

        // The main account handle.
        public string Scatter { get; set; } = "";
        public string Name { get; set; } = "";

        // The extra data.
        public int Health { get; set; } = 100;
        public int Armor { get; set; } = 0;
        public bool IsDead { get; set; } = false;
        public bool Banned { get; set; } = false;
        public bool NewAccount { get; set; } = true;
        public double Money { get; set; } = 0;
        public string Inventory { get; set; } = "[]";
        public string LastPosition { get; set; } = JsonConvert.SerializeObject(new Vector3(Settings.Settings.SpawnX, Settings.Settings.SpawnY, Settings.Settings.SpawnZ));
        public int CurrentExperience { get; set; } = 200;
        public string LevelRanks { get; set; } = JsonConvert.SerializeObject(new LevelRanks());
        public string LevelSkills { get; set; } = JsonConvert.SerializeObject(new Skillsheet());
        public string Weapons { get; set; } = "[]";

        public void Create(Client client, Scatter scatterHash)
        {
            string salt = Encryption.BCryptHelper.GenerateSalt();
            string hash = Encryption.BCryptHelper.HashPassword(scatterHash.Hash, salt);
            string scatterJsonHash;

            scatterHash.Hash = hash;
            scatterJsonHash = scatterHash.GetAsJSON();
            this.Scatter = scatterJsonHash;
            this.Name = $"{scatterHash.FirstName}_{scatterHash.LastName}";
            Database.Upsert(this);

            // Setup UserID with Database Insert ID.
            Account acc = Database.Get<Account>("Name", $"{scatterHash.FirstName}_{scatterHash.LastName}");
            acc.UserID = acc.ID;
            Database.UpdateData(acc);

            // Setup Clothing Data
            Clothing clothing = new Clothing();
            clothing.Create(acc.UserID);

            // Setup Appearance Data
            Appearance appearance = new Appearance();
            appearance.Create(acc.UserID);

            // Attach to the account to the player based on the new account instance.
            acc.Attach(client);
        }

        public void Attach(Client client)
        {
            Scatter scatter = GetScatter();

            // Basic Account
            client.SetData(EntityData.Account, this);
            client.Name = scatter.FirstName + "_" + scatter.LastName;
            client.Health = Health;
            client.Armor = Armor;

            Console.WriteLine($"{client.Name} has logged in.");

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
            AccountUtil.UpdateLevelSystemLocally(client);

            // Inventory
            InventoryHandler.SendInventoryLocally(client);

            // Reload existing weapons.
            AccountUtil.ReloadPlayerWeapons(client);

            if (IsDead)
            {
                IsDead = false;
                Health = 75;
                client.Health = 75;
            }

            // Finish
            FinishLogin(client);
        }

        private void FinishLogin(Client client)
        {
            AccountUtil.UpdatePlayerMoneyLocally(client);
            Utilities.FreezePlayerAccount(client, false);
            Utilities.DisablePlayerAccount(client, false);
            Utilities.LoginPlayerAccount(client, true);

            client.TriggerEvent("closeBrowser");
            
            client.Dimension = 0;
            client.Transparency = 255;

            /*

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
            Database.UpdateData(this);
            */
        }

        /// <summary>
        /// Update the account even if they're not online.
        /// </summary>
        public void OfflineUpdate() => Database.UpdateData(this);

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

            /*
            if (IsAccountLoggedIn())
                LoggedInAccounts.Remove(this);
            */
        }

        /*
        /// <summary>
        /// Compare the Account list and try to find a username that matches the player's.
        /// </summary>
        /// <returns></returns>
        public bool IsAccountLoggedIn()
        {
            //var result = LoggedInAccounts.Find(x => x.Username == Username);
            return result == null ? false : true;
        }
        */

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
            client.SetSharedData(EntitySharedData.IsPlayerDowned, false);

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

        /// <summary>
        /// Get the Scatter class from the json string.
        /// </summary>
        /// <returns></returns>
        public Scatter GetScatter() => JsonConvert.DeserializeObject<Scatter>(Scatter);
    }
}
