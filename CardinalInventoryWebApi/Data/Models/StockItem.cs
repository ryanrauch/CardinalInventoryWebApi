using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.Models
{
    public class StockItem
    {
        public Guid StockItemId { get; set; }
        public string Description { get; set; }
        public Decimal UnitPrice { get; set; }
    }
}
