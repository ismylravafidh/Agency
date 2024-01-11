using Agency.Business.ViewModels.BaseVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.ViewModels.PortfolioVms
{
	public class PortfolioGetVm:BaseEntityVm
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string? ImageUrl { get; set; }
	}
}
