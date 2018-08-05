using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi.Data.Models
{
    public class Bar
    {
        public Guid BarId { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
