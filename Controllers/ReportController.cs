using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagementSystem.WEB.Services;

namespace WarehouseManagementSystem.WEB.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        public  IActionResult Index()
        {
           return View();
        } 
        public async Task<IActionResult> Top5Customers()
        {
            var model = await _reportService.GetTop5Customers();
            return View(model);
        }
        public async Task<IActionResult> Top5Sectors()
        {
           var model = await _reportService.GetTop5Sectors();
            return View(model);
        }

    }
}
