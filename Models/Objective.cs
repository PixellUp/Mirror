using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Models
{
    public class Objective
    {
        public int ID { get; set; } // The order of the objective.
        public string Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int TimeLimit { get; set; }
        public int Radius { get; set; } // Get the radius.
        public int Progression { get; set; } // Used to tell if the Objective is complete.
        public NetHandle[] RequiredVehicles { get; set; } = new NetHandle[] { };

        /// <summary>
        /// Get the location of this objective.
        /// </summary>
        /// <returns></returns>
        public Vector3 GetLocation()
        {
            return new Vector3(X, Y, Z);
        }

        /// <summary>
        /// Determine if the player is close enough to the objective.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool IsPlayerCloseEnough(Client client)
        {
            if (client.Position.DistanceTo(GetLocation()) <= Radius)
                return true;
            return false;
        }

        /// <summary>
        /// Determine if the objective has reached 100 progression.
        /// </summary>
        /// <returns></returns>
        public bool IsObjectiveComplete()
        {
            if (Progression < 100)
                return false;
            return true;
        }
    }
}
