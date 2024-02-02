using Microsoft.AspNetCore.Mvc;

namespace TeamProject.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
    }
}
