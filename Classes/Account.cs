using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes
{
    public class Account : StandardData
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public Clothing Clothing { get; set; }
        public Appearance Appearance { get; set; }

        public Account()
        {

        }
    }
}
