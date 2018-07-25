using GTANetworkAPI;
using LiteDbWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes
{
    public class Account : StandardData
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int Age { get; set; } = 0;
        public string Gender { get; set; } = "Male";
        public string Description { get; set; } = "";
        public bool Banned { get; set; } = false;
        public Clothing Clothing { get; set; }
        public Appearance Appearance { get; set; }

        public void SetupAccountData()
        {
            // User Account
            Account acc = Database.Get<Account>("Name", Name);
            acc.UserID = acc.ID;
            Database.UpdateData(acc);
            // Clothing
            Clothing = new Clothing
            {
                UserID = acc.ID
            };
            Database.Upsert(Clothing);
            // Appearance
            Appearance = new Appearance
            {
                UserID = acc.ID
            };
            Database.Upsert(Appearance);
        }

        public void LoadAccountData(Client client)
        {
            client.Name = Name;
            client.SetData("Account", this);

            if (Gender == "Female")
                client.SetSkin(PedHash.FreemodeFemale01);
            
            if (Gender == "Male")
                client.SetSkin(PedHash.FreemodeMale01);
        }
    }
}
