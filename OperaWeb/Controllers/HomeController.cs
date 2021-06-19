using Microsoft.AspNetCore.Mvc;

namespace OperaWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
