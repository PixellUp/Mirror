using GTANetworkAPI;
using Mirror.Classes.Models;
using Mirror.Events;
using Mirror.Jobs;

using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Handler
{
    public class JobHandler : Script
    {
        public static JobEvent JobEvent = new JobEvent();

        public JobHandler()
        {
            JobEvent.JobEventTrigger += JobStartTrigger;
        }

        private void JobStartTrigger(object source, Client client, string jobID)
        {
            // Remove player from current team to start a new one.
            if (client.HasData("Mission_Active"))
            {
                if ((client.GetData("Mission_Active") is Mission mission))
                {
                    mission.RemoveActivePlayer(client);
                }
            }

            if (!client.HasData("Mission_Cooldown"))
                client.SetData("Mission_Cooldown", DateTime.Now);

            DateTime lastClientTime = client.GetData("Mission_Cooldown");

            if (DateTime.Compare(DateTime.Now, lastClientTime) <= 0)
            {
                client.SendChatMessage("Please wait a moment before starting a new mission...");
                return;
            }

            client.SetData("Mission_Cooldown", DateTime.Now.AddSeconds(25));


            // Check through registered jobs to determine where our job starting point will be.
            switch (jobID.ToLower())
            {
                case "testjob1":
                    TestJob.StartJob(client);
                    break;
            }
        }
    }
}
