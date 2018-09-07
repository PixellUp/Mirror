using LiteDbWrapper;
using Mirror.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mirror.Models
{
    public class Money
    {
        public int Id { get; set; }
        public double ServerHardcap { get; set; } = 500000000; // 500,000,000;
        public double CurrentEconomyPrinted { get; set; } = 0;
    }

    public static class TransactionProccess
    {
        public static Money ServerFunds { get; set; }

        /// <summary>
        /// Initialize the Money Service on Server Start.
        /// </summary>
        public static void Initialize()
        {
            if (!Database.Exists<Money>())
            {
                // Create Money Entry
                ServerFunds = new Money();
                Database.Upsert(ServerFunds);
                Console.WriteLine(Exceptions.UtilityMoneyEstablished);
                return;
            }

            // Get Money Entry
            var collection = Database.GetCollection<Money>();
            ServerFunds = collection.First();

            if (ServerFunds == null)
                return;

            Console.WriteLine(Exceptions.UtilityMoneyLoaded);
            Console.WriteLine(Exceptions.Prefix + ServerFunds.CurrentEconomyPrinted.ToString());
        }

        public static void Transaction(string fromPlayer, string toPlayer, int amount)
        {

        }

        public static void ServerTransactionTo(string toPlayer)
        {

        }
    }
}
