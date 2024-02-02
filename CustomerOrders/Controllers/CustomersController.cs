using CustomerOrders.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerOrders.Controllers
{
    public class CustomersController : Controller
    {
        NorthwindContext _context;
        public CustomersController(NorthwindContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //ViewBag.Customers = new SelectList("字串集合","客戶代號","公司名稱");
            ViewBag.Customers = new SelectList(_context.Customers.Select(c => new
            {
                客戶代號 = c.CustomerId,
                公司名稱 = c.CompanyName,
            }), "客戶代號", "公司名稱");
            return View();
        }
        public async Task<IActionResult> Orders(string id)
        {
            Customer? c = await _context.Customers.FindAsync(id);
            if (c == null)
            {
                return NotFound();
            }
            return PartialView("_OrdersPartial",c.Orders);
        }
    }
}
