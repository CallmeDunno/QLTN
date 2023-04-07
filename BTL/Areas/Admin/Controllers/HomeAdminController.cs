using BTL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using Microsoft.EntityFrameworkCore.Query;

namespace BTL.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {

        QltnContext db = new QltnContext();

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }


        [Route("ThongTinNha")]
        public IActionResult ThongTinNha()
        {
            var listnha = db.ThongTinNhas.ToList();
            return View(listnha);
        }

        #region Văn Vũ 11h tối

        #region ChuNha
        [Route("ThongTinChuNha")]
        public IActionResult ThongTinChuNha()
        {
            return View();
        }

        #endregion

        [Route("DanhMucChuNha")]
        public IActionResult DanhMucChuNha(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstchu = db.ChuNhas.AsNoTracking().OrderBy(x => x.MaChuNha);
            PagedList<ChuNha> lst = new PagedList<ChuNha>(lstchu, pageNumber, pageSize);
            return View(lst);
        }
        #region NguoiDung
        [Route("ThongTinNguoiDung")]
        public IActionResult ThongTinNguoiDung()
        {
            return View();
        }
        #endregion
   

        [Route("ThemChuNhaMoi")]
        [HttpGet]
        public IActionResult ThemChuNhaMoi() 
        {

            return View(); 
        }
        [Route("ThemChuNhaMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemChuNhaMoi(ChuNha chunha)
        {
            if(ModelState.IsValid)
            {
                db.ChuNhas.Add(chunha);
                db.SaveChanges();
                return RedirectToAction("DanhMucChuNha");   
            }    
            return View(chunha);
        }


        [Route("SuaChuNha")]
        [HttpGet]

        public IActionResult SuaChuNha(int maChuNha)
        {
            var chuNha = db.ChuNhas.Find(maChuNha);
            return View(chuNha);
        }
        [Route("SuaChuNha")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaChuNha(ChuNha chuNha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuNha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucChuNha", "HomeAdmin");
            }
            return View(chuNha);
        }
        [Route("XoaChuNha")]
        [HttpGet]
        public IActionResult XoaChuNha(int maChuNha)
        {
          
            var tenchunha = db.ChuNhas.Where(x => x.MaChuNha==maChuNha).ToList();
            if (tenchunha.Any()) db.RemoveRange(tenchunha);
            db.Remove(db.ChuNhas.Find(maChuNha));
            db.SaveChanges();
            TempData["Message"] = "Chủ Nhà đã được xóa";
            return RedirectToAction("DanhMucChuNha", "HomeAdmin");
        }

        [Route("DanhMucNguoiDung")]
        public IActionResult DanhMucNguoiDung(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstuser = db.NguoiDungs.AsNoTracking().OrderBy(x => x.MaNguoiDung);
            PagedList<NguoiDung> lst = new PagedList<NguoiDung>(lstuser, pageNumber, pageSize);
            return View(lst);
        }
        [Route("ThemNguoiDungMoi")]
        [HttpGet]
        public IActionResult ThemNguoiDungMoi()
        {

            return View();
        }
        [Route("ThemNguoiDungMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemNguoiDungMoi(NguoiDung nguoidung)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDungs.Add(nguoidung);
                db.SaveChanges();
                return RedirectToAction("DanhMucNguoiDung");
            }
            return View(nguoidung);
        }

        [Route("SuaNguoiDung")]
        [HttpGet]
        public IActionResult SuaNguoiDung(int maNguoiDung)
        {
            var nguoiDung = db.NguoiDungs.Find(maNguoiDung);
            return View(nguoiDung);
        }
        [Route("SuaNguoiDung")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNguoiDung(NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoiDung).State = EntityState.Modified;   
                db.SaveChanges();
                return RedirectToAction("DanhMucNguoiDung", "HomeAdmin");
            }
            return View(nguoiDung);
        }

        [Route("XoaNguoiDung")]
        [HttpGet]
        public IActionResult XoaNguoiDung(int maNguoiDung)
        {
            TempData["Message"] = "";
            var tennguoidung = db.NguoiDungs.Where(x => x.MaNguoiDung == maNguoiDung).ToList();
            if (tennguoidung.Any()) db.RemoveRange(tennguoidung);
            db.Remove(db.NguoiDungs.Find(maNguoiDung));
            db.SaveChanges();
            TempData["Message"] = "Người Dùng đã được xóa";
            return RedirectToAction("DanhMucNguoiDung", "HomeAdmin");
        }


        #endregion

        #region Ngọc Quân
        #region DichVu
        [Route("ThongTinDichVu")]
        public IActionResult ThongTinDichVu()
        {
            return View();
        }
        #endregion

        #region DTSD
        [Route("ThongTinDTSD")]
        public IActionResult ThongTinDTSD()
        {
            return View();
        }
        #endregion
        #endregion

        #region Dương
        #region HDN
        [Route("ThongTinHDN")]
        public IActionResult ThongTinHDN()
        {
            return View();
        }
        #endregion

        #region LoaiNha
        [Route("ThongTinLoaiNha")]
        public IActionResult ThongTinLoaiNha()
        {
            return View();
        }
        #endregion
        #endregion

        #region Hải
        #region MDSD
        [Route("ThongTinMDSD")]
        public IActionResult ThongTinMDSD()
        {
            return View();
        }
        #endregion

        #region TaiSan
        [Route("ThongTinTaiSan")]
        public IActionResult ThongTinTaiSan()
        {
            return View();
        }
        #endregion
        #endregion
    }
}
