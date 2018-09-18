using GTANetworkAPI;
using Mirror.Classes.Models;
using Mirror.Globals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Skills
{
    public class Skills
    {
        public int Endurance { get; set; } = 0;
        public int Intelligence { get; set; } = 0;
        public int Charisma { get; set; } = 0;
        public int Strength { get; set; } = 0;
        public int EnduranceModifier { get; set; } = 0;
        public int IntelligenceModifier { get; set; } = 0;
        public int CharismaModifier { get; set; } = 0;
        public int StrengthModifier { get; set; } = 0;

        public Skills()
        {
            GenerateRandomScores();
        }

        public void Attach(Client client)
        {
            client.SetData(EntityData.Skills, this);
            UpdateSkillsLocal(client);
        }

        /// <summary>
        /// Update the skills locally for the client provided.
        /// </summary>
        /// <param name="client"></param>
        public void UpdateSkillsLocal(Client client)
        {
            int str = GetScore(Strength, StrengthModifier);
            int end = GetScore(Endurance, EnduranceModifier);
            int intel = GetScore(Intelligence, IntelligenceModifier);
            int cha = GetScore(Charisma, CharismaModifier);
            client.TriggerEvent("eventLoadStats", str, end, intel, cha);
        }

        /// <summary>
        /// Randomly generate the player stats.
        /// </summary>
        public void GenerateRandomScores()
        {
            Endurance = Utility.GenerateModifier();
            Strength = Utility.GenerateModifier();
            Charisma = Utility.GenerateModifier();
            Intelligence = Utility.GenerateModifier();
        }

        /// <summary>
        /// Gets the score for any type of modifier combination.
        /// </summary>
        /// <param name="ability"></param>
        /// <param name="abilityModifier"></param>
        /// <returns></returns>
        public int GetScore(int ability, int abilityModifier)
        {
            return (ability / Settings.Settings.TalentDivision) + abilityModifier;
        }

        /// <summary>
        /// Resets the player's skill modifiers.
        /// </summary>
        /// <param name="client"></param>
        public void RestoreModifiers(Client client)
        {
            EnduranceModifier = 0;
            IntelligenceModifier = 0;
            CharismaModifier = 0;
            StrengthModifier = 0;
            UpdateSkillsLocal(client);
        }

        /// <summary>
        /// Updates the account with the current skillset.
        /// </summary>
        /// <param name="account"></param>
        public void Update(Client client)
        {
            if (!client.HasData(EntityData.Account))
                return;

            if (!(client.GetData(EntityData.Account) is Account account))
                return;

            UpdateSkillsLocal(client);

            string jsonString = JsonConvert.SerializeObject(this);
            account.LevelSkills = jsonString;
            Account.PlayerUpdateEvent.Trigger(client, account);
        }
    }

    public static class Utility
    {
        public readonly static Random Random = new Random();

        /// <summary>
        /// Returns a new modifier number that is correctly calculated.
        /// </summary>
        /// <returns></returns>
        public static int GenerateModifier()
        {
            int modifier = 0;

            for (var i = 0; i < 3; i++)
            {
                modifier += RollDice(6);
            }

            return modifier;
        }

        /// <summary>
        /// Returns a random number between 1 and the sides issued.
        /// </summary>
        /// <param name="sides"></param>
        /// <returns></returns>
        public static int RollDice(int sides = 20, int howManyTimes = 1)
        {
            int startAmount = 0;

            for (int i = 0; i < howManyTimes; i++)
            {
                startAmount += Random.Next(1, sides + 1);
            }

            return startAmount;
        }

        public static int RollDamage(int sides = 20, int modifier = 0)
        {
            return Random.Next(1, sides + 1) + modifier;
        }
    }
}
