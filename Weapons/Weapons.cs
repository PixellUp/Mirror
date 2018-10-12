using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Globals;

namespace Mirror.Classes.Static
{
    public static class Weapons
    {
        /// <summary>
        /// Get the weapon tick based on the weapon name.
        /// </summary>
        /// <param name="weaponName"></param>
        /// <returns></returns>
        public static int GetWeaponTick(string weaponName)
        {
            int tick = 20;

            Type obj = typeof(WeaponTicksData);

            foreach (var property in obj.GetFields())
            {
                if (property.Name.ToLower() == weaponName.ToLower())
                    tick = Convert.ToInt32(property.GetValue(obj));
            }

            return tick;
        }

        /// <summary>
        /// Get the weapon range based on the weapon name.
        /// </summary>
        /// <param name="weaponName"></param>
        /// <returns></returns>
        public static int GetWeaponRange(string weaponName)
        {
            int range = 10;

            Type obj = typeof(WeaponRangeData);

            foreach (var property in obj.GetFields())
            {
                if (property.Name.ToLower() == weaponName.ToLower())
                    range = Convert.ToInt32(property.GetValue(obj));
            }

            return range;
        }

        /// <summary>
        /// Check if the weapon tick remainder is 1. Anything else returns false.
        /// </summary>
        /// <param name="weaponName"></param>
        /// <param name="currentTick"></param>
        /// <returns></returns>
        public static bool IsWeaponTickReady(string weaponName, int currentTick)
        {
            int weaponTick = GetWeaponTick(weaponName);

            if (currentTick % weaponTick == 1)
                return false;

            if (currentTick % weaponTick == 0)
                return true;

            return false;
        }

        /// <summary>
        /// Get the weapon damage base dice.
        /// </summary>
        /// <param name="weaponName"></param>
        /// <returns></returns>
        public static int GetWeaponDamageDie(string weaponName)
        {
            int weaponDice = 4;

            Type obj = typeof(WeaponDamageData);

            foreach (var property in obj.GetFields())
            {
                if (property.Name.ToLower() == weaponName.ToLower())
                    weaponDice = Convert.ToInt32(property.GetValue(obj));
            }

            return weaponDice;
        }

        /// <summary>
        /// Get the amount of times we roll the weapon base dice.
        /// </summary>
        /// <param name="weaponName"></param>
        /// <returns></returns>
        public static int GetWeaponRollCount(string weaponName)
        {
            int weaponRollCount = 0;

            Type obj = typeof(WeaponShotsData);

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
