using Agency.Business.ViewModels.BaseVm;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.ViewModels.PortfolioVms
{
    public class PortfolioUpdateVm : BaseEntityVm
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile ImageFile { get; set; }
    }
    public class PortfolioUpdateVmValidator : AbstractValidator<PortfolioUpdateVm>
    {
        public PortfolioUpdateVmValidator()
        {
			RuleFor(p => p.Title).NotEmpty().WithMessage("Title bos ola bilmez")
				.MaximumLength(30).WithMessage("Title 30 den cox ola bilmez");
		}


    }
}
