using GTANetworkAPI;
using Mirror.Levels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Mirror.Classes.Static;
using Mirror.Classes.Models;
using Mirror.Events;
using Mirror.Globals;

namespace Mirror.Classes.Static.StaticEvents
{
    public static class RankEvents
    {
        public static PassiveEvent PassiveEvent = new PassiveEvent();

        public static void AllocateRankPoint(Client client, params object[] args)
        {
            if (args[1] == null)
                return;

            if (!client.HasData(EntityData.Account))
                return;

            if (!(client.GetData(EntityData.Account) is Account account))
                return;

            string argumentString = args[1] as string;

            if (argumentString.Contains(":"))
            {
                argumentString = argumentString.Substring(0, argumentString.Length - 3);
                argumentString = Regex.Replace(argumentString, @"[0-9\s:]", String.Empty);
            }

            LevelRanks levelRanks = JsonConvert.DeserializeObject<LevelRanks>(account.LevelRanks);
            bool success = levelRanks.AllocateSkillPoint(account.CurrentExperience, argumentString);

            if (!success)
            {
                if (levelRanks.GetUnallocatedRankPointCount(account.CurrentExperience) <= 0)
                    client.SendChatMessage("~r~You have no points available.");
                client.TriggerEvent("PlaySoundFrontend", "Hack_Failed", "DLC_HEIST_BIOLAB_PREP_HACKING_SOUNDS");
                return;
            }
            
            levelRanks.UpdateLevelRanks(client);

            int pointsLeft = levelRanks.GetUnallocatedRankPointCount(account.CurrentExperience);
            client.SendChatMessage($"Point allocated successfully to ~g~{argumentString}~w~. You have ~o~{pointsLeft}~w~ points left.");

            client.TriggerEvent("PlaySoundFrontend", "Hack_Success", "DLC_HEIST_BIOLAB_PREP_HACKING_SOUNDS");
            client.TriggerEvent("ReloadRankButtons");
        }

        public static void UpdateAllPlayerPassives()
        {
            List<Client> clients = NAPI.Pools.GetAllPlayers();

            clients.ForEach((client) =>
            {
                if (!AccountUtil.IsAccountReady(client))
                    return;

                PassiveEvent.Trigger(client);
            });
        }
    }
}
