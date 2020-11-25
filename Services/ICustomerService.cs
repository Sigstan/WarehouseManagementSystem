using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagementSystem.WEB.Entities;
using WarehouseManagementSystem.WEB.Models;

namespace WarehouseManagementSystem.WEB.Services
{
    public interface ICustomerService
    {
       Task<bool> SaveCustomer(CustomerViewModel customerViewModel);
       Customer HandleViewToEntity(CustomerViewModel customerViewModel);
       Task <ListOfCustomersViewModel> GetAllCustomersViewModels();
       Task<ExtendedCustomerViewModel> GetCustomersDetailsViewModel(Guid customerId);
    }
}
