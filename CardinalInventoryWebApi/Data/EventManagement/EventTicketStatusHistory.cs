using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.EventManagement
{
    public class EventTicketStatusHistory
    {
        public Guid EventTicketStatusHistoryId { get; set; }
        public Guid EventTicketId { get; set; }
        public EventTicket EventTicket { get; set; }
        public Guid EventTicketAdmissionTypeId { get; set; }
        public EventTicketAdmissionType EventTicketAdmissionType { get; set; }
        public Guid EventStationId { get; set; }
        public EventStation EventStation { get; set; }
        public DateTime TimeStamp { get; set; }
        public EventStationControlType EventStationControlType { get; set; }
        public EventStationProcessResult EventStationProcessResult { get; set; }
    }
}
