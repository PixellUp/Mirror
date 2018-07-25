using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes
{
    public class Clothing : StandardData
    {
        public int Mask { get; set; } = 0;
        public int MaskVariant { get; set; } = 0;
        public int Torso { get; set; } = 1;
        public int TorsoVariant { get; set; } = 0;
        public int Legs { get; set; } = 76;
        public int LegsVariant { get; set; } = 0;
        public int Bags { get; set; } = 0;
        public int Feet { get; set; } = 66;
        public int FeetVariant { get; set; } = 0;
        public int Accessories { get; set; } = 0;
        public int Undershirt { get; set; } = 15;
        public int UndershirtVariant { get; set; } = 0;
        public int BodyArmor { get; set; } = 0;
        public int BodyArmorVariant { get; set; } = 0;
        public int Top { get; set; } = 41;
        public int TopVariant { get; set; } = 0;

        public void LoadClothingData(Client client)
        {
            client.SetClothes(1, Mask, MaskVariant);
            client.SetClothes(3, Torso, TorsoVariant);
            client.SetClothes(4, Legs, LegsVariant);
            client.SetClothes(5, Bags, 0);
            client.SetClothes(6, Feet, FeetVariant);
            client.SetClothes(7, Accessories, 0);
            client.SetClothes(8, Undershirt, UndershirtVariant);
            client.SetClothes(9, BodyArmor, BodyArmorVariant);
            client.SetClothes(11, Top, TopVariant);
        }
    }
}
