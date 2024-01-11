using Agency.Business.Services.Interfaces;
using Agency.Business.ViewModels.PortfolioVms;
using Microsoft.AspNetCore.Mvc;

namespace Agency.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPortfolioService _service;

        public HomeController(IPortfolioService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            return View(await _service.GetAllAsync());
        }
    }
}
