using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.EventManagement
{
    public class EventTicketStatus
    {
        public Guid EventTicketId { get; set; }
        public EventTicket EventTicket { get; set; }
        public Guid EventTicketAdmissionTypeId { get; set; }
        public EventTicketAdmissionType EventTicketAdmissionType { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
