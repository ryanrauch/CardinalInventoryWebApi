using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.EventManagement.Contracts
{
    public class EventTicketScanContract
    {
        public Guid EventStationId { get; set; }
        public string TicketUID { get; set; } // mapped to EventTicket.UniqueIdentifier
    }
}
