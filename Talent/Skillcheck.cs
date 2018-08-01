using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Classes;

namespace Mirror.Talent
{
    public static class Skillcheck
    {
        public enum Skills
        {
            endurance,
            intelligence,
            strength,
            charisma
        }

        /// <summary>
        /// Checks if the player's endurance beats the score required and if they fail impacts the skill by whatever amount is set. Default is 0. Use + or -
        /// </summary>
        /// <param name="client"></param>
        /// <param name="scoreToBeat"></param>
        /// <returns></returns>
        public static bool CheckEndurance(Client client, int scoreToBeat = 10, int impact = 0)
        {
            TalentScoresheet scoresheet = client.GetData("TalentScoresheet") as TalentScoresheet;

            if (scoresheet.GetEndScore() + Dice.RollDice() > scoreToBeat)
                return true;

            scoresheet.EnduranceModifier += impact;
            return false;
        }

        /// <summary>
        /// Checks if the player's Intelligence beats the score required.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="scoreToBeat"></param>
        /// <returns></returns>
        public static bool CheckIntelligence(Client client, int scoreToBeat = 10, int impact = 0)
        {
            TalentScoresheet scoresheet = client.GetData("TalentScoresheet") as TalentScoresheet;

            if (scoresheet.GetIntScore() + Dice.RollDice() > scoreToBeat)
                return true;

            scoresheet.IntelligenceModifier += impact;
            return false;
        }

        /// <summary>
        /// Checks if the player's Strength beats the score required.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="scoreToBeat"></param>
        /// <returns></returns>
        public static bool CheckStrength(Client client, int scoreToBeat = 10, int impact = 0)
        {
            TalentScoresheet scoresheet = client.GetData("TalentScoresheet") as TalentScoresheet;

            if (scoresheet.GetStrScore() + Dice.RollDice() > scoreToBeat)
                return true;

            scoresheet.StrengthModifier += impact;
            return false;
        }

        /// <summary>
        /// Checks if the player's Endurance beats the score required.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="scoreToBeat"></param>
        /// <returns></returns>
        public static bool CheckCharisma(Client client, int scoreToBeat = 10, int impact = 0)
        {
            TalentScoresheet scoresheet = client.GetData("TalentScoresheet") as TalentScoresheet;

            if (scoresheet.GetChaScore() + Dice.RollDice() > scoreToBeat)
                return true;

            scoresheet.CharismaModifier += impact;
            return false;
        }

        /// <summary>
        /// Will return true if the client wins. False is the target wins.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool CheckStrAgainstOpponent(Client client, Client target, int impact = 0)
        {
            if (!client.HasData("TalentScoresheet"))
                return false;

            if (!target.HasData("TalentScoresheet"))
                return false;

            TalentScoresheet clientSheet = client.GetData("TalentScoresheet") as TalentScoresheet;
            TalentScoresheet targetSheet = client.GetData("TalentScoresheet") as TalentScoresheet;

            if (clientSheet == null)
                return false;

            if (targetSheet == null)
                return false;

            int clientRoll = clientSheet.GetStrScore() + Dice.RollDice();
            int targetRoll = targetSheet.GetStrScore() + Dice.RollDice();

            client.SendNotification($"[~r~STRENGTH~w~] -> ~b~{clientRoll} vs ~o~{targetRoll}");

            if (clientRoll > targetRoll)
                return true;

            clientSheet.StrengthModifier += impact;
            return false;
        }

        /// <summary>
        /// Will return true if the client wins. False is the target wins.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool CheckEndAgainstOpponent(Client client, Client target, int impact = 0)
        {
            if (!client.HasData("TalentScoresheet"))
                return false;

            if (!target.HasData("TalentScoresheet"))
                return false;

            TalentScoresheet clientSheet = client.GetData("TalentScoresheet") as TalentScoresheet;
            TalentScoresheet targetSheet = client.GetData("TalentScoresheet") as TalentScoresheet;

            if (clientSheet == null)
                return false;

            if (targetSheet == null)
                return false;

            int clientRoll = clientSheet.GetEndScore() + Dice.RollDice();
            int targetRoll = targetSheet.GetEndScore() + Dice.RollDice();

            client.SendNotification($"[~g~ENDURANCE~w~] -> ~b~{clientRoll} vs ~o~{targetRoll}");

            if (clientRoll > targetRoll)
                return true;

            clientSheet.EnduranceModifier += impact;
            return false;
        }

        /// <summary>
        /// Will return true if the client wins. False is the target wins.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool CheckIntAgainstPlayer(Client client, Client target, int impact = 0)
        {
            if (!client.HasData("TalentScoresheet"))
                return false;

            if (!target.HasData("TalentScoresheet"))
                return false;

            TalentScoresheet clientSheet = client.GetData("TalentScoresheet") as TalentScoresheet;
            TalentScoresheet targetSheet = client.GetData("TalentScoresheet") as TalentScoresheet;

            if (clientSheet == null)
                return false;

            if (targetSheet == null)
                return false;

            int clientRoll = clientSheet.GetIntScore() + Dice.RollDice();
            int targetRoll = targetSheet.GetIntScore() + Dice.RollDice();

            client.SendNotification($"[~b~INTEL~w~] -> ~b~{clientRoll} vs ~o~{targetRoll}");

            if (clientRoll > targetRoll)
                return true;

            clientSheet.IntelligenceModifier += impact;
            return false;
        }

        /// <summary>
        /// Will return true if the client wins. False is the target wins.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool CheckChaAgainstPlayer(Client client, Client target, int impact = 0)
        {
            if (!client.HasData("TalentScoresheet"))
                return false;

            if (!target.HasData("TalentScoresheet"))
                return false;

            TalentScoresheet clientSheet = client.GetData("TalentScoresheet") as TalentScoresheet;
            TalentScoresheet targetSheet = client.GetData("TalentScoresheet") as TalentScoresheet;

            if (clientSheet == null)
                return false;

            if (targetSheet == null)
                return false;

            int clientRoll = clientSheet.GetChaScore() + Dice.RollDice();
            int targetRoll = targetSheet.GetChaScore() + Dice.RollDice();

            client.SendNotification($"[~y~CHARISMA~w~] -> ~b~{clientRoll} vs ~o~{targetRoll}");

            if (clientRoll > targetRoll)
                return true;

            clientSheet.CharismaModifier += impact;
            return false;
        }
    }
}
