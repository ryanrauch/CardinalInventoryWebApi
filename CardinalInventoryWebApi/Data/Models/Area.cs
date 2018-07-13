using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.Models
{
    public class Area
    {
        public Guid AreaId { get; set; }
        public string Description { get; set; }
        public Guid BuildingId { get; set; }
        public Building Building { get; set; }
        public bool Active { get; set; }
    }
}
