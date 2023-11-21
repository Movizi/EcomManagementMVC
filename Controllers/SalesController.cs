using Microsoft.AspNetCore.Mvc;

namespace EcomManagement.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
