using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes.Models
{
    public class JobInfo
    {
        public static List<JobInfo> JobInformation = new List<JobInfo>();

        public string Identification { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TextureName { get; set; }
        public Vector3 Location { get; set; }

        public JobInfo()
        {
            JobInformation.Add(this);
        }
    }
}
