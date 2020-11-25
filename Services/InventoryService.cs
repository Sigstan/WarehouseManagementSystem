using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.WEB.Entities;
using WarehouseManagementSystem.WEB.Models;
using WarehouseManagementSystem.WEB.Repositories;

namespace WarehouseManagementSystem.WEB.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IRepository _repository;

        public InventoryService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task SaveInventory(InventoryViewModel inventoryViewModel, Guid customerId)
        {
            var entity = HandleViewToEntity(inventoryViewModel);
            entity.CustomerId = customerId;
            await _repository.SaveAsync(entity);
        }

        public async Task<List<Inventory>> GetAllCustomerInventories(Guid customerId)
        {
            var inventory = await _repository.Query<Inventory>().Where(x => x.CustomerId == customerId).ToListAsync();
            return inventory;
        }

        private Inventory HandleViewToEntity(InventoryViewModel inventoryViewModel)
        {
            var entity = new Inventory()
            {
                Name = inventoryViewModel.Name,
                Weight = inventoryViewModel.Weight,
                Sector = inventoryViewModel.Sector,
                StoredDateTime = inventoryViewModel.StoredDateTime,
                CustomerId = inventoryViewModel.CustomerId
            };
            return entity;
        }
        private InventoryViewModel HandleEntityToView(Inventory inventory)
        {
            var model = new InventoryViewModel()
            {
                Name = inventory.Name,
                Weight = inventory.Weight,
                Sector = inventory.Sector,
                StoredDateTime = inventory.StoredDateTime,
                CustomerId = inventory.CustomerId,
                Id = inventory.Id
            };
            return model;
        }

        public List<InventoryViewModel> PrepareInventoriesViewModels(List<Inventory> inventories)
        {
            var listOfInventory = new List<InventoryViewModel>();
            if (inventories == null)
            {
                return listOfInventory;
            }
            foreach (var inventory in inventories)
            {
                var model = HandleEntityToView(inventory);
                listOfInventory.Add(model);
            }
            return listOfInventory;
        }

        public async Task DeleteInventory(Guid inventoryId)
        {
            var inventory = await GetInventoryById(inventoryId);
            await _repository.DeleteAsync<Inventory>(inventory);
        }

        public async Task<InventoryViewModel> GetInventoryDetails(Guid inventoryId)
        {
            var inventory = await GetInventoryById(inventoryId);
            var model = HandleEntityToView(inventory);
            return model;
        }

        private async Task<Inventory> GetInventoryById(Guid inventoryId)
        {
            var inventory = await _repository.GetEntityById<Inventory>(inventoryId);
            return inventory;
        }
    }
}

