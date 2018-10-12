using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes.Models.Player
{
    public class TopOutfit
    {
        public int[] Mask { get; set; } = new int[] { 0, 0 };
        public int[] Undershirt { get; set; } = new int[] { 0, 0 };
        public int[] Torso { get; set; } = new int[] { 0, 0 };
        public int[] Top { get; set; } = new int[] { 0, 0 };
        public int[] Hats { get; set; } = new int[] { 255, 0 };
        public int[] Glasses { get; set; } = new int[] { 255, 0 };

        public void Equip(Clothing clothing)
        {
            clothing.Mask = Mask;
            clothing.Undershirt = Undershirt;
            clothing.Torso = Torso;
            clothing.Top = Top;
            clothing.Hats = Hats;
            clothing.Glasses = Glasses;
        }
    }
}
