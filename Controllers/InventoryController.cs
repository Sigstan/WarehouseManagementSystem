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
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;
        private readonly ILogger<InventoryController> _logger;
        public InventoryController(IInventoryService inventoryService, ILogger<InventoryController> logger)
        {
            _logger = logger;
            _inventoryService = inventoryService;
        }
        public IActionResult Create(Guid customerId)
        {
            TempData["customerId"] = customerId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(InventoryViewModel inventoryViewModel)
        {
            Guid.TryParse(TempData["customerId"].ToString(), out Guid customerId);

            if (ModelState.IsValid)
            {
                await _inventoryService.SaveInventory(inventoryViewModel, customerId);
                _logger.LogInformation($"Created new inventory {inventoryViewModel.Name} for customer {customerId}");
            }
            else
            {
                TempData["Error"] = "Could not save new inventory";
                _logger.LogError($"Could not save new inventory for customer {customerId}");
                return RedirectToAction("Create", new { id = customerId });
            }
            return RedirectToAction("Details", "Customer", new{ id = customerId});
        }
        public async Task<IActionResult> Details(Guid inventoryId)
        {
          var model =  await _inventoryService.GetInventoryDetails(inventoryId);
        return View(model);
        }
        public async Task<IActionResult> Delete(Guid inventoryId, Guid customerId)
        { 
            TempData["customerId"] = customerId;
            TempData["inventoryId"] = inventoryId;

          var model = await _inventoryService.GetInventoryDetails(inventoryId);
            return View(model);
        } 
        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            Guid.TryParse(TempData["inventoryId"].ToString(), out Guid inventoryId);

            await _inventoryService.DeleteInventory(inventoryId);
            _logger.LogInformation($"Deleted inventory {inventoryId}");

            Guid.TryParse(TempData["customerId"].ToString(), out Guid customerId);

            return RedirectToAction("Details", "Customer", new{id = customerId});
        }


    }

 
}
