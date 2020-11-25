using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WEB.Models
{
    public class ExtendedCustomerViewModel : CustomerViewModel
    {
        [Display(Name = "Registered inventory")]
        public int RegisteredInventory { get; set; }  
        public List<InventoryViewModel> Inventory { get; set; }  
    }
}
