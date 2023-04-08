using Microsoft.AspNetCore.Mvc;
using BTL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace BTL.Controllers
{
    public class AccessController : Controller
    {
        QltnContext db = new QltnContext();

        [Route("ThemThongTinNguoiDung")]
        [HttpGet]
        public IActionResult ThemThongTinNguoiDung(int idnha)
        {
            int x = idnha;
            return View();
        }

        [Route("ThemThongTinNguoiDung")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemThongTinNguoiDung(NguoiDung nguoidung)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDungs.Add(nguoidung);
                ThongTinNha nha = db.ThongTinNhas.Find();
                if (nha != null)
                {
                    nha.TinhTrangThue = 1;
                    db.Entry(nha).State = EntityState.Modified;
                }
                
                db.SaveChanges();
                return RedirectToAction("Index", "House");
            }
            return View(nguoidung);
        }

    }
}
