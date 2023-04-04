using BTL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTL.Controllers
{  
    public class HostController : Controller
    {
        QltnContext db = new QltnContext();

        public IActionResult Index()
        {
            var chunhas = db.ChuNhas.ToList();
            //ViewBag.ChuNhas = chunhas;
            return View(chunhas);
        }
    }
}
