using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.SmartWatch
{
    public class PourSpout
    {
        public Guid PourSpoutId { get; set; }
        public string Description { get; set; }
        public double DurationForOneLiter { get; set; } //Seconds
        public string ImagePath { get; set; }
    }
}
