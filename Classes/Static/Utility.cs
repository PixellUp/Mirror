using GTANetworkAPI;
using Mirror.Classes;
using Mirror.Classes.Models;

namespace Mirror.Classes.Static
{
    public static class Utilities
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
        /// Check if the username already exists.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool DoesFieldExistInAccounts(string targetField, string name)
        {
            Account acc = Database.Get<Account>(targetField, name);
            if (acc == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Freeze the player's client.
        /// </summary>
        /// <param name="client"></param>
        public static void FreezePlayerAccount(Client client, bool value) => client.TriggerEvent("eventFreeze", client.Handle, value);

        /// <summary>
        /// Disables the player's client controls + hud.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="value"></param>
        public static void DisablePlayerAccount(Client client, bool value) => client.TriggerEvent("eventDisable", value);

        /// <summary>
        /// Sets the player's account as logged in on the client-side.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="value"></param>
        public static void LoginPlayerAccount(Client client, bool value) => client.TriggerEvent("eventLoggedIn", value);
    }
}
