using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WEB.Models
{
    public class Top5SectorsViewModel
    {
        public List<SectorViewModel> Sectors { get; set; }
    }

    public class SectorViewModel
    {
        public double Weight { get; set; }
        public int Sector { get; set; }
    }
}
