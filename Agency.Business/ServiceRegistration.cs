using Agency.Business.Services.Implementations;
using Agency.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business
{
	public static class ServiceRegistration
	{
		public static void AddService(this IServiceCollection services)
		{
			services.AddScoped<IPortfolioService,PortfolioService>();
		}
	}
}
