using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using WarehouseManagementSystem.WEB.Enum;

namespace WarehouseManagementSystem.WEB.Entities
{
    public class Customer : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public ClientType ClientType { get; set; }

        public List<Inventory> Inventories { get; set; }
    }
}
