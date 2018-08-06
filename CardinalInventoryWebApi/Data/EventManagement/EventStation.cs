using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.EventManagement
{
    public class EventStation
    {
        public Guid EventStationId { get; set; }
        public string Description { get; set; }
        public EventStationHardware Hardware { get; set; }
    }
}
