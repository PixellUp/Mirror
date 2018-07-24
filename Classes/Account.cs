using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes
{
    public class Account : StandardData
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int Age { get; set; } = 0;
        public string Gender { get; set; } = "Male";
        public string Description { get; set; } = "";
        public bool Banned { get; set; } = false;
        public Clothing Clothing { get; set; }
        public Appearance Appearance { get; set; }

        public Account()
        {

        }
    }
}
