using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.EventManagement
{
    public class EventTicketAdmissionType
    {
        public Guid EventTicketAdmissionTypeId { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
    }
}
