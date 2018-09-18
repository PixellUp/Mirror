using GTANetworkAPI;
using Mirror.Events;
using Mirror.Handler;
using Mirror.Levels;

using Mirror.Skills;
using Mirror.Updates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Classes.Static;
using Mirror.Classes.Models;
using Mirror.Classes.Static.StaticEvents;
using Mirror.Skills.Intelligence;
using Mirror.Skills.Endurance;
using Mirror.Globals;

namespace Mirror
{
    public class WeaponDamageHandler : Script
    {
        public WeaponDamageHandler()
        {
            AttackUpdates.AttackEvent.AttackEventTrigger += RecieveClientAttackData;
        }

        private void RecieveClientAttackData(object source, Client client, Client target, string weaponName)
        {
            // Basic Failures. Just make sure there's a weapon and such.
            if (!client.Exists || !target.Exists || weaponName == "")
                return;

            if (client == target || !client.IsAiming)
            {
                PlayerEvents.CancelAttack(client);
                return;
            }

            int WeaponRange = Weapons.GetWeaponRange(weaponName);
            float DistanceBetweenTargets = client.Position.DistanceTo(target.Position);

            // If it's too far there's no point in rolling.
            if (DistanceBetweenTargets > WeaponRange + 20)
                return;

            // Ternary Op - If the distance is greater than the weapon range return the distance between the targets. If they're in range set the penalty to zero.
            int RangePenalty = (DistanceBetweenTargets > WeaponRange) ? Convert.ToInt32((DistanceBetweenTargets - WeaponRange)) : 0;

            /*
            if (weaponName == "Unarmed")
            {
                if (!Skillcheck.SkillCheckPlayers(client, target, Skillcheck.Skills.strength, clientModifier: RangePenalty))
                {
                    target.TriggerEvent("eventLastDamage", 0);
                    client.TriggerEvent("eventTargetDamage", 0);
                    return;
                }

                int meleeDie = Weapons.GetWeaponDamageDie(weaponName);
                int meleeDamage = Utility.RollDamage(meleeDie);

                target.Health -= meleeDamage;

                if (target.Health <= 0)
                    PlayerEvents.CancelAttack(client);

                target.TriggerEvent("eventLastDamage", meleeDamage);
                client.TriggerEvent("eventTargetDamage", meleeDamage);
                return;
            }
            */

            Account account = AccountUtil.RetrieveAccount(client);
            LevelRanks clientLevelRanks = AccountUtil.GetLevelRanks(client);

            LevelRankCooldowns levelRankCooldowns = AccountUtil.GetCooldowns(client);
            bool skipCheck = false;
            int deadeyeBonus = 0;

            // The target player's defense bonus.
            int targetDefenseBonus = 0;
            targetDefenseBonus = Quick.Use(target, targetDefenseBonus);

            if (account.IsDead)
            {
                PlayerEvents.CancelAttack(client);
                return;
            }

            // Calculated Skill Check
            if (Calculated.Use(client))
                skipCheck = true;

            // Use Deadeye if Calculated wasn't triggered.
            if (Deadeye.Use(client) && !skipCheck)
                deadeyeBonus = clientLevelRanks.Deadeye;

            // Check if the player beats the other's score.
            if (!skipCheck)
            {
                if (!Skillcheck.SkillCheckPlayers(client, target, Skillcheck.Skills.endurance, clientModifier: (RangePenalty + deadeyeBonus), targetModifier: targetDefenseBonus))
                {
                    target.TriggerEvent("eventLastDamage", 0);
                    client.TriggerEvent("eventTargetDamage", 0);
                    return;
                }
            }
            
            // Get the weapon dice and roll count for the damage calculation.
            int weaponDie = Weapons.GetWeaponDamageDie(weaponName);
            int weaponRollCount = Weapons.GetWeaponRollCount(weaponName);

            // Roll for damage.
            int amountOfDamage = 0;
            for (int i = 0; i < weaponRollCount; i++)
                amountOfDamage += Utility.RollDamage(weaponDie);

            // Double damage if concentrate is available.
            amountOfDamage = Concentrate.Use(client, amountOfDamage);

            // Add fisticuffs damage if they're unarmed.
            amountOfDamage += weaponName.ToLower() == "unarmed" ? clientLevelRanks.Fisticuffs : 0;
        
            // Double Damage Skill
            if (clientLevelRanks.Concentrate > 0)
            {
                if (levelRankCooldowns.IsConcentrateReady)
                {
                    amountOfDamage *= 2;
                    levelRankCooldowns.IsConcentrateReady = false;
                    client.SendChatMessage("~g~Concentrate ~w~Your shot hit for ~r~DOUBLE ~w~damage.");
                }
            }

            if (target.Health - amountOfDamage <= 0)
            {
                target.Health = 1;
            } else {
                target.Health -= amountOfDamage;
            }

            // Update Health
            Account targetAccount = target.GetData(EntityData.Account);
            Account.PlayerUpdateEvent.Trigger(target, targetAccount);
            
            target.TriggerEvent("eventLastDamage", amountOfDamage);
            client.TriggerEvent("eventTargetDamage", amountOfDamage);

            if (target.Health > 2)
                return;

            PlayerEvents.CancelAttack(client);
            DeathHandler.DeathEvent.Trigger(target, client); // Raise Death Event
        }
    }
}
