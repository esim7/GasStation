using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Fuel : Entity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Capacity { get; set; }
    }
}
