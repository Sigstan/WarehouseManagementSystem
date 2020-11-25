using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WEB.Entities
{
    public class Inventory : EntityBase
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Sector { get; set; }
        public DateTime StoredDateTime { get; set; }
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
