using GTANetworkAPI;
using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Jobs
{
    public class TestJob : Script
    {
        public static JobInfo jobInfo;

        public TestJob()
        {
            if (jobInfo != null)
                return;

            jobInfo = new JobInfo()
            {
                Identification = "TestJob1",
                Name = "Delivery Driver",
                Description = "Pickup and deliver the package to the set location.",
                Location = new Vector3(-392, 1189, 325),
                TextureName = ""
            };
        }

        public static void StartJob(Client client)
        {
            if (client.Position.DistanceTo2D(jobInfo.Location) > 3)
                return;

            Mission mission = new Mission();

            NetHandle vehicle = NAPI.Vehicle.CreateVehicle(VehicleHash.Burrito, new Vector3(), 0, 255, 255, "", 255, false, false);

            // 0
            Objective objective = new Objective
            {
                ID = 0,
                X = -396,
                Y = 1215,
                Z = 325,
                Progression = 0,
                Radius = 3,
                Type = "Retrieve Car"
            };

            NAPI.Entity.SetEntityPosition(vehicle, objective.GetLocation());
            objective.RequiredVehicles = new NetHandle[] { vehicle };
            mission.Objectives.Enqueue(objective);

            // 1
            objective = new Objective
            {
                ID = 0,
                X = -366,
                Y = 1259,
                Z = 329,
                Progression = 0,
                Radius = 3,
                Type = "Drive"
            };

            objective.RequiredVehicles = new NetHandle[] { vehicle };
            mission.Objectives.Enqueue(objective);

            // 2
            objective = new Objective
            {
                ID = 1,
                X = -324,
                Y = 1371,
                Z = 347,
                Progression = 0,
                Radius = 3,
                Type = "Drive"
            };

            objective.RequiredVehicles = new NetHandle[] { vehicle };
            mission.Objectives.Enqueue(objective);

            // 3
            objective = new Objective
            {
                ID = 2,
                X = -260,
                Y = 1554,
                Z = 336,
                Progression = 0,
                Radius = 3,
                Type = "Drive"
            };

            objective.RequiredVehicles = new NetHandle[] { vehicle };
            mission.Objectives.Enqueue(objective);

            // 4
            objective = new Objective
            {
                ID = 3,
                X = -122,
                Y = 1546,
                Z = 299,
                Progression = 0,
                Radius = 3,
                Type = "Drive"
            };

            objective.RequiredVehicles = new NetHandle[] { vehicle };
            mission.Objectives.Enqueue(objective);

            // 5
            objective = new Objective
            {
                ID = 4,
                X = 66,
                Y = 1411,
                Z = 263,
                Progression = 0,
                Radius = 3,
                Type = "Drive"
            };

            objective.RequiredVehicles = new NetHandle[] { vehicle };
            mission.Objectives.Enqueue(objective);

            // 6
            objective = new Objective
            {
                ID = 5,
                X = 234,
                Y = 1189,
                Z = 225,
                Progression = 0,
                Radius = 3,
                Type = "Drive"
            };

            objective.RequiredVehicles = new NetHandle[] { vehicle };
            mission.Objectives.Enqueue(objective);

            // 7
            objective = new Objective
            {
                ID = 5,
                X = 195,
                Y = 1237,
                Z = 225,
                Progression = 0,
                Radius = 3,
                Type = "Deliver Car"
            };

            objective.RequiredVehicles = new NetHandle[] { vehicle };
            mission.Objectives.Enqueue(objective);

            // 8
            objective = new Objective
            {
                ID = 5,
                X = 185,
                Y = 1212,
                Z = 225,
                Progression = 0,
                Radius = 3,
                Type = "Capture"
            };

            mission.Objectives.Enqueue(objective);

            mission.AddActivePlayer(client);
        }
    }
}
