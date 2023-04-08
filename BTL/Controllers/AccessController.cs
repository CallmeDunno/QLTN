using Microsoft.AspNetCore.Mvc;
using BTL.Models;

namespace BTL.Controllers
{
    public class AccessController : Controller
    {
        QltnContext db = new QltnContext();
        [HttpGet]
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Login(NguoiDung user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u = db.NguoiDungs.Where(x => x.TenNguoiDung.Equals(user.TenNguoiDung) && x.MatKhau.Equals(user.MatKhau)).FirstOrDefault();
                if(u!= null)
                {
                    HttpContext.Session.SetString("UserName", u.TenNguoiDung.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }

        /*[HttpPost]
        public IActionResult Logout()
        {
            // Xóa cookie
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            // Xóa session
            HttpContext.Session.Clear();

            //Xóa session có tên UserName
            HttpContext.Session.Remove("UserName");

            // Xóa cache
            Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
            Response.Headers.Add("Pragma", "no-cache");
            Response.Headers.Add("Expires", "0");

            return RedirectToAction("Index", "Home");
        }*/

    }
}
