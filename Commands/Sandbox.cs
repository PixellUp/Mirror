using GTANetworkAPI;
using Mirror.Handler;
using Mirror.Levels;
using Mirror.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Skillsheet = Mirror.Skills.Skills;

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

        [Command("dropitem")]
        public void CmdRemoveItem(Client client, int index)
        {
            InventoryHandler.RemoveItemFromInventory(client, index, true);

            string json = InventoryHandler.GetInventory(client);

            InventoryItem[] items = InventoryHandler.GetInventoryArray(json);

            string itemList = "";

            StringBuilder builder = new StringBuilder(itemList);

            foreach (InventoryItem item in items)
            {
                if (item == null)
                    continue;

                builder.Append($"{item.ID} {item.Name} | ");
            }

            string finished = builder.ToString();
            client.SendChatMessage(finished);
        }

        [Command("addxp")]
        public void CmdSetXP(Client client, int amount)
        {
            LevelSystem.AddPlayerExperience(client, amount);
        }

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
        public void cmdTP(Client client, string trg)
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
    }
}
