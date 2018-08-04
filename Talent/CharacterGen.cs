using GTANetworkAPI;
using LiteDbWrapper;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Models;

namespace Mirror.Talent
{
    public static class CharacterGen
    {
        /// <summary>
        /// Returns a new modifier number that is correctly calculated.
        /// </summary>
        /// <returns></returns>
        public static int GenerateModifier()
        {
            int modifier = 0;

            for (var i = 0; i < 3; i++)
            {
                modifier += Dice.RollDice(6);
            }

            return modifier;
        }

        /// <summary>
        /// Load the TalentSheet from the database.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static Skills LoadTalentSheet(Client client)
        {
            Skills skills = (Skills) client.GetData("Mirror_Skills");

            if (skills == null)
                return new Skills();

            return skills;
        }
    }
}
