using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WarehouseManagementSystem.WEB.Models
{
    public class Top5CustomersViewModel
    {
        public List<TopCustomerViewModel> TopCustomers;
    }

    public class TopCustomerViewModel
    {
        public Guid Name { get; set; }
        [Display(Name = "Total Registrations")]
        public int TotalRegistrations { get; set; }
    }
}
