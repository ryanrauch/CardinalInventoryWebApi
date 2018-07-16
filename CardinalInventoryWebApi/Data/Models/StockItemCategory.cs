using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.Models
{
    public class StockItemCategory
    {
        public Guid StockItemCategoryId { get; set; }
        public string Description { get; set; }
    }
}
