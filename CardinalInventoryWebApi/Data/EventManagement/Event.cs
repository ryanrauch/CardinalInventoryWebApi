using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.EventManagement
{
    public class Event
    {
        public Guid EventId { get; set; }
        public string Description { get; set; }
    }
}
