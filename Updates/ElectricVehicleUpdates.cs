using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Mirror.Classes.Models;

namespace Mirror.Updates
{
    public class ElectricVehicleUpdates : Script
    {
        // About 10 Seconds for 5000.
        readonly int maxTicks = 5000;
        int ticks = 0;

        [ServerEvent(Event.Update)]
        public void EventOnUpdate()
        {
            if (ElectricVehicle.ElectricVehicles.Count <= 0)
                return;

            ticks += 1;

            if (ticks < maxTicks)
                return;

            ticks = 0;

            for (int i = 0; i < ElectricVehicle.ElectricVehicles.Count; i++)
            {
                if (ElectricVehicle.ElectricVehicles[i].HasVehicleMoved())
                    ElectricVehicle.ElectricVehicles[i].DepletePower();
            }
        }
    }
}
