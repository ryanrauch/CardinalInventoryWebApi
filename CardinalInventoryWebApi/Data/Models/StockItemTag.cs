using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.Models
{
    public class StockItemTag
    {
        public Guid StockItemTagId { get; set; }
        public Guid StockItemId { get; set; }
        public StockItem StockItem { get; set; }
        public string Tag { get; set; }
    }
}
