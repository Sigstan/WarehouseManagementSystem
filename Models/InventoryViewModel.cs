using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WEB.Models
{
    public class InventoryViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        [Range(1, 40)]
        public int Sector { get; set; }
        [Display(Name = "Stored date")]
        [Required]
        public DateTime StoredDateTime { get; set; }

        public Guid CustomerId { get; set; }
        public Guid Id { get; set; }
    }
}
