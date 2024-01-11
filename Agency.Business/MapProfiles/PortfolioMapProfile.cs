using Agency.Business.ViewModels.PortfolioVms;
using Agency.Core.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.MapProfiles
{
    public class PortfolioMapProfile : Profile
    {
        public PortfolioMapProfile()
        {
            CreateMap<Portfolio, PortfolioCreateVm>().ReverseMap();
            CreateMap<Portfolio, PortfolioGetVm>().ReverseMap();
            CreateMap<PortfolioGetVm, PortfolioUpdateVm>().ReverseMap();
        }
    }
}
