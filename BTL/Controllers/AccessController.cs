using Microsoft.AspNetCore.Mvc;
using BTL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace BTL.Controllers
{
    public class AccessController : Controller
    {
        QltnContext db = new QltnContext();
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
        [HttpPost]
        public IActionResult Login(NguoiDung user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u = db.NguoiDungs.Where(x => x.TenNguoiDung.Equals(user.TenNguoiDung) && x.MatKhau.Equals(user.MatKhau)).FirstOrDefault();
                if (u != null)
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
        public ActionResult Register(NguoiDung user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra xem tài khoản đã tồn tại chưa
                    var u = db.NguoiDungs.FirstOrDefault(u => u.TenNguoiDung == user.TenNguoiDung);
                    if (u != null)
                    {
                        ModelState.AddModelError("TenNguoiDung", "Tài khoản đã tồn tại");
                        return View();
                    }

                    // Tạo mới đối tượng NguoiDung và lưu vào CSDL
                    var newUser = new NguoiDung
                    {
                        TenNguoiDung = user.TenNguoiDung,
                        MatKhau = user.MatKhau,
                        Sdt = user.Sdt,
                        Email = user.Email,
                        DiaChi = user.DiaChi,
                        NgaySinh = user.NgaySinh,
                        NgheNghiep = user.NgheNghiep,
                        AnhNguoiDung = user.AnhNguoiDung
                    };

                    db.NguoiDungs.Add(newUser);
                    db.SaveChanges();

                    // Đăng ký thành công, chuyển hướng đến trang đăng nhập
                    return RedirectToAction("Login", "Access");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Đã có lỗi xảy ra: " + ex.Message);
                    return View();
                }
            }

            // Dữ liệu không hợp lệ, trả về View với thông tin lỗi
            return View();
        }*/
    }
}
