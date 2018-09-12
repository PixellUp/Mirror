using GTANetworkAPI;
using Mirror.Classes.Models;
using Mirror.Levels;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Skills.Strength
{
    // Increased Melee Damage based on Points in Skillset.
    public static class Fisticuffs
    {
        // Returns Bonus Damage on use.
        public static int Event(Client client)
        {
            int bonusDamage = 0;

            if (!client.HasData("Mirror_Account"))
                return bonusDamage;

            if (!(client.GetData("Mirror_Account") is Account account))
                return bonusDamage;

            if (client.CurrentWeapon != WeaponHash.Unarmed)
                return bonusDamage;

            LevelRanks levelRanks = account.GetLevelRanks();
            bonusDamage = levelRanks.Fisticuffs;

            return bonusDamage;
        }
    }
}
