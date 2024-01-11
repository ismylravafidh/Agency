using Agency.DAL.Repository.Implementations;
using Agency.DAL.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.DAL
{
	public static class ServiceRegistration
	{
		public static void AddRepository(this IServiceCollection services)
		{
			services.AddScoped<IPortfolioRepository,PortfolioRepository>();
		}
	}
}
