using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class MsitController : Controller
    {
        public IActionResult Index()        //action函式
        {
            return View();
        }
        public IActionResult Test()        //action函式
        {
            return View();
        }
    }
}
