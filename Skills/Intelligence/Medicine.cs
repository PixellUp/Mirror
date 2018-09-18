using GTANetworkAPI;
using Mirror.Events;
using Mirror.Levels;

using Mirror.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Mirror.Handler;
using Mirror.Classes.Static;
using Mirror.Classes.Models;
using Mirror.Classes.Static.StaticEvents;
using Mirror.Globals;

namespace Mirror.Skills.Intelligence
{
    public class Medicine : Script
    {
        private readonly string VariableName = "IsMedicineReady";
        private readonly string Notification = "Notification";

        public Medicine()
        {
            RankEvents.PassiveEvent.PassiveEventTrigger += CheckPassive;
        }

        private void CheckPassive(object source, Client client)
        {
            if (!client.HasData(VariableName + Notification))
                client.SetData(VariableName + Notification, false);

            if (!(client.GetData(EntityData.Account) is Account account))
                return;

            LevelRanks levelRanks = account.GetLevelRanks();

            if (levelRanks.Medicine <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = AccountUtil.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, VariableName, SkillCooldowns.Medicine);

            if (!levelRankCooldowns.IsMedicineReady)
            {
                client.SetData(VariableName + Notification, false);
                return;
            }

            if (client.GetData(VariableName + Notification))
                return;

            client.SetData(VariableName + Notification, true);
            client.SendChatMessage("~b~Medicine ~w~You can heal someone else or heal yourself for additional again.");
        }

        public static void Use(Client client, Client target)
        {
            Account account = client.GetData(EntityData.Account);
            LevelRanks ranks = account.GetLevelRanks();
            LevelRankCooldowns cooldowns = AccountUtil.GetCooldowns(client);
            string itemToBurn = "Medkit";

            if (client.Position.DistanceTo2D(target.Position) > 5)
                return;

            if (account.IsDead)
                return;

            // They don't have Medicine.
            if (ranks.Medicine <= 0)
                return;

            if (!cooldowns.IsMedicineReady)
                return;

            if (!account.Inventory.ToLower().Contains(itemToBurn.ToLower()))
            {
                client.SendChatMessage("~r~You don't have a Medkit to heal the other player.");
                return;
            }

            bool didItBurn = InventoryHandler.BurnItemFromInventory(client, itemToBurn);

            if (!didItBurn)
                return;

            cooldowns.IsMedicineReady = false;
            cooldowns.NotifyClientsideOfChange(client);

            // Okay it burned let's heal the other player.
            Account targetAccount = target.GetData(EntityData.Account);
            target.Health += (25 + ranks.Medicine * 2); // Heal 25 + Ranks * 2. Max heal is around 91 at 33 points.
            targetAccount.SetPlayerRevived(target);
            target.StopAnimation();
            Account.PlayerUpdateEvent.Trigger(target, targetAccount);
        }
    }
}
