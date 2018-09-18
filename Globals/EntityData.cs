using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Globals
{
    public static class EntityData
    {
        // Account Related
        public static readonly string Account = "Mirror_Account";
        public static readonly string Appearance = "Mirror_Appearance";
        public static readonly string Clothing = "Mirror_Clothing";
        public static readonly string Skills = "Mirror_Skills";
        public static readonly string Attack = "Mirror_Attack";
        public static readonly string DeathTime = "Mirror_Death_Time";
        public static readonly string Cooldowns = "Mirror_Cooldowns";

        // Ticks
        public static readonly string CurrentTick = "Mirror_Tick";

        // Mission Related
        public static readonly string ActiveMission = "Mission_Active";
        public static readonly string MissionCooldown = "Mission_Cooldown";

        // Electric Vehicles
        public static readonly string Vehicle_Electric = "Vehicle_Electric";
        public static readonly string Vehicle_Headlights = "Vehicle_Headlights";
    }

    public static class EntitySharedData
    {
        public static readonly string IsPlayerDowned = "IsPlayerDowned";
    }
}
