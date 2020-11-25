using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.WEB.Entities;
using WarehouseManagementSystem.WEB.Models;
using WarehouseManagementSystem.WEB.Repositories;

namespace WarehouseManagementSystem.WEB.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository _repository;

        public ReportService(IRepository repository)
        {
            _repository = repository;   
        }
        public async Task<Top5CustomersViewModel> GetTop5Customers()
        {
            var customers = await _repository.Query<Inventory>()
                .GroupBy(x => x.CustomerId).Select(n => new TopCustomerViewModel()
                {
                    Name = n.Key,
                    TotalRegistrations = n.Count()
                }).OrderByDescending(x=>x.TotalRegistrations)
                .ToListAsync();
            
            var top5Customers = new Top5CustomersViewModel()
            {
                TopCustomers = customers
            };
            return top5Customers;
        }

        public async Task<Top5SectorsViewModel> GetTop5Sectors()
        {
            var sectors = await _repository.Query<Inventory>()
                .Select(x => new {x.Sector, x.Weight})
                .GroupBy(x => x.Sector, x => x.Weight,
                    (key, values) => new SectorViewModel() {Sector = key, Weight = values.Sum()})
                .OrderByDescending(x => x.Weight).Take(5).ToListAsync();
            var top5Sectors = new Top5SectorsViewModel()
            {
                Sectors = sectors
            };
            return top5Sectors;
        }
    }
}
