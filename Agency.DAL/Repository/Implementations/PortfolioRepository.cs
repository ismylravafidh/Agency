using Agency.Core.Common;
using Agency.DAL.Data;
using Agency.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.DAL.Repository.Implementations
{
    public class PortfolioRepository : Repository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
