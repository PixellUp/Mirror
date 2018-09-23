using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes.Models.Player
{
    public class Scatter
    {
        public string Hash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PubKey { get; set; }

        public string GetAsJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
