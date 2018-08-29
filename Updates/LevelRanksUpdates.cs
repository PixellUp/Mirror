using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Updates
{
    public class LevelRanksUpdates : Script
    {
        // About 10 Seconds for 5000.
        readonly int maxTicks = 2500;
        int ticks = 0;

        [ServerEvent(Event.Update)]
        public void EventOnUpdate()
        {
            if (NAPI.Pools.GetAllPlayers().Count <= 0)
                return;

            ticks += 1;

            if (ticks < maxTicks)
                return;

            ticks = 0;
            Events.RankEvents.UpdateAllPlayerPassives();
        }
    }
}
