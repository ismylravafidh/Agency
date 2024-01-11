using Agency.Business.ViewModels.PortfolioVms;
using Agency.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.Services.Interfaces
{
    public interface IPortfolioService
    {
        Task<List<PortfolioGetVm>> GetAllAsync();
        Task<PortfolioGetVm> GetByIdAsync(int id);
        Task CreateAsync(PortfolioCreateVm createVm);
        Task UpdateAsync(PortfolioUpdateVm updateVm);
        Task DeleteAsync(int id);
    }
}
