using CustomersWebSite.Models;
using CustomersWebSite.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace CustomersWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        NorthwindContext _context;
        IMemoryCache _cache;
        //宣告成變數，並加入DI模型
        public HomeController(ILogger<HomeController> logger, NorthwindContext context, IMemoryCache cache)
        {
            _logger = logger;
            _context = context;
            _cache = cache;
        }

        public IActionResult Index()
        {
            //Session
            ViewBag.Phone = _context.Customers.First().Phone;
            ViewBag.Country = new SelectList(_context.Customers.Select(c => c.Country).Distinct());
            ViewBag.CustomerCount = $"alert('客戶數:{_context.Customers.Count()}');";
            HttpContext.Session.SetString("MSIT", "155");
            //Cache
            MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions();
            cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromDays(1));
            cacheEntryOptions.SetPriority(CacheItemPriority.High); //High表示最高級，最不可清除的
            _cache.Set("MSIT", 155, cacheEntryOptions);
            //Cookie
            CookieOptions cookieOption = new CookieOptions();
            cookieOption.Expires = DateTime.Now.AddDays(1);
            cookieOption.Secure = true;

            Response.Cookies.Append("MSIT", "155", cookieOption);
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact([Bind("Name,Email,Phone")]ContactViewModel cvm)//Bind限制接受的欄位數量與欄位值
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "alert('寫入資料庫成功!')"; //跨頁面的資料使用TempData，ViewBag值用完就丟，無保存
                //寫入資料庫
                return RedirectToAction("Index");
            }
            return View(cvm);
        }
        public IActionResult Privacy()
        {
            //Session
            string? MSIT = HttpContext.Session.GetString("MSIT"); //因為Session可能因為逾時而沒有值所以要+上?
            if (MSIT!= null)
            {

            }
            //Cache
            object data;
            //_cache.TryGetValue("MSIT", out data);
            if (_cache.TryGetValue("MSIT", out data))
            {
                //int msit = (int)data;
                string? CacheData = Convert.ToString(data);
            }
            //Cookie
            string? mistcookie = Request.Cookies["MSIT"];
            if(mistcookie != null)
            {

            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
