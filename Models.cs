using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class CityCoordinateModel
    {
        public String name { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public String country { get; set; }
        public String state { get; set; }

        public override string ToString()
        {
            return name + " " + lat + " " + lon;
        }
    }
}
