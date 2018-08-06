using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.EventManagement
{
    public class EventTicketHistory
    {
        public Guid EventTicketHistoryId { get; set; }
        public Guid EventTicketId { get; set; }
        public string ColumnChanged { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid ApplicationUserId { get; set; }
    }
}
