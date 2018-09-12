using Mirror.Classes.Readonly;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes.Models
{
    public static class Weapons
    {
        public static int GetWeaponTick(string weaponName)
        {
            int tick = 20;

            Type obj = typeof(WeaponTicks);

            foreach (var property in obj.GetFields())
            {
                if (property.Name.ToLower() == weaponName.ToLower())
                    tick = Convert.ToInt32(property.GetValue(obj));
            }

            return tick;
        }

        public static int GetWeaponRange(string weaponName)
        {
            int range = 10;

            Type obj = typeof(WeaponRange);

            foreach (var property in obj.GetFields())
            {
                if (property.Name.ToLower() == weaponName.ToLower())
                    range = Convert.ToInt32(property.GetValue(obj));
            }

            return range;
        }

        public static bool IsWeaponTickReady(string weaponName, int currentTick)
        {
            int weaponTick = GetWeaponTick(weaponName);

            if (currentTick % weaponTick == 1)
                return false;

            if (currentTick % weaponTick == 0)
                return true;

            return false;
        }

        public static int GetWeaponDamageDie(string weaponName)
        {
            int weaponDice = 4;

            Type obj = typeof(WeaponDamage);

            foreach (var property in obj.GetFields())
            {
                if (property.Name.ToLower() == weaponName.ToLower())
                    weaponDice = Convert.ToInt32(property.GetValue(obj));
            }

            return weaponDice;
        }

        public static int GetWeaponRollCount(string weaponName)
        {
            int weaponRollCount = 0;

            Type obj = typeof(WeaponShots);

            foreach (var property in obj.GetFields())
            {
                if (property.Name.ToLower() == weaponName.ToLower())
                {
                    weaponRollCount = Convert.ToInt32(property.GetValue(obj));
                }
            }

            return weaponRollCount;
        }
    }
}
