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
        public Guid EventTicketAdmissionTypeId { get; set; } // The type of ticket to Check for when scanning
        public EventTicketAdmissionType EventTicketAdmissionType { get; set; }
        public Guid GateEventTicketAdmissionTypeId { get; set; } // The type of area permitting entrance/exit from [ie: when scanning VIP ticket at G.A. Entrance from separate queue]
        public EventTicketAdmissionType GateEventTicketAdmissionType { get; set; }
        public EventStationControlType ControlType { get; set; }
    }
}
