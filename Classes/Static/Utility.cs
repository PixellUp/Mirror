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

        /// <summary>
        /// Break a vehicle's window on 'client-side'.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="vehicle"></param>
        public static void BreakVehicleWindow(Client client, Vehicle vehicle)
        {
            Client[] players = NAPI.Pools.GetAllPlayers().ToArray();

            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].Position.DistanceTo2D(client.Position) > 30)
                    continue;

                client.TriggerEvent("eventBreakWindow", vehicle);
            }
        }

        /// <summary>
        /// Force the client to follow the target for a set period of time.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="target"></param>
        /// <param name="dragTime"></param>
        public static void ForcePlayerToFollowPlayer(Client client, Client target, int dragTime) => client.TriggerEvent("eventForceFollow", target, dragTime);

        /// <summary>
        /// Force a client to cower in position for a set period of time.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="cowerTime"></param>
        public static void ForcePlayerCower(Client client, int cowerTime) => client.TriggerEvent("eventIntimidate", cowerTime);

        /// <summary>
        /// Play a sound for the client.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="audioName"></param>
        /// <param name="audioLibrary"></param>
        public static void PlaySoundFrontend(Client client, string audioName, string audioLibrary) => client.TriggerEvent("PlaySoundFrontend", audioName, audioLibrary);

        /// <summary>
        /// Force the player to close their inventory.
        /// </summary>
        /// <param name="client"></param>
        public static void ForceCloseInventory(Client client) => client.TriggerEvent("eventCloseInventory");
    }
}
