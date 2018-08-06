using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.EventManagement
{
    public class EventStationAssignment
    {
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public Guid EventStationId { get; set; }
        public EventStation EventStation { get; set; }
        public Guid EventTicketAdmissionTypeId { get; set; }
        public EventTicketAdmissionType EventTicketAdmissionType { get; set; }
        public EventStationControlType ControlType { get; set; }
    }
}
