using Microsoft.AspNetCore.Mvc;
using BTL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace BTL.Controllers
{
    public class AccessController : Controller
    {
        QltnContext db = new QltnContext();

        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            /*if (HttpContext.Session.GetString("Username") == null)
            {
                return View();
            }
            else if (HttpContext.Session.GetString("Username") == "admin")
            {
                return RedirectToAction("index", "admin");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }*/
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(NguoiDung user)
        {
            /*if (ModelState.IsValid)
            {
                db.NguoiDungs.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "House");
            }
            return View(user);*/
            var obj = db.NguoiDungs.FirstOrDefault(x => x.TenNguoiDung == user.TenNguoiDung && x.Email == user.Email);
            if (obj != null)
            {
                if (obj.MaNguoiDung == 1)
                {
                    HttpContext.Session.SetString("UserName", obj.TenNguoiDung.ToString());
                    HttpContext.Session.SetString("UserId", obj.MaNguoiDung.ToString());
                    return RedirectToAction("index", "admin");
                }
                else
                {
                    HttpContext.Session.SetString("UserName", obj.TenNguoiDung.ToString());
                    HttpContext.Session.SetString("UserId", obj.MaNguoiDung.ToString());
                    return RedirectToAction("Index", "Home");
                }

            }
           
            return View();
          
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login", "Access");
        }

        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("Register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(NguoiDung nguoidung)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDungs.Add(nguoidung);
                db.SaveChanges();
                return RedirectToAction("Login", "Access");
            }
            return View(nguoidung);
        }

    }
}
