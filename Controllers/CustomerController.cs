using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WarehouseManagementSystem.WEB.Models;
using WarehouseManagementSystem.WEB.Services;

namespace WarehouseManagementSystem.WEB.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _logger = logger;
            _customerService = customerService;
        }
       
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel customerViewModel)
        {
            var isSaved = false;
            if (ModelState.IsValid)
            {
              isSaved = await _customerService.SaveCustomer(customerViewModel);
              _logger.LogInformation($"Created new customer {customerViewModel.FirstName} {customerViewModel.LastName}");
            }

            if (!isSaved)
            {
                TempData["Error"] = "User exists or something else went wrong";
                _logger.LogInformation($"Could not Create new customer {customerViewModel.FirstName} {customerViewModel.LastName}");
                return RedirectToAction("Create");
            }

            return RedirectToAction("List");
        }
        public async Task<IActionResult> List()
        {
           var customers = await _customerService.GetAllCustomersViewModels();

            return View(customers);
        } 
        public async Task<IActionResult> Details(Guid id)
        {
           var customer = await _customerService.GetCustomersDetailsViewModel(id);

            return View(customer);
        }
        
    }
}
