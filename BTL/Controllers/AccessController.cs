using Microsoft.AspNetCore.Mvc;
using BTL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace BTL.Controllers
{
    public class AccessController : Controller
    {
        QltnContext db = new QltnContext();

        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(NguoiDung user)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDungs.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "House");
            }
            return View(user);
        }

    }
}
