using GTANetworkAPI;
using Mirror.Events;
using Mirror.Levels;
using Mirror.Models;
using Mirror.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Skills.Intelligence
{
    public class Electric : Script
    {
        private readonly string VariableName = "IsElectricReady";
        private readonly string Notification = "Notification";

        public Electric()
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

            if (levelRanks.Electric <= 0)
                return;

            LevelRankCooldowns levelRankCooldowns = AccountUtilities.GetCooldowns(client);
            levelRankCooldowns.UpdateCooldownTime(client, VariableName, SkillCooldowns.Electric);

            if (!levelRankCooldowns.IsElectricReady)
            {
                client.SetData(VariableName + Notification, false);
                return;
            }

            if (client.IsInVehicle)
            {
                // Check if the vehicle is electric.
                if (!client.Vehicle.HasData("ElectricVehicle"))
                    return;

                // Get the electric vehicle class.
                if (!(client.GetData("ElectricVehicle") is ElectricVehicle electricVehicle))
                    return;
                
                // If the electric vehicle's power is greater than 100. Don't try recharging.
                if (electricVehicle.Power > 100)
                    return;

                // If the electric vehicle has less than 100 power. Add some power based on ranks put into Electric.
                levelRankCooldowns.IsElectricReady = false;
                electricVehicle.Power += levelRanks.Electric;
                client.SendChatMessage("~b~Electric ~w~This vehicle has recieved a little more power.");
            }

            // Has the notification been sent.
            if (client.GetData(VariableName + Notification))
                return;

            client.SetData(VariableName + Notification, true);
            client.SendChatMessage("~b~Electric ~w~You will recharge a vehicle slightly when you enter it.");
        }
    }
}
