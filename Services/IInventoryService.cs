using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.WEB.Entities;
using WarehouseManagementSystem.WEB.Models;

namespace WarehouseManagementSystem.WEB.Services
{
    public interface IInventoryService
    {
        Task SaveInventory(InventoryViewModel inventoryViewModel, Guid customerId);
        List<Inventory> GetAllCustomerInventories(Guid customerId);
        List<InventoryViewModel> PrepareInventoryViewModels(List<Inventory> inventories);
       // List<InventoryViewModel> PrepareCustomersInventoryViewModels(Guid customerId);
       Task DeleteInventory(Guid inventoryId);
       Task<InventoryViewModel> GetInventoryDetails(Guid inventoryId);
    }
}
