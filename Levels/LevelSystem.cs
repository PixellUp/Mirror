using GTANetworkAPI;
using Mirror.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
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
        public int Downer { get; set; } = 0;

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
        public int Deadeye { get; set; } = 0;
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

        /// <summary>
        /// Allocates a skill point if they player has skill points available.
        /// </summary>
        /// <param name="currentXP"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool AllocateSkillPoint(int currentXP, string type)
        {
            int pointsAvailable = GetUnallocatedRankPointCount(currentXP);

            if (pointsAvailable <= 0)
                return false;

            foreach (var property in GetType().GetProperties())
            {
                if (property.Name.ToLower().Contains(type.ToLower()))
                {
                    int currentValue = Convert.ToInt32(property.GetValue(this, null));
                    currentValue += 1;
                    property.SetValue(this, currentValue);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check if the LevelRank exists in the class.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool DoesLevelRankExist(string type)
        {
            foreach (var property in GetType().GetProperties())
            {
                if (property.Name.ToLower() == type.ToLower())
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Get the total number of skill points this player has allocated.
        /// </summary>
        /// <returns></returns>
        public int GetRankPointsAllocated()
        {
            int total = 0;

            foreach (var property in GetType().GetProperties())
            {
                total += Convert.ToInt32(property.GetValue(this, null));
            }

            return total;
        }

        /// <summary>
        /// Calculate rankPoints points available to a player based on their current XP.
        /// </summary>
        /// <param name="currentXP"></param>
        /// <returns></returns>
        public int GetRankPointsAvailable(int currentXP)
        {
            int availablePoints = 0;
            int currentLevel = LevelSystem.GetCurrentLevel(currentXP);

            for (int i = 0; i < LevelSystem.Levels.Length; i++) {
                if (LevelSystem.Levels[i] == null)
                    continue;

                if (LevelSystem.Levels[i].Level == 0)
                    continue;

                if (LevelSystem.Levels[i].Level >= currentLevel)
                    break;

                if (LevelSystem.Levels[i].Level % 3 == 0)
                    availablePoints += 1;
            }

            return availablePoints;
        }

        /// <summary>
        /// Get the total amount of Unallocated rank points available to the player.
        /// </summary>
        /// <returns></returns>
        public int GetUnallocatedRankPointCount(int currentXP)
        {
            int totalPoints = GetRankPointsAvailable(currentXP);
            int totalAllocated = GetRankPointsAllocated();

            return totalPoints - totalAllocated;
        }

        /// <summary>
        /// Update the Level Ranks with this current version of the class.
        /// </summary>
        /// <param name="account"></param>
        public void UpdateLevelRanks(Client client) => AccountUtilities.UpdateLevelRanks(client, this);
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

        /// <summary>
        /// Setup the server with the levels available to players with their experience count.
        /// </summary>
        /// <param name="levelCap"></param>
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

        /// <summary>
        /// Get the next level for the player based on their current xp.
        /// </summary>
        /// <param name="currentXP"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get the last level's experienced based on their current xp.
        /// </summary>
        /// <param name="currentXP"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get the current level of the player based on their xp.
        /// </summary>
        /// <param name="currentXP"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get the current experienced based on the level.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
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
    }
}
