using Mirror.Classes.Models.Player;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes.Models
{
    public class InventoryItem
    {
        public int UniqueID { get; set; } = new Random().Next(0, 99999);
        public int ID { get; set; }
        public string Name { get; set; }
        public int StackCount { get; set; } = 1;
        public bool IsStackable { get; set; } = false;
        public string Properties { get; set; } = "[]";

        public void CreateTopOutfit(int[] mask, int[] undershirt, int[] torso, int[] top, int[] hats, int[] glasses)
        {
            TopOutfit topOutfit = new TopOutfit
            {
                Mask = mask,
                Undershirt = undershirt,
                Torso = torso,
                Top = top,
                Hats = hats,
                Glasses = glasses
            };

            Properties = JsonConvert.SerializeObject(topOutfit);
        }
    }
}
