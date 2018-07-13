using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.Models
{
    public class InventoryHistory
    {
        public Guid InventoryHistoryId { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid AreaId { get; set; }
        public Area Area { get; set; }
        public Guid StockItemId { get; set; }
        public StockItem StockItem { get; set; }
        public Decimal Quantity { get; set; }
    }
}
