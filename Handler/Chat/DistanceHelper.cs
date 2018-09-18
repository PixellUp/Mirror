using GTANetworkAPI;
using Mirror.Globals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Handler.Chat
{
    public class DistanceHelper : Script
    {
        // Turn off chat globally.
        public DistanceHelper()
        {
            NAPI.Server.SetGlobalServerChat(false);
        }

        [ServerEvent(Event.ChatMessage)]
        public void EventChatMessage(Client client, string message)
        {
            if (!client.HasData(EntityData.Account))
                return;

            Client[] clients = NAPI.Pools.GetAllPlayers().FindAll(x => x.Position.DistanceTo2D(client.Position) <= 10).ToArray();

            for (int i = 0; i < clients.Length; i++)
            {
                if (!clients[i].Exists)
                    continue;

                clients[i].SendChatMessage($"{client.Name} says, \"{message}\"");
            }
        }
    }
}
