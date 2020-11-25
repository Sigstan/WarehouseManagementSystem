using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagementSystem.WEB.Models;

namespace WarehouseManagementSystem.WEB.Services
{
    public interface IReportService 
    {
        Task<Top5CustomersViewModel> GetTop5Customers();
       Task<Top5SectorsViewModel> GetTop5Sectors();
    }
}
