using Microsoft.AspNetCore.Mvc;

namespace BTL.Controllers
{
    public class HostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
