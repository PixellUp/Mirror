using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes.Static.StaticEvents
{
    public static class SkillEvents
    {
        // mp.events.callRemote("EventHandler", "Skill_Event", skillName, target);
        public static void ParseSkillEvent(Client client, params object[] arguments)
        {
            if (arguments.Length < 3) //0, 1, 2
                return;

            string eventName = arguments[0] as string;
            string skillName = arguments[1] as string;

            Vehicle vehicle = null;
            Client target = null;

            switch (skillName)
            {
                case "Medicine":
                    client = arguments[2] as Client;
                    Skills.Intelligence.Medicine.Use(client, target);
                    return;
                case "Drag":
                    // not yets
                    return;
                case "Smash":
                    vehicle = arguments[2] as Vehicle;
                    Skills.Strength.Smash.Use(client, vehicle);
                    return;
            }
        }
    }
}
