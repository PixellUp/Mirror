using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Models;
using Newtonsoft.Json;

namespace Mirror.Events
{
    public static class PushAppearanceChanges
    {
        public static void Event(Client client, params object[] args)
        {
            if (!client.HasData("Mirror_Appearance"))
                return;

            if (!(client.GetData("Mirror_Appearance") is Appearance app))
                return;

            client.TriggerEvent("eventCreatePlayerNotification", $"Appearance Updated");

            app = JsonConvert.DeserializeObject<Appearance>(args[1] as string);
            app.Update();
            app.UpdateAppearance(client);
        }
    }
}
