using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using LiteDbWrapper;
using Mirror.Classes;

namespace Mirror.Utility
{
    public static class Utility
    {
        /// <summary>
        /// Check if the username is in Roleplay format.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsNameRoleplayFormat(string name)
        {
            string pattern = "^([A-Z][a-z]+_[A-Z][a-z]+)$";
            return System.Text.RegularExpressions.Regex.IsMatch(name, pattern);
        }

        /// <summary>
        /// Determine if the player is already logged in to the server.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CheckIfLoggedIn(string name)
        {
            Client client = NAPI.Pools.GetAllPlayers().Find(x => x.Name == name);

            if (client == null)
                return false;

            return true;
        }

        /// <summary>
        /// Check if the username already exists.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool DoesUsernameExist(string name)
        {
            Account acc = Database.Get<Account>("Name", name);
            if (acc == null)
            {
                return false;
            }
            return true;
        }
    }
}
