using GTANetworkAPI;
using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Handler
{
    public static class ItemHandler
    {
        public static void Heal(Client client, int amount)
        {
            if (client.Health < 100)
                client.Health += amount;

            if (client.Health > 100)
                client.Health = 100;

            client.TriggerEvent("eventCreatePlayerNotification", $"{amount} Health");
        }

        public static void Armor(Client client, int amount)
        {
            if (client.Armor < 100)
                client.Armor += amount;

            if (client.Armor > 100)
                client.Armor = 100;

            client.TriggerEvent("eventCreatePlayerNotification", $"{amount} Armor");
        }

        public static void Drunk(Client client, int time)
        {
            client.TriggerEvent("ScreenEffect", "Drunk", time);
        }

        public static void RestoreStats(Client client)
        {
            if (!(client.GetData("Mirror_Skills") is Skills skillsheet))
                return;

            skillsheet.RestoreModifiers(client);
            skillsheet.Update();
            client.TriggerEvent("eventCreatePlayerNotification", $"Stats Restored");
        }

        public static void Weapon(Client client, string name)
        {
            WeaponHash hash = NAPI.Util.WeaponNameToModel(name);

            client.GiveWeapon(hash, 0);
        }
    }
}
