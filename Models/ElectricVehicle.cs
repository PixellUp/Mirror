using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Models
{
    public class ElectricVehicle
    {
        public static List<ElectricVehicle> ElectricVehicles = new List<ElectricVehicle>();

        public Vector3 LastPosition { get; set; }
        public Vehicle Vehicle { get; set; }
        public int Power { get; set; } = 100;

        public ElectricVehicle(Vehicle vehicle)
        {
            LastPosition = vehicle.Position;
            Vehicle = vehicle;
            ElectricVehicles.Add(this);
            Vehicle.SetData("ElectricVehicle", this);
        }

        public bool HasPower()
        {
            if (Power <= 0)
                return false;
            return true;
        }

        public void DepletePower()
        {
            if (Power <= 0)
                return;
            Power -= 1;
        }

        public bool HasVehicleMoved()
        {
            if (Vehicle.Position.DistanceTo2D(LastPosition) > 2)
            {
                LastPosition = Vehicle.Position;
                return true;
            }

            LastPosition = Vehicle.Position;
            return false;
        }
    }
}
