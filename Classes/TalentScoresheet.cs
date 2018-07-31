﻿using GTANetworkAPI;
using LiteDbWrapper;
using Mirror.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes
{
    public class TalentScoresheet : StandardData
    {
        public string Name { get; set; }
        public int Endurance { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        public int Strength { get; set; }
        public int EnduranceModifier { get; set; } = 0;
        public int IntelligenceModifier { get; set; } = 0;
        public int CharismaModifier { get; set; } = 0;
        public int StrengthModifier { get; set; } = 0;

        public TalentScoresheet() { }

        public void AddSheetToPlayer(Client client)
        {
            client.SetData("TalentScoresheet", this);
        }

        public void SaveNewScoresheet()
        {
            if (Database.Get<TalentScoresheet>("Name", Name) != null)
                UserID = Database.Get<TalentScoresheet>("Name", Name).UserID;

            GenerateRandomScores();

            Database.UpdateData(this);
        }

        public void GenerateRandomScores()
        {
            Endurance = Talent.CharacterGen.GenerateModifier();
            Strength = Talent.CharacterGen.GenerateModifier();
            Charisma = Talent.CharacterGen.GenerateModifier();
            Intelligence = Talent.CharacterGen.GenerateModifier();
        }

        /// <summary>
        /// Restore any negative or positive modifier impacts.
        /// </summary>
        public void RestoreModifiers()
        {
            EnduranceModifier = 0;
            IntelligenceModifier = 0;
            CharismaModifier = 0;
            StrengthModifier = 0;
        }

        /// <summary>
        /// Return the player's true endurance talent score.
        /// </summary>
        /// <returns></returns>
        public int GetEndScore()
        {
            return (Endurance / Settings.Settings.TalentDivision) + EnduranceModifier;
        }

        /// <summary>
        /// Return the player's true intelligence talent score.
        /// </summary>
        /// <returns></returns>
        public int GetIntScore()
        {
            return (Intelligence / Settings.Settings.TalentDivision) + IntelligenceModifier;
        }

        /// <summary>
        /// Return the player's true charisma talent score.
        /// </summary>
        /// <returns></returns>
        public int GetChaScore()
        {
            return (Charisma / Settings.Settings.TalentDivision) + CharismaModifier;
        }

        /// <summary>
        /// Return the player's true strength talent score.
        /// </summary>
        /// <returns></returns>
        public int GetStrScore()
        {
            return (Strength / Settings.Settings.TalentDivision) + StrengthModifier;
        }
    }
}
