using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Misc
{
    public class Greeter : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        public void PlayerConnected(Client client)
        {
            client.SendChatMessage(Settings.Settings.StartupMessage);
        }
    }
}
