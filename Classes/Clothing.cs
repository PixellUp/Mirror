using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes
{
    public class Clothing : StandardData
    {
        public int Mask { get; set; } = 0;
        public int MaskVariant { get; set; } = 0;
        public int Torso { get; set; } = 0;
        public int TorsoVariant { get; set; } = 0;
        public int Legs { get; set; } = 0;
        public int LegsVariant { get; set; } = 0;
        public int Bags { get; set; } = 0;
        public int Feet { get; set; } = 0;
        public int FeetVariant { get; set; } = 0;
        public int Accessories { get; set; } = 0;
        public int Undershirt { get; set; } = 0;
        public int UndershirtVariant { get; set; } = 0;
        public int BodyArmor { get; set; } = 0;
        public int BodyArmorVariant { get; set; } = 0;
        public int Top { get; set; } = 0;
        public int TopVariant { get; set; } = 0;
    }
}
