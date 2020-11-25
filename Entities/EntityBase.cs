using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WEB.Entities
{
    public class EntityBase : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    }
}
