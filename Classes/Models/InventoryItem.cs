using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes.Models
{
    public class InventoryItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int StackCount { get; set; } = 1;
    }
}
