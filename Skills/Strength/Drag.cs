using GTANetworkAPI;
using Mirror.Events;
using Mirror.Levels;

using Mirror.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Classes.Static;
using Mirror.Classes.Models;
using Mirror.Classes.Static.StaticEvents;

namespace Mirror.Skills.Strength
{
    public class Drag : Script
    {
        private readonly string VariableName = "IsDragReady";
        private readonly string Notification = "Notification";

        public Drag()
        {
            RankEvents.PassiveEvent.PassiveEventTrigger += CheckPassive;
        }

        private void CheckPassive(object source, Client client)
        {
            if (!client.HasData(VariableName + Notification))
                client.SetData(VariableName + Notification, false);

            if (!(client.GetData("Mirror_Account") is Account account))
                return;

            LevelRanks levelRanks = account.GetLevelRanks();

            if (levelRanks.Drag <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = AccountUtil.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, VariableName, SkillCooldowns.Drag);

            if (!levelRankCooldowns.IsDragReady)
            {
                client.SetData(VariableName + Notification, false);
                return;
            }

            if (client.GetData(VariableName + Notification))
                return;

            client.SetData(VariableName + Notification, true);
            client.SendChatMessage("~r~Drag ~w~You're able to drag someone again.");
        }

        public static void Use(Client client, Client target)
        {
            if (!client.Exists)
                return;

            if (!target.Exists)
                return;

            if (client.Position.DistanceTo2D(target.Position) > 5)
                return;

            LevelRankCooldowns cooldowns = AccountUtil.GetCooldowns(client);
            LevelRanks ranks = AccountUtil.GetLevelRanks(client);

            if (ranks.Drag <= 0)
                return;

            if (!cooldowns.IsDragReady)
                return;

            cooldowns.IsDragReady = false;
            Utilities.ForcePlayerToFollowPlayer(target, client, ranks.Drag * 2500);
            client.SendChatMessage($"~r~Drag ~w~You are dragging ~o~{target.Name}.");
            target.SendChatMessage($"~r~Drag ~w~You are being dragged by ~o~{client.Name}.");
        }
    }
}
