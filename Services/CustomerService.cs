using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.WEB.Controllers;
using WarehouseManagementSystem.WEB.Entities;
using WarehouseManagementSystem.WEB.Models;
using WarehouseManagementSystem.WEB.Repositories;

namespace WarehouseManagementSystem.WEB.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository _repository;
        private readonly IInventoryService _inventoryService;
        public CustomerService(IRepository repository, IInventoryService inventoryService)
        {
            _repository = repository;
            _inventoryService = inventoryService;
        }

        public async Task<bool> SaveCustomer(CustomerViewModel customerViewModel)
        {
            var entity = HandleViewToEntity(customerViewModel);
            var isRegistered = CheckIfCustomerRegistered(customerViewModel);
            var isSaved = false;
            if (!isRegistered)
            {
                await _repository.SaveAsync(entity);
                isSaved = true;
            }

            return isSaved;
        }

        private bool CheckIfCustomerRegistered(CustomerViewModel customerViewModel)
        {
            var isRegistered = _repository.Query<Customer>().Any(x => x.FirstName.ToLower() == customerViewModel.FirstName.ToLower()
                                                    && x.LastName.ToLower() == customerViewModel.LastName.ToLower()
                                                    && x.Birthday == customerViewModel.Birthday);
            return isRegistered;
        }

        public Customer HandleViewToEntity(CustomerViewModel customerViewModel)
        {
            var entity = new Customer()
            {
                FirstName = customerViewModel.FirstName,
                LastName = customerViewModel.LastName,
                Birthday = customerViewModel.Birthday,
                ClientType = customerViewModel.ClientType,
                PhoneNumber = customerViewModel.PhoneNumber
            };
            return entity;
        }

        public ListOfCustomersViewModel GetAllCustomersViewModels()
        {
            var entities = GetAllCustomers();
            var customers = PrepareCustomerToView(entities);
            var listOfCustomers = new ListOfCustomersViewModel()
            {
                CustomerViewModels = customers
            };
            return listOfCustomers;
        }

        public async Task<ExtendedCustomerViewModel> GetCustomersDetailsViewModel(Guid customerId)
        {
            var customer = await GetCustomerById(customerId);
            //TODO: o kas jei negauni customer?
            var model = HandleEntityToExtendedView(customer);
            model.Inventory = _inventoryService.PrepareInventoryViewModels(customer.Inventories);
            return model;
        }

        private async Task<Customer> GetCustomerById(Guid customerId)
        {
            return await _repository.GetEntityById<Customer>(customerId);
        }

        private List<ExtendedCustomerViewModel> PrepareCustomerToView(List<Customer> entities)
        {
            var customersViewModels = new List<ExtendedCustomerViewModel>();
            foreach (var entity in entities)
            {
                var model = HandleEntityToExtendedView(entity);
                customersViewModels.Add(model);
            }

            return customersViewModels;
        }

        private ExtendedCustomerViewModel HandleEntityToExtendedView(Customer entity)
        {
            var model = HandelEntityToView(entity);
            var modelExtended = new ExtendedCustomerViewModel()
            {
                Birthday = model.Birthday,
                ClientType = model.ClientType,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Id = model.Id
            };
            var inventories = _inventoryService.GetAllCustomerInventories(entity.Id).Count();
            modelExtended.RegisteredInventory = inventories;
            return modelExtended;
        }

        private CustomerViewModel HandelEntityToView(Customer entity)
        {
            var model = new CustomerViewModel()
            {
                Birthday = entity.Birthday,
                ClientType = entity.ClientType,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber,
                Id = entity.Id
            };
            return model;
        }

        private List<Customer> GetAllCustomers()
        {
            return _repository.Query<Customer>().Where(x => x.Id != null).ToList();
        }
    }
}
