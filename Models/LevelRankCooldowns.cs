using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Models
{
    public class LevelRankCooldowns
    {
        // STR
        public bool IsSmashReady { get; set; } = false;
        public bool IsIntimidateReady { get; set; } = false;
        public bool IsDragReady { get; set; } = false;
        public bool IsDownerReady { get; set; } = false;
        public bool IsBruteReady { get; set; } = false;

        // END
        public bool IsDeadeyeReady { get; set; } = false;
        public bool IsQuickReady { get; set; } = false;
        public bool IsHighJumpReady { get; set; } = false;
        public bool IsConcentrateReady { get; set; } = false;
        public bool IsPerceptionReady { get; set; } = false;

        // INT
        public bool IsMedicineReady { get; set; } = false;
        public bool IsCrowdControlReady { get; set; } = false;
        public bool IsRegenerateReady { get; set; } = false;
        public bool IsElectricReady { get; set; } = false;
        public bool IsCalculatedReady { get; set; } = false;
        public bool IsLockpickReady { get; set; } = false;
        public bool IsVehicleSenseReady { get; set; } = false;
        public bool IsSickSenseReady { get; set; } = false;

        // CHA
        public bool IsDisguiseReady { get; set; } = false;
        public bool IsAgendaReady { get; set; } = false;
        public bool IsLeadershipReady { get; set; } = false;
        public bool IsPersuasionReady { get; set; } = false;
        public bool IsHiddenReady { get; set; } = false;
        public bool IsTransparentReady { get; set; } = false;
        public bool IsFakeoutReady { get; set; } = false;
        public bool IsBrainsReady { get; set; } = false;
        public bool IsAttentionReady { get; set; } = false;

        public static readonly string VariableName = "Mirror_LevelRank_Cooldowns";

        public static LevelRankCooldowns GetCooldowns(Client client)
        {
            if (!client.HasData(VariableName))
                client.SetData(VariableName, new LevelRankCooldowns());

            return client.GetData(VariableName) as LevelRankCooldowns;
        }

        public bool UpdateCooldownTime(Client client, string variableName, int secondsOnCooldown)
        {
            if (!client.HasData(variableName))
                client.SetData(variableName, DateTime.Now.AddSeconds(secondsOnCooldown));

            DateTime clientTime = client.GetData(variableName);

            if (DateTime.Compare(DateTime.Now, clientTime) <= 0)
                return false;

            client.SetData(variableName, DateTime.Now.AddSeconds(secondsOnCooldown));
            foreach (var property in GetType().GetProperties())
            {
                if (property.Name.ToLower() == variableName.ToLower())
                {
                    property.SetValue(this, true);
                    break;
                }
                    
            }
            return true;
        }
    }
}
