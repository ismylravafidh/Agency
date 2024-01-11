using Microsoft.AspNetCore.Mvc;

namespace Agency.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
