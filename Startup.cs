using System;
using System.Collections.Generic;
using GTANetworkAPI;
using LiteDbWrapper;
using Mirror.Models;
using Newtonsoft.Json;

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

            /*
            double minLevel = 2;
            double points = 0;
            
            for (int level = 0; level < 100; level++)
            {
                points += Math.Floor(level + 300 * Math.Pow(2, level / 7));
                if (level >= minLevel)
                {
                    Console.WriteLine($"{level} -> XP: {Math.Floor(points / 4)}");
                }

            }
            */




            
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