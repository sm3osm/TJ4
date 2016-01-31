using Microsoft.AspNet.Mvc;

namespace TJ4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return View();
            return RedirectToAction("Index", "Customer");
        }
    }
}
