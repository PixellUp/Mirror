using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Updates
{
    public class AttackUpdates : Script
    {
        int ticks = 0;
        int maxTicks = 3000;

        [ServerEvent(Event.Update)]
        public void UpdateAttack()
        {
            ticks += 1;

            if (ticks < maxTicks)
                return;

            ticks = 0;

            Console.WriteLine("Tick");
        }
    }
}
