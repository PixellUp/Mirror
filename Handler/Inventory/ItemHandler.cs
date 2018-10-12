using GTANetworkAPI;
using Skillsheet = Mirror.Skills.Skills;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Classes.Models;
using Mirror.Classes.Static;
using Mirror.Levels;
using Mirror.Globals;
using Mirror.Classes.Models.Player;
using Newtonsoft.Json;
using Mirror.Utility;

namespace Mirror.Handler
{
    public static class ItemHandler
    {
        /// <summary>
        /// Heal the player for the specified amount.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static bool Heal(Client client, int amount)
        {
            if (client.Health >= 100)
            {
                client.SendNotification("You're already at full health.");
                return false;
            }

            if (client.Health + amount > 100)
            {
                client.Health = 100;
                client.SendNotification("You have reached maximum health.");
                return true;
            }
                
            client.Health += amount;
            client.SendNotification($"You were healed for {amount}."); 
            return true;
        }

        /// <summary>
        /// Add armor to the player for the specific amount.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static bool Armor(Client client, int amount)
        {
            if (client.Armor >= 100)
            {
                client.SendNotification("You already have maximum armor.");
                return false;
            }

            if (client.Armor + amount > 100)
            {
                client.Armor = 100;
                client.SendNotification("You have reached maximum armor.");
                return true;
            }

            client.Armor += amount;
            client.SendNotification($"You gained {amount} armor.");
            return true;
        }

        public static void Drunk(Client client, int time)
        {
            client.TriggerEvent("ScreenEffect", "Drunk", time);
        }

        /// <summary>
        /// Resets the modifiers of the client completely.
        /// </summary>
        /// <param name="client"></param>
        public static void RestoreStats(Client client)
        {
            if (!(client.GetData(EntityData.Skills) is Skillsheet skillsheet))
                return;

            if (!(client.GetData(EntityData.Account) is Account account))
                return;

            skillsheet.RestoreModifiers(client);
            skillsheet.Update(client);
            client.TriggerEvent("eventCreatePlayerNotification", $"Stats Restored");
        }

        public static bool Weapon(Client client, string name)
        {
            LevelRanks levelRanks = AccountUtil.GetLevelRanks(client);
            WeaponHash hash = NAPI.Util.WeaponNameToModel(name);

            if (Array.IndexOf(WeaponNamesData.AssaultWeapons, name.ToLower()) >= 0)
            {
                if (levelRanks.MediumWeaponry <= 0)
                {
                    client.SendChatMessage("~o~You are unable to wield this weapon type: ~y~Medium");
                    Utilities.PlaySoundFrontend(client, "ERROR", "HUD_FRONTEND_DEFAULT_SOUNDSET");
                    return false;
                }
            }

            if (Array.IndexOf(WeaponNamesData.ShotgunWeapons, name.ToLower()) >= 0)
            {
                if (levelRanks.MediumWeaponry <= 0)
                {
                    client.SendChatMessage("~o~You are unable to wield this weapon type: ~y~Medium");
                    Utilities.PlaySoundFrontend(client, "ERROR", "HUD_FRONTEND_DEFAULT_SOUNDSET");
                    return false;
                }
            }

            if (Array.IndexOf(WeaponNamesData.SmgWeapons, name.ToLower()) >= 0)
            {
                if (levelRanks.LightWeaponry <= 0)
                {
                    client.SendChatMessage("~o~You are unable to wield this weapon type: ~y~Light");
                    Utilities.PlaySoundFrontend(client, "ERROR", "HUD_FRONTEND_DEFAULT_SOUNDSET");
                    return false;
                }
            }

            if (Array.IndexOf(WeaponNamesData.HeavyWeapons, name.ToLower()) >= 0)
            {
                if (levelRanks.HeavyWeaponry <= 0)
                {
                    client.SendChatMessage("~o~You are unable to wield this weapon type: ~y~Heavy");
                    Utilities.PlaySoundFrontend(client, "ERROR", "HUD_FRONTEND_DEFAULT_SOUNDSET");
                    return false;
                }
            }

            // Try adding the weapon to the player.
            if (!AccountUtil.AddPlayerWeapon(client, hash))
                return false;

            Utilities.PlaySoundFrontend(client, "PICK_UP_WEAPON", "HUD_FRONTEND_CUSTOM_SOUNDSET");
            client.SendNotification("A weapon may be unequipped into your inventory by pressing ~o~R~w~.");
            return true;
        }

        public static void TopOutfit(Client client, InventoryItem item)
        {
            Account account = AccountUtil.RetrieveAccount(client);
            Clothing clothing = Clothing.RetrieveClothing(account);

            TopOutfit topOutfit = JsonConvert.DeserializeObject<TopOutfit>(item.Properties);

            if (topOutfit == null)
                return;

            InventoryItem oldOutfit = new InventoryItem
            {
                ID = 0,
                Name = $"TopOutfit{new Random().Next(0, 999)}",
                StackCount = 1
            };

            oldOutfit.CreateTopOutfit(
                clothing.Mask,
                clothing.Undershirt,
                clothing.Torso,
                clothing.Top,
                clothing.Hats,
                clothing.Glasses
            );

            topOutfit.Equip(clothing);
            clothing.Update();
            clothing.UpdateClothing(client);

            Utilities.ForceCloseInventory(client);
            NAPI.Task.Run(() =>
            {
                InventoryHandler.AddItemToInventory(client, oldOutfit.Name, 1, oldOutfit);
            }, 1000);
        }
    }
}
