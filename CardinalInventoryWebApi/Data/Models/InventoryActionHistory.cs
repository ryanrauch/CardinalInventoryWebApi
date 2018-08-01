using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.Models
{
    public class InventoryActionHistory
    {
        public Guid InventoryActionHistoryId { get; set; }
        public Guid AreaId { get; set; }
        public Area Area { get; set; }
        public Guid SerializedStockItemId { get; set; }
        public SerializedStockItem SerializedStockItem { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime Timestamp { get; set; }
        public Decimal ItemLevel { get; set; }
        public InventoryAction Action { get; set; }
    }
}
