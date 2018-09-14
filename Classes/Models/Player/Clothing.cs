using GTANetworkAPI;
using Mirror.Classes.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes.Models
{
    public class Clothing : LiteDbData
    {
        // Type, Variant
        public int[] Mask { get; set; } = new int[] { 0, 0 };
        public int[] Torso { get; set; } = new int[] { 0, 0 };
        public int[] Legs { get; set; } = new int[] { 76, 0 };
        public int[] Bags { get; set; } = new int[] { 255, 0 };
        public int[] Feet { get; set; } = new int[] { 0, 0 };
        public int[] Accesssories { get; set; } = new int[] { 255, 0 };
        public int[] Undershirt { get; set; } = new int[] { 0, 0 };
        public int[] BodyArmor { get; set; } = new int[] { 255, 0 };
        public int[] Top { get; set; } = new int[] { 0, 0 };
        public int[] Hats { get; set; } = new int[] { 255, 0 };
        public int[] Glasses { get; set; } = new int[] { 255, 0 };
        public int[] Ears { get; set; } = new int[] { 255, 0 };
        public int[] Watch { get; set; } = new int[] { 255, 0 };
        public int[] Bracelet { get; set; } = new int[] { 255, 0 };

        public void Create(int id)
        {
            UserID = id;
            Database.Upsert(this);
        }

        public void Attach(Client client)
        {
            UpdateClothing(client);
        }

        public void Update()
        {
            Database.UpdateData(this);
        }

        /// <summary>
        /// Update the player's clothing with what is available in the class.
        /// </summary>
        /// <param name="client"></param>
        public void UpdateClothing(Client client)
        {
            client.SetData("Mirror_Clothing", this);

            int[] skip = new int[]{ };

            // Skip: 0, 2, 10
            int[][] clothing = new int[][] { skip, Mask, skip, Torso, Legs, Bags, Feet, Accesssories, Undershirt, BodyArmor, skip, Top };
            for (int i = 0; i < clothing.Length; i++)
            {
                if (i == 0 || i == 2 || i == 10)
                {
                    continue;
                }

                client.SetClothes(i, clothing[i][0], clothing[i][1]);
            }

            // Skip: 3, 4, 5
            int[][] accessories = new int[][] { Hats, Glasses, Ears, skip, skip, skip, Watch, Bracelet };
            for (int i = 0; i < accessories.Length; i++)
            {
                if (i == 3 || i == 4 || i == 5)
                    continue;

                client.SetAccessories(i, accessories[i][0], accessories[i][1]);
            }


            string clothingJson = JsonConvert.SerializeObject(this);
            client.SetSharedData("Mirror_Clothing_JSON", clothingJson);
        }

        /// <summary>
        /// Retrieve the player's clothing by UserID.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static Clothing RetrieveClothing(Account account)
        {
            return Database.GetById<Clothing>(account.UserID);
        }
    }
}
