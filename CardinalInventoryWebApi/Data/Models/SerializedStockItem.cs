using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.Models
{
    public class SerializedStockItem
    {
        public Guid SerializedStockItemId { get; set; }
        public Guid StockItemId { get; set; }
        public StockItem StockItem { get; set; }
        public string Barcode { get; set; }
        public Decimal UnitCost { get; set; }
        public Decimal CurrentItemLevel { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public Guid AreaId { get; set; }
        public Area Area { get; set; }
    }
}
