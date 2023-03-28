using Microsoft.AspNetCore.Mvc;

namespace BTL.Controllers
{
    public class HouseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
