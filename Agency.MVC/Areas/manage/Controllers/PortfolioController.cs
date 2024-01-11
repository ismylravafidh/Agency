using Agency.Business.Services.Interfaces;
using Agency.Business.ViewModels.PortfolioVms;
using Agency.Core.Common;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agency.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize]
    public class PortfolioController : Controller
    {
		private readonly IPortfolioService _service;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _env;

		public PortfolioController(IPortfolioService service,IMapper mapper,IWebHostEnvironment env)
        {
			_service = service;
			_mapper = mapper;
			_env = env;
		}
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }
        public async Task<IActionResult> Create()
        {
			if (!ModelState.IsValid)
			{
				return View();
			}
			return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PortfolioCreateVm createVm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _service.CreateAsync(createVm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
			if (!ModelState.IsValid)
			{
				return View();
			}
			PortfolioUpdateVm updateVm = _mapper.Map<PortfolioUpdateVm>(await _service.GetByIdAsync(id));
            return View(updateVm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(PortfolioUpdateVm updateVm)
        {
			if (!ModelState.IsValid)
			{
				return View();
			}
			await _service.UpdateAsync(updateVm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
			if (!ModelState.IsValid)
			{
				return View();
			}
			await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
