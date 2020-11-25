using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace WarehouseManagementSystem.WEB.Services
{
    public interface IAppService
    {
        Task<T> HanldeViewToEntity<T>(T viewModel) where T : class;
    }
}
