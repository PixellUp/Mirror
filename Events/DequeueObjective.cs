using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public static class DequeueObjective
    {
        public static void Event(Mission mission)
        {
            mission.UpdateObjectives();
        }
    }
}
