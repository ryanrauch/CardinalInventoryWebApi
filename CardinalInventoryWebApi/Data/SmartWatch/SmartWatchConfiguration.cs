using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.SmartWatch
{
    public class SmartWatchConfiguration
    {
        public Guid SmartWatchConfigurationId { get; set; }
        public string Description { get; set; }
        public double AttitudePitchStart { get; set; }
        public double AttitudePitchStop { get; set; }
        public double AttitudeRollStart { get; set; }
        public double AttitudeRollStop { get; set; }
        public double AttitudeYawStart { get; set; }
        public double AttitudeYawStop { get; set; }
    }
}
