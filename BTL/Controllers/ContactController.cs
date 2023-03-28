using Microsoft.AspNetCore.Mvc;

namespace BTL.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
