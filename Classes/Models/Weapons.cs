using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes.Models
{
    public static class WeaponTicks
    {
        public static readonly int Unarmed = 10; // 4s
        public static readonly int Pistol50 = 8; // 3s
        public static readonly int Smg = 4;
        public static readonly int HeavySniper = 19;
        public static readonly int MachinePistol = 2;
        public static readonly int DoubleAction = 6;
        public static readonly int PumpShotgun = 8;
        public static readonly int MG = 1;
        public static readonly int MicroSMG = 1;
    }

    public static class WeaponDice
    {
        public static readonly int Unarmed = 6;
        public static readonly int Pistol50 = 6;
        public static readonly int Smg = 4;
        public static readonly int HeavySniper = 40;
        public static readonly int MachinePistol = 2;
        public static readonly int DoubleAction = 10;
        public static readonly int PumpShotgun = 15;
        public static readonly int MG = 4;
        public static readonly int MicroSMG = 2;
    }

    public static class WeaponShotsFired
    {
        public static readonly int Unarmed = 0;
        public static readonly int Pistol50 = 0;
        public static readonly int Smg = 4;
        public static readonly int HeavySniper = 0;
        public static readonly int MachinePistol = 4;
        public static readonly int DoubleAction = 0;
        public static readonly int PumpShotgun = 2;
        public static readonly int MG = 2;
        public static readonly int MicroSMG = 3;
    }

    public static class WeaponRange
    {
        public static readonly int Unarmed = 5;
        public static readonly int Pistol50 = 15;
        public static readonly int Smg = 25;
        public static readonly int HeavySniper = 80;
        public static readonly int MachinePistol = 12;
        public static readonly int DoubleAction = 12;
        public static readonly int PumpShotgun = 20;
        public static readonly int MG = 25;
        public static readonly int MicroSMG = 10;
    }

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

            Type obj = typeof(WeaponDice);

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

            Type obj = typeof(WeaponShotsFired);

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
