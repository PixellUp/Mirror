using GTANetworkAPI;
using Mirror.Levels;
using Mirror.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Skills.Strength
{
    // Increased Melee Damage based on Points in Skillset.
    public static class Fisticuffs
    {
        public static int Event(Client client)
        {
            int bonusDamage = 0;

            if (!client.HasData("Mirror_Account"))
                return bonusDamage;

            if (!(client.GetData("Mirror_Account") is Account account))
                return bonusDamage;

            if (client.CurrentWeapon != WeaponHash.Unarmed)
                return bonusDamage;

            LevelRanks levelRanks = JsonConvert.DeserializeObject<LevelRanks>(account.LevelRanks);
            bonusDamage = levelRanks.Fisticuffs;

            return bonusDamage;
        }
    }
}
