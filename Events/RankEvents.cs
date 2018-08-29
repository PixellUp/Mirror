using GTANetworkAPI;
using Mirror.Events.ActualEvents;
using Mirror.Levels;
using Mirror.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public static class RankEvents
    {
        public static PassiveEvent PassiveEvent = new PassiveEvent();

        public static void AllocateRankPoint(Client client, params object[] args)
        {
            if (args[1] == null)
                return;

            if (!client.HasData("Mirror_Account"))
                return;

            if (!(client.GetData("Mirror_Account") is Account account))
                return;

            LevelRanks levelRanks = JsonConvert.DeserializeObject<LevelRanks>(account.LevelRanks);
            bool success = levelRanks.AllocateSkillPoint(account.CurrentExperience, args[1] as string);

            if (!success)
            {
                if (levelRanks.GetUnallocatedRankPointCount(account.CurrentExperience) <= 0)
                    client.SendChatMessage("~r~You have no points available.");
                return;
            }
            
            levelRanks.UpdateLevelRanks(client);

            int pointsLeft = levelRanks.GetUnallocatedRankPointCount(account.CurrentExperience);
            client.SendChatMessage($"Point allocated successfully to ~g~{args[1]}~w~. You have ~o~{pointsLeft}~w~ points left.");
        }

        public static void UpdateAllPlayerPassives()
        {
            List<Client> clients = NAPI.Pools.GetAllPlayers();

            clients.ForEach((client) =>
            {
                if (!client.HasData("Mirror_Account"))
                    return;

                PassiveEvent.Trigger(client);
            });
        }


        public static void RankEventRegenerate(Client client)
        {
            if (!client.HasData("Mirror_Account"))
                return;

            if (!(client.GetData("Mirror_Account") is Account account))
                return;

            if (!client.HasData("Mirror_LevelRank_Regenerate"))
                client.SetData("Mirror_LevelRank_Regenerate", DateTime.Now);

            LevelRanks levelRanks = account.GetLevelRanks();

            if (levelRanks.Regenerate <= 0)
                return;

            DateTime clientDateTime = client.GetData("Mirror_LevelRank_Regenerate");

            if (DateTime.Compare(DateTime.Now, clientDateTime) < 0)
                return;

            client.SetData("Mirror_LevelRank_Regenerate", DateTime.Now.AddSeconds(30));

            if (client.Health >= 100)
                return;

            client.Health += levelRanks.Regenerate;
        }
    }
}
