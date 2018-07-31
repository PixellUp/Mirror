using GTANetworkAPI;
using LiteDB = LiteDbWrapper;
using System;
using System.Collections.Generic;
using System.Text;
using Talent;
using System.Threading.Tasks;
using System.Threading;

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
        public TalentScoresheet TalentScoreSheet { get; set; }

        public void SetupAccountData()
        {
            // User Account
            Account acc = LiteDB.Database.Get<Account>("Name", Name);
            acc.UserID = acc.ID;
            LiteDB.Database.UpdateData(acc);
            // Clothing
            Clothing = new Clothing
            {
                UserID = acc.ID
            };
            LiteDB.Database.Upsert(Clothing);
            // Appearance
            Appearance = new Appearance
            {
                UserID = acc.ID
            };
            LiteDB.Database.Upsert(Appearance);
            // Talentsheet
            TalentScoreSheet = new TalentScoresheet
            {
                UserID = acc.ID
            };
            TalentScoreSheet.GenerateRandomScores();
            LiteDB.Database.Upsert(TalentScoreSheet);
        }

        public void LoadAccountData(Client client)
        {
            client.Name = Name;
            client.SetData("Account", this);

            if (Gender == "Female")
                client.SetSkin(PedHash.FreemodeFemale01);
            
            if (Gender == "Male")
                client.SetSkin(PedHash.FreemodeMale01);

            Appearance = LiteDB.Database.GetById<Appearance>(ID);
            var appTask = Task.Factory.StartNew(() =>
            {
                while (Appearance == null)
                {
                    Thread.Sleep(2000);
                }
                Appearance.LoadAppearanceData(client);
                client.SendChatMessage("Loaded Facial Features");
            });
            
            Clothing = LiteDB.Database.GetById<Clothing>(ID);
            var clothingTask = Task.Factory.StartNew(() =>
            {
                while (Clothing == null)
                {
                    Thread.Sleep(2000);
                }
                Clothing.LoadClothingData(client);
                client.SendChatMessage("Loaded Clothing");
            });

            TalentScoreSheet = LiteDB.Database.GetById<TalentScoresheet>(ID);
            var sheetTask = Task.Factory.StartNew(() =>
            {
                while (TalentScoreSheet == null)
                {
                    Thread.Sleep(2000);
                }
                TalentScoreSheet.AddSheetToPlayer(client);
                client.SendChatMessage("Loaded Talent Sheet");
            });
            
        }
    }
}
