using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EosSharp;
using EosSharp.Api.v1;
using GTANetworkAPI;
using Mirror.Classes.Models;
using Mirror.Classes.Models.Player;
using Newtonsoft.Json;

namespace Mirror.Classes.Static
{
    public class EOSHelper : Script
    {
        public class Row
        {
            public string Balance { get; set; }
        }

        public class BalanceParse
        {
            public List<Row> Rows { get; set; }
            public bool More { get; set; }
        }

        public static Eos EOS;

        public EOSHelper()
        {
            string key = new System.IO.StreamReader(@"A:/Documents/Wallet/magic.txt").ReadLine();
            EosConfigurator config = new EosConfigurator()
            {
                HttpEndpoint = "https://nodes.eos42.io",
                ExpireSeconds = 60,
                ChainId = "aca376f206b8fc25a6ed44dbdc66547c36c6c33e3a119ffbeaef943642f0e906",
            };


            config.SignProvider = new DefaultSignProvider(key);

            EOS = new Eos(config);

            TestTransactionResults();
        }

        public static void TestTransactionResults()
        {
            Task.Factory.StartNew(async () =>
            {
                Task<GetTransactionResponse> actions = EOS.GetTransaction("8aec0347579236900878bc460eb4b3ab3fdd4009ca1e5e7c6aad5b97a1b8e622");

                var result = await actions;

                Console.WriteLine(JsonConvert.SerializeObject(result));

            });
        }


        private async void GetAccountBalance(Client client, string pubkey)
        {
            var result = await EOS.GetTableRows(new GetTableRowsRequest()
            {
                Json = true,
                Code = "mirrorserver",
                Scope = pubkey,
                Table = "accounts"
            });

            if (result == null)
                return;

            string parsedResult = JsonConvert.SerializeObject(result);
            BalanceParse balance = JsonConvert.DeserializeObject<BalanceParse>(parsedResult);

            var row = balance.Rows.Find(x => x.Balance.Contains("MIRROR"));

            if (row == null)
                return;

            string finalBalance = row.Balance.Replace("MIRROR", "");
            double amount = Convert.ToDouble(finalBalance);

            client.SendChatMessage($"Your account balance is: {amount} MIRROR");
        }

        private async void IssueToken(Client client, string pubkey, double amount)
        {
            if (amount > 10)
                return;

            if (amount < 0)
                return;

            Task<string> task = EOS.CreateTransaction(new Transaction()
            {
                Actions = new List<EosSharp.Api.v1.Action>()
                    {
                        new EosSharp.Api.v1.Action()
                        {
                            Account = "mirrorserver",
                            Authorization = new List<PermissionLevel>()
                            {
                                new PermissionLevel() { Actor = "mirrorserver", Permission = "active" }
                            },
                            Name = "issue",
                            Data = new { from = "mirrorserver", to = pubkey, quantity = "0.01 MIRROR", memo = "(Memo: Testing a Memo)" }
                        }
                    }
            });

            try
            {
                SendMessageToClient(client, await task, $"From: MirrorServer -> To: {pubkey} ~n~Amount: {amount}");
                GetBalance(client);
            } catch (Exception ex) {
                client.SendChatMessage("Transaction was invalid.");
            }
        }

        private void SendMessageToClient(Client client, string transactionID, string receipt) => client.SendNotification($"Transaction: {transactionID} ~n~{receipt}");

        [Command("testtoken")]
        public void TestToken(Client client, double amount)
        {
            Account account = AccountUtil.RetrieveAccount(client);
            Scatter scatter = account.GetScatter();

            IssueToken(client, scatter.PubKey, amount);
        }

        [Command("getbalance")]
        public void GetBalance(Client client)
        {
            Account account = AccountUtil.RetrieveAccount(client);
            Scatter scatter = account.GetScatter();

            GetAccountBalance(client, scatter.PubKey);
        }


    }
}
