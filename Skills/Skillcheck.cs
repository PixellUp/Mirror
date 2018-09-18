using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

using Skillsheet = Mirror.Skills.Skills;
using Dice = Mirror.Skills.Utility;
using Mirror.Globals;
using Mirror.Classes.Static;

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
            if (!client.HasData(EntityData.Skills))
                return false;

            if (!target.HasData(EntityData.Skills))
                return false;

            int clientRoll = 0;
            int targetRoll = 0;

            Skillsheet clientSheet = client.GetData(EntityData.Skills);
            Skillsheet targetSheet = target.GetData(EntityData.Skills);

            int initialClientRoll = Dice.RollDice(20);
            int initialTargetRoll = Dice.RollDice(20);

            if (initialClientRoll == 20)
            {
                client.SendNotification("You rolled a ~o~20!");
                client.TriggerEvent("eventLastRoll", initialClientRoll);
                target.TriggerEvent("eventLastRoll", initialTargetRoll);
                return true;
            }

            switch (type)
            {
                case Skills.strength:
                    clientRoll = clientSheet.GetScore(clientSheet.Strength, clientSheet.StrengthModifier) + initialClientRoll - clientModifier;
                    targetRoll = targetSheet.GetScore(targetSheet.Strength, targetSheet.StrengthModifier) + initialTargetRoll - targetModifier;
                    break;
                case Skills.endurance:
                    clientRoll = clientSheet.GetScore(clientSheet.Endurance, clientSheet.EnduranceModifier) + initialClientRoll - clientModifier;
                    targetRoll = targetSheet.GetScore(targetSheet.Endurance, targetSheet.EnduranceModifier) + initialTargetRoll - targetModifier;
                    break;
                case Skills.intelligence:
                    clientRoll = clientSheet.GetScore(clientSheet.Intelligence, clientSheet.IntelligenceModifier) + initialClientRoll - clientModifier;
                    targetRoll = targetSheet.GetScore(targetSheet.Intelligence, targetSheet.IntelligenceModifier) + initialTargetRoll - targetModifier;
                    break;
                case Skills.charisma:
                    clientRoll = clientSheet.GetScore(clientSheet.Charisma, clientSheet.CharismaModifier) + initialClientRoll - clientModifier;
                    targetRoll = targetSheet.GetScore(targetSheet.Charisma, targetSheet.CharismaModifier) + initialTargetRoll - targetModifier;
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
        public static bool SkillCheckPlayer(Client client, Skills type, int scoreToBeat = 10, int impact = 0, int clientModifier = 0, int targetModifier = 0)
        {
            if (!client.HasData(EntityData.Skills))
                return false;

            if (!(client.GetData(EntityData.Skills) is Skillsheet clientSheet))
                return false;

            int clientRoll = 0;
            int initialRoll = Dice.RollDice(20);

            switch (type)
            {
                case Skills.strength:
                    clientRoll = clientSheet.GetScore(clientSheet.Strength, clientSheet.StrengthModifier);
                    break;
                case Skills.endurance:
                    clientRoll = clientSheet.GetScore(clientSheet.Endurance, clientSheet.EnduranceModifier);
                    break;
                case Skills.intelligence:
                    clientRoll = clientSheet.GetScore(clientSheet.Intelligence, clientSheet.IntelligenceModifier);
                    break;
                case Skills.charisma:
                    clientRoll = clientSheet.GetScore(clientSheet.Charisma, clientSheet.CharismaModifier);
                    break;
            }

            clientRoll += initialRoll;
            client.TriggerEvent("eventLastRoll", clientRoll);

            if (clientRoll + clientModifier > (scoreToBeat + targetModifier) || initialRoll == 20)
            {
                if (initialRoll == 20)
                    client.SendNotification("You rolled a ~o~20!");
                return true;
            }

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
