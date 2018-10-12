using GTANetworkAPI;
using Mirror.Handler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.StaticEvents
{
    public static class JobEvents
    {
        public static void StartJob(Client client, params object[] args)
        {
            if (args[1] == null)
                return;

            JobHandler.JobEvent.Trigger(client, args[1] as string);
        }
    }
}
