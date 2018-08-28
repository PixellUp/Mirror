using GTANetworkAPI;
using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Levels
{
    public class LevelRanks
    {
        // STR
        public int HeavyVehicles { get; set; } = 0;
        public int HeavyWeaponry { get; set; } = 0;
        public int Brute { get; set; } = 0;
        public int Fisticuffs { get; set; } = 0;
        public int Smash { get; set; } = 0;
        public int Intimidate { get; set; } = 0;
        public int Drag { get; set; } = 0;

        // INT
        public int MediumWeaponry { get; set; } = 0;
        public int Medicine { get; set; } = 0;
        public int CrowdControl { get; set; } = 0;
        public int Regenerate { get; set; } = 0;
        public int Lockpick { get; set; } = 0;
        public int VehicleSense { get; set; } = 0;
        public int Electric { get; set; } = 0;
        public int SickSense { get; set; } = 0;
        public int Calculated { get; set; } = 0;

        // Endurance
        public int LightWeaponry { get; set; } = 0;
        public int FlyingVehicles { get; set; } = 0;
        public int SuperclassVehicles { get; set; } = 0;
        public int Deadye { get; set; } = 0;
        public int Quick { get; set; } = 0;
        public int HighJump { get; set; } = 0;
        public int Perception { get; set; } = 0;
        public int Concentrate { get; set; } = 0;

        // Charisma
        public int Disguise { get; set; } = 0;
        public int Agenda { get; set; } = 0;
        public int Leadership { get; set; } = 0;
        public int Persuasion { get; set; } = 0;
        public int Hidden { get; set; } = 0;
        public int Transparent { get; set; } = 0;
        public int Fakeout { get; set; } = 0;
        public int Brains { get; set; } = 0;
        public int Attention { get; set; } = 0;
    }

    public class LevelInfo
    {
        public int Level { get; set; } = 0;
        public int TotalExperience { get; set; } = 0;

        public bool DoesExperienceMeetRequirement(int experience)
        {
            if (experience > TotalExperience)
                return true;
            return false;
        }
    }

    public static class LevelSystem
    {
        public static LevelInfo[] Levels = new LevelInfo[0];

        public static void InitializeLevels(int levelCap)
        {
            Levels = new LevelInfo[levelCap + 1];

            double expPoints = 0;

            for (int i = 0; i < levelCap; i++)
            {
                expPoints += Math.Floor(i + 300 * Math.Pow(2, i / 7));
                Levels[i] = new LevelInfo
                {
                    Level = i,
                    TotalExperience = Convert.ToInt32(expPoints / 4)
                };
            }
        }

        public static int GetNextLevelExperience(int currentXP)
        {
            for (int i = 0; i < Levels.Length; i++)
            {
                if (Levels[i] == null)
                    continue;

                if (Levels[i].TotalExperience >= currentXP)
                    return Levels[i].TotalExperience;
            }
            return 0;
        }

        public static int GetLastLevelExperience(int currentXP)
        {
            if (currentXP <= 100)
                return 0;

            for (int i = 0; i < Levels.Length; i++)
            {
                if (Levels[i] == null)
                    continue;

                if (Levels[i].TotalExperience >= currentXP)
                {
                    if (Levels[i - 1] == null)
                        return 0;

                    return Levels[i - 1].TotalExperience;
                }
            }
            return 0;
        }

        public static int GetCurrentLevel(int currentXP)
        {
            for (int i = 0; i < Levels.Length; i++)
            {
                if (Levels[i] == null)
                    continue;

                if (Levels[i].TotalExperience >= currentXP)
                    return Levels[i].Level;
            }
            return 0;
        }

        public static int GetExperienceAtLevel(int level)
        {
            for (int i = 0; i < Levels.Length; i++)
            {
                if (Levels[i] == null)
                    continue;

                if (Levels[i].Level == level)
                    return Levels[i].TotalExperience;
            }
            return 0;
        }

        public static void UpdatePlayerExperienceLocally(Client client)
        {
            if (!client.HasData("Mirror_Account"))
                return;

            if (!(client.GetData("Mirror_Account") is Account account))
                return;

            int currentXP = account.CurrentExperience;
            int lastXP = GetLastLevelExperience(currentXP);
            int nextLevelXP = GetNextLevelExperience(currentXP);
            int currentLvl = GetCurrentLevel(currentXP);

            client.TriggerEvent("UpdateExperienceHUD", lastXP, currentXP, nextLevelXP, currentLvl);
        }

        public static void AddPlayerExperience(Client client, int amount)
        {
            if (!client.HasData("Mirror_Account"))
                return;

            if (!(client.GetData("Mirror_Account") is Account account))
                return;

            account.CurrentExperience += amount;
            account.Update();

            UpdatePlayerExperienceLocally(client);
        }
    }
}
