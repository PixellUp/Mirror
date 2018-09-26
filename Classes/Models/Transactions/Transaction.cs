using EosSharp;
using GTANetworkAPI;
using Mirror.Classes.Static;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mirror.Classes.Models.Transactions
{
    public static class TransactionPool
    {
        public static List<UnconfirmedTransaction> Transactions = new List<UnconfirmedTransaction>();

        public static void FindTransaction(Client client, string transaction)
        {
            Task.Factory.StartNew(async () =>
            {
                /*
                Task<EosSharp.Api.v1.GetTransactionResponse> response = EOSHelper.EOS.GetActions(transaction);

                var result = await response;
                */
                
            });
        }
    }

    public class UnconfirmedTransaction
    {
        public Client Client { get; set; }
        public string UniqueID { get; set; } = $"MIRROR{new Random().Next(0, 9000000)}";
        public InventoryItem Item { get; set; }
        public bool Issued { get; set; } = false;
        public double Cost { get; set; } = 1.00;
    }
}
