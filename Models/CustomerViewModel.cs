using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WarehouseManagementSystem.WEB.Enum;

namespace WarehouseManagementSystem.WEB.Models
{
    public class CustomerViewModel
    {
        [Display(Name = "Firstname")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Lastname")]
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Display(Name = "Phone number")]
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Display(Name = "Client type")]
        [Required]
        public ClientType ClientType { get; set; }
        public Guid Id { get; set; }
    }
}
