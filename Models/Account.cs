using GTANetworkAPI;
using LiteDbWrapper;
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

namespace Mirror.Models
{
    public class Account : StandardData
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Age { get; set; } = 20;
        public bool Banned { get; set; } = false;
        public bool IsLoggedIn { get; set; } = false;
        public bool NewAccount { get; set; } = true;
        public string Inventory { get; set; } = "";
        public string LastPosition { get; set; } = JsonConvert.SerializeObject(new Vector3(Settings.Settings.SpawnX, Settings.Settings.SpawnY, Settings.Settings.SpawnZ));
        public int CurrentExperience { get; set; } = 75;
        // Ranks
        public string LevelRanks { get; set; } = JsonConvert.SerializeObject(new LevelRanks());
        // Skills
        public string LevelSkills { get; set; } = JsonConvert.SerializeObject(new Skills.Skills());

        public void Create(Client client, string username, string playerName, string password)
        {
            string salt = Encryption.BCryptHelper.GenerateSalt();
            string hash = Encryption.BCryptHelper.HashPassword(password, salt);

            Username = username;
            Name = playerName;
            Password = hash;
            Database.Upsert(this);

            // Setup UserID with Database Insert ID.
            Account acc = Database.Get<Account>("Username", username);
            acc.UserID = acc.ID;
            Database.UpdateData(acc);

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
            // Basic Account
            IsLoggedIn = true;
            client.SetData("Mirror_Account", this);
            client.Name = Name;

            Vector3 position = JsonConvert.DeserializeObject<Vector3>(LastPosition);
            NAPI.Entity.SetEntityPosition(client, position);

            Update(client);

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
            LevelSystem.UpdatePlayerExperienceLocally(client);

            // Finish
            FinishLogin(client);
        }

        public void ResetLogin()
        {
            IsLoggedIn = false;
            Update();
        }

        private void FinishLogin(Client client)
        {
            client.TriggerEvent("eventFreeze", client.Handle, false);
            client.TriggerEvent("eventDisable", false);
            client.TriggerEvent("eventLoggedIn", true);
            client.Dimension = 0;
            client.Transparency = 255;

            if (!NewAccount)
                return;

            Task task = new Task(() =>
            {
                client.SendChatMessage("Please wait... setting up appearance menu for your new account.");
                System.Threading.Thread.Sleep(2000);
                client.TriggerEvent("OpenFacialMenu");
            });
            task.Start();
            
            NewAccount = false;
            Database.UpdateData(this);
        }

        /// <summary>
        /// Fully updates the database with new information.
        /// </summary>
        public void Update(Client client)
        {
            // Save the player's last position.
            LastPosition = JsonConvert.SerializeObject(client.Position); 

            Clothing clothing = Database.GetById<Clothing>(UserID);
            clothing.Update();

            Appearance appearance = Database.GetById<Appearance>(UserID);
            appearance.Update();

            Database.UpdateData(this);
        }

        public void Update()
        {
            Clothing clothing = Database.GetById<Clothing>(UserID);
            clothing.Update();

            Appearance appearance = Database.GetById<Appearance>(UserID);
            appearance.Update();

            Database.UpdateData(this);
        }

        public static Account RetrieveAccount(string username)
        {
            Account acc = Database.Get<Account>("Username", username);
            return acc;
        }

        public static bool CompareAccountPassword(string username, string password)
        {
            bool passwordCorrect = Encryption.BCryptHelper.CheckPassword(password, Database.Get<Account>("Username", username).Password);
            return passwordCorrect;
        }


        public LevelRanks GetLevelRanks()
        {
            return JsonConvert.DeserializeObject<LevelRanks>(LevelRanks);
        }

        public void UpdateLevelRanks(LevelRanks levelRanks)
        {
            LevelRanks = JsonConvert.SerializeObject(levelRanks);
            Update();
        }

    }
}
