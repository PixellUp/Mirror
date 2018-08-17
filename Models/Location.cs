using GTANetworkAPI;
using LiteDbWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Models
{
    public class Location : StandardData
    {
        public string Type { get; set; } = "None";
        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;
        public float Z { get; set; } = 0;
        public float Radius { get; set; } = 5;

        public Vector3 GetPosition()
        {
            return new Vector3(X, Y, Z);
        }

        public static Location CreatePosition(Client client, string type, int radius)
        {
            Location location = new Location
            {
                Type = type,
                Radius = radius,
                X = client.Position.X,
                Y = client.Position.Y,
                Z = client.Position.Z
            };

            Database.Upsert(location);

            return location;
        }
    }
}
