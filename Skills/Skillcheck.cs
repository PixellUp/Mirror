using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Models;
using Skillsheet = Mirror.Skills.Skills;
using Dice = Mirror.Skills.Utility;

namespace Mirror.Skills
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
        /// Compare skills between two players. Impact will always effect the initiator.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="target"></param>
        /// <param name="type"></param>
        /// <param name="impact"></param>
        /// <returns></returns>
        public static bool SkillCheckPlayers(Client client, Client target, Skills type, int impact = 0, int clientModifier = 0, int targetModifier = 0)
        {
            if (!client.HasData("Mirror_Skills"))
                return false;

            if (!target.HasData("Mirror_Skills"))
                return false;

            int clientRoll = 0;
            int targetRoll = 0;

            Skillsheet clientSheet = client.GetData("Mirror_Skills");
            Skillsheet targetSheet = target.GetData("Mirror_Skills");

            switch (type)
            {
                case Skills.strength:
                    clientRoll = clientSheet.GetScore(clientSheet.Strength, clientSheet.StrengthModifier) + Dice.RollDice(20) - clientModifier;
                    targetRoll = targetSheet.GetScore(targetSheet.Strength, targetSheet.StrengthModifier) + Dice.RollDice(20) - targetModifier;
                    break;
                case Skills.endurance:
                    clientRoll = clientSheet.GetScore(clientSheet.Endurance, clientSheet.EnduranceModifier) + Dice.RollDice(20) - clientModifier;
                    targetRoll = targetSheet.GetScore(targetSheet.Endurance, targetSheet.EnduranceModifier) + Dice.RollDice(20) - targetModifier;
                    break;
                case Skills.intelligence:
                    clientRoll = clientSheet.GetScore(clientSheet.Intelligence, clientSheet.IntelligenceModifier) + Dice.RollDice(20) - clientModifier;
                    targetRoll = targetSheet.GetScore(targetSheet.Intelligence, targetSheet.IntelligenceModifier) + Dice.RollDice(20) - targetModifier;
                    break;
                case Skills.charisma:
                    clientRoll = clientSheet.GetScore(clientSheet.Charisma, clientSheet.CharismaModifier) + Dice.RollDice(20) - clientModifier;
                    targetRoll = targetSheet.GetScore(targetSheet.Charisma, targetSheet.CharismaModifier) + Dice.RollDice(20) - targetModifier;
                    break;
            }

            client.TriggerEvent("eventLastRoll", clientRoll);
            target.TriggerEvent("eventLastRoll", targetRoll);

            if (clientRoll > targetRoll)
                return true;

            switch (type)
            {
                case Skills.strength:
                    clientSheet.StrengthModifier += impact;
                    break;
                case Skills.endurance:
                    clientSheet.EnduranceModifier += impact;
                    break;
                case Skills.intelligence:
                    clientSheet.IntelligenceModifier += impact;
                    break;
                case Skills.charisma:
                    clientSheet.CharismaModifier += impact;
                    break;
            }
            clientSheet.Update(client);
            return false;
        }

        /// <summary>
        /// Compare a skill against a basic 'score to beat'.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="type"></param>
        /// <param name="scoreToBeat"></param>
        /// <param name="impact"></param>
        /// <returns></returns>
        public static bool SkillCheckPlayer(Client client, Skills type, int scoreToBeat = 10, int impact = 0)
        {
            if (!client.HasData("Mirror_Skills"))
                return false;

            if (!(client.GetData("Mirror_Skills") is Skillsheet clientSheet))
                return false;

            int clientRoll = 0;

            switch (type)
            {
                case Skills.strength:
                    clientRoll = clientSheet.GetScore(clientSheet.Strength, clientSheet.StrengthModifier) + Dice.RollDice(20);
                    break;
                case Skills.endurance:
                    clientRoll = clientSheet.GetScore(clientSheet.Endurance, clientSheet.EnduranceModifier) + Dice.RollDice(20);
                    break;
                case Skills.intelligence:
                    clientRoll = clientSheet.GetScore(clientSheet.Intelligence, clientSheet.IntelligenceModifier) + Dice.RollDice(20);
                    break;
                case Skills.charisma:
                    clientRoll = clientSheet.GetScore(clientSheet.Charisma, clientSheet.CharismaModifier) + Dice.RollDice(20);
                    break;
            }

            client.TriggerEvent("eventLastRoll", clientRoll);

            if (clientRoll > scoreToBeat)
                return true;

            switch (type)
            {
                case Skills.strength:
                    clientSheet.StrengthModifier += impact;
                    break;
                case Skills.endurance:
                    clientSheet.EnduranceModifier += impact;
                    break;
                case Skills.intelligence:
                    clientSheet.IntelligenceModifier += impact;
                    break;
                case Skills.charisma:
                    clientSheet.CharismaModifier += impact;
                    break;
            }

            clientSheet.Update(client);
            return false;
        }
    }
}
