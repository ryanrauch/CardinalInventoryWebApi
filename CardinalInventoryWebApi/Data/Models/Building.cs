using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.Models
{
    public class Building
    {
        public Guid BuildingId { get; set; }
        public string Description { get; set; }
        public Guid BarId { get; set; }
        public Bar Bar { get; set; }
        public bool Active { get; set; }
    }
}
