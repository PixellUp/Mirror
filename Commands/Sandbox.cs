using GTANetworkAPI;
using Mirror.Handler;
using Mirror.Levels;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Skillsheet = Mirror.Skills.Skills;
using Mirror.Classes.Static;
using Mirror.Classes.Models;

namespace Mirror.Commands
{
    public class Sandbox : Script
    {
        [Command("cv")]
        public void CreateVehicle(Client client, string value, bool locked)
        {
            uint vehiclecode = NAPI.Util.GetHashKey(value);

            Vehicle newVeh = NAPI.Vehicle.CreateVehicle(vehiclecode, client.Position.Around(5), 0, 45, 45, "TESTING", 255, locked, true);
        }

        [Command("sethealth")]
        public void SetHealth(Client client, int amount)
        {
            client.Health = amount;
        }

        [Command("time")]
        public void SetTime(Client client, int hour)
        {
            NAPI.World.SetTime(hour, 0, 0);
        }

        [Command("update")]
        public void UpdateClothing(Client client)
        {
            if (!client.HasData("Mirror_Account"))
                return;

            Account acc = client.GetData("Mirror_Account") as Account;

            Appearance app = Appearance.RetrieveAppearance(acc);
            app.Attach(client);

            Clothing clothing = Clothing.RetrieveClothing(acc);
            clothing.Attach(client);
        }

        [Command("setpoint")]
        public void CmdSetPoint(Client client, string type, int radius = 5)
        {
            Location.CreatePosition(client, type, radius);
        }


        [Command("additem")]
        public void CmdAddItem(Client client, string name, int amount = 1)
        {
            InventoryHandler.AddItemToInventory(client, name, amount);
        }

        [Command("addxp")]
        public void CmdSetXP(Client client, int amount) => AccountUtil.AddExperience(client, amount);

        [Command("getpoints")]
        public void GetPoints(Client client)
        {
            Account account = client.GetData("Mirror_Account");

            LevelRanks levelRanks = JsonConvert.DeserializeObject<LevelRanks>(account.LevelRanks);

            client.SendChatMessage($"{levelRanks.GetUnallocatedRankPointCount(account.CurrentExperience)}");
        }

        [Command("allocatepoint")]
        public void CMDAllocatePoint(Client client, string type)
        {
            Events.RankEvents.AllocateRankPoint(client, "", type);
        }

        [Command("tp")]
        public void CmdTP(Client client, string trg)
        {
            Client target = NAPI.Player.GetPlayerFromName(trg);

            if (target == null)
                return;

            client.Position = target.Position.Around(5);
        }

        [Command("weapon")]
        public void CmdWeapon(Client client, string weapon)
        {
            client.RemoveAllWeapons();

            WeaponHash hash = NAPI.Util.WeaponNameToModel(weapon);
            NAPI.Player.GivePlayerWeapon(client, hash, 25);
        }

        [Command("transfer")]
        public void CmdTransferMoney(Client client, string target, int amount)
        {
            TransactionProccess.Transaction(client, target, amount);
        }
    }
}
