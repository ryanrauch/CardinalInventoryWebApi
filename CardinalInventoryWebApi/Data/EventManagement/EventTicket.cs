using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.EventManagement
{
    public class EventTicket
    {
        public Guid EventTicketId { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public Guid EventTicketAdmissionTypeId { get; set; }
        public EventTicketAdmissionType EventTicketAdmissionType { get; set; }
        public string UniqueIdentifier { get; set; }
        public bool Enabled { get; set; }
        public Guid EventCustomerId { get; set; }
        public EventCustomer EventCustomer { get; set; }
    }
}
