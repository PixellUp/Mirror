using GTANetworkAPI;
using LiteDbWrapper;
using Mirror.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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

            // Setup Skill Sheet Data
            Skills skills = new Skills();
            skills.Create(acc.UserID);

            // Fully Registered
            client.SendChatMessage(Exceptions.AccountHasBeenRegistered);
        }

        public void Attach(Client client)
        {
            // Basic Account
            IsLoggedIn = true;
            client.SetData("Mirror_Account", this);
            client.Name = Name;
            Update();

            // Appearance
            Appearance appearance = Appearance.RetrieveAppearance(this);
            appearance.Attach(client);
            client.SendChatMessage(Exceptions.LoginLoadedAppearance);

            // Clothing
            Clothing clothing = Clothing.RetrieveClothing(this);
            clothing.Attach(client);
            client.SendChatMessage(Exceptions.LoginLoadedClothing);

            // Skills
            Skills skills = Skills.RetrieveSkills(this);
            skills.Attach(client);
            client.SendChatMessage(Exceptions.LoginLoadedSkills);

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
        }

        /// <summary>
        /// Fully updates the database with new information.
        /// </summary>
        public void Update()
        {
            Clothing clothing = Database.GetById<Clothing>(UserID);
            clothing.Update();

            Appearance appearance = Database.GetById<Appearance>(UserID);
            clothing.Update();

            Skills skills = Database.GetById<Skills>(UserID);
            clothing.Update();

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

    }
}
