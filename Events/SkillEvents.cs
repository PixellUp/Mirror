using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
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
            Client target = arguments[2] as Client;

            switch (skillName)
            {
                case "Medicine":
                    Skills.Intelligence.Medicine.Use(client, target);
                    return;
                case "Drag":
                    // not yet
                    return;
            }
        }
    }
}
