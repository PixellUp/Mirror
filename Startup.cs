using System;
using System.Collections.Generic;
using GTANetworkAPI;
using LiteDbWrapper;
using Mirror.Models;

namespace Mirror
{
    public class Startup : Script
    {
        public Startup()
        {
            Settings.Settings.Initialize();
            ResetLogins();

            MaleValidTopConfiguration.Initialize();
            FemaleValidTopConfiguration.Initialize();
        }

        /// <summary>
        /// Resets all the players from logged in to false on server restart.
        /// </summary>
        public void ResetLogins()
        {
            IEnumerable<Account> collection = Database.GetCollection<Account>();

            foreach (Account acc in collection)
            {
                acc.ResetLogin();
            }
        }
    }
}