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
            if (!client.Exists)
                return;

            if (!target.Exists)
                return;

            if (client == target)
            {
                PlayerEvents.CancelAttack(client);
                return;
            }

            if (weaponName == "")
                return;

            int WeaponRange = Weapons.GetWeaponRange(weaponName);
            float DistanceBetweenTargets = client.Position.DistanceTo(target.Position);

            // If it's too far there's no point in rolling.
            if (DistanceBetweenTargets > WeaponRange + 20)
            {
                return;
            }

            // Ternary Op - If the distance is greater than the weapon range return the distance between the targets. If they're in range set the penalty to zero.
            int RangePenalty = (DistanceBetweenTargets > WeaponRange) ? Convert.ToInt32((DistanceBetweenTargets - WeaponRange)) : 0;

            if (weaponName == "Unarmed")
            {
                if (!Skillcheck.SkillCheckPlayers(client, target, Skillcheck.Skills.strength, clientModifier: RangePenalty))
                {
                    target.TriggerEvent("eventLastDamage", 0);
                    client.TriggerEvent("eventTargetDamage", 0);
                    return;
                }

                int meleeDie = Weapons.GetWeaponDamageDie(weaponName);
                int meleeDamage = Skills.Utility.RollDamage(meleeDie);

                target.Health -= meleeDamage;

                if (target.Health <= 0)
                    PlayerEvents.CancelAttack(client);

                target.TriggerEvent("eventLastDamage", meleeDamage);
                client.TriggerEvent("eventTargetDamage", meleeDamage);
                return;
            }


            if (!client.IsAiming)
            {
                PlayerEvents.CancelAttack(client);
                return;
            }

            Account account = client.GetData("Mirror_Account");
            LevelRanks levelRanks = JsonConvert.DeserializeObject<LevelRanks>(account.LevelRanks);
            LevelRankCooldowns levelRankCooldowns = AccountUtil.GetCooldowns(client);

            if (account.IsDead)
            {
                PlayerEvents.CancelAttack(client);
                return;
            }

            bool skipCheck = false;

            // Calculated Check
            if (levelRanks.Calculated > 0)
            {
                // If ready skip the accuracy check and roll for damage.
                if (levelRankCooldowns.IsCalculatedReady)
                {
                    levelRankCooldowns.IsCalculatedReady = false;
                    skipCheck = true;
                    client.SendChatMessage("~b~Calculated ~w~Your shot hit with 100% Accuracy.");
                }
            }

            // Check if the player beats the other's score.
            if (!skipCheck)
            {
                if (!Skillcheck.SkillCheckPlayers(client, target, Skillcheck.Skills.endurance, clientModifier: RangePenalty))
                {
                    target.TriggerEvent("eventLastDamage", 0);
                    client.TriggerEvent("eventTargetDamage", 0);
                    return;
                }
            }
            
            int weaponDie = Weapons.GetWeaponDamageDie(weaponName);
            int weaponRollCount = Weapons.GetWeaponRollCount(weaponName);

            int amountOfDamage = 0;
            
            if (weaponRollCount == 0)
            {
                amountOfDamage = Skills.Utility.RollDamage(weaponDie);
            } else {
                for (int i = 0; i < weaponRollCount; i++)
                {
                    amountOfDamage += Skills.Utility.RollDamage(weaponDie);
                }
            }

            // Double Damage Skill
            if (levelRanks.Concentrate > 0)
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
            Account targetAccount = target.GetData("Mirror_Account");
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
