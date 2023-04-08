using Azure;
using BTL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

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

        #region ThongTinNha

        [Route("ThongTinNha")]
        public IActionResult ThongTinNha(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listNha = db.ThongTinNhas.AsNoTracking().OrderBy(x => x.MaNha);
            PagedList<ThongTinNha> lst = new PagedList<ThongTinNha>(listNha, pageNumber, pageSize);
            return View(lst);
        }

        [Route("ThemNha")]
        [HttpGet]
        public IActionResult ThemNha()
        {
            ViewBag.MaDtsd = new SelectList(db.DoiTuongSuDungs.ToList(), "MaDtsd", "MaDtsd");
            ViewBag.MaLoai = new SelectList(db.LoaiNhas.ToList(), "MaLoai", "MaLoai");
            ViewBag.MaChuNha = new SelectList(db.ChuNhas.ToList(), "MaChuNha", "MaChuNha");
            ViewBag.MaMdsd = new SelectList(db.MucDichSuDungs.ToList(), "MaMdsd", "MaMdsd");
            return View();
        }

        [Route("ThemNha")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemNha(ThongTinNha thongTinNha)
        {
            if (!ModelState.IsValid)
            {
                db.ThongTinNhas.Add(thongTinNha);
                db.SaveChanges();
                return RedirectToAction("ThongTinNha");
            } else
            {
                return View();
            }
        }

        [Route("SuaNha")]
        [HttpGet]
        public IActionResult SuaNha(int id)
        {
            ViewBag.MaDtsd = new SelectList(db.DoiTuongSuDungs.ToList(), "MaDtsd", "MaDtsd");
            ViewBag.MaLoai = new SelectList(db.LoaiNhas.ToList(), "MaLoai", "MaLoai");
            ViewBag.MaChuNha = new SelectList(db.ChuNhas.ToList(), "MaChuNha", "MaChuNha");
            ViewBag.MaMdsd = new SelectList(db.MucDichSuDungs.ToList(), "MaMdsd", "MaMdsd");
            var nha = db.ThongTinNhas.Find(id);
            return View(nha);
        }

        [Route("SuaNha")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNha(ThongTinNha thongTinNha)
        {
            if (!ModelState.IsValid)
            {
                db.Entry(thongTinNha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ThongTinNha");
            }
            else
            {
                return View();
            }
        }

        [Route("XoaNha")]
        [HttpGet]
        public IActionResult XoaNha(int id)
        {
            TempData["Message"] = "";
            var hdn = db.HopDongNhas.Where(x => x.MaNha == id).ToList();
            var dgn = db.DanhGiaNhas.Where(x => x.MaNha == id).ToList();
            var ndv = db.NhaDichVus.Where(x => x.MaNha == id).ToList();
            var nts = db.NhaTaiSans.Where(x => x.MaNha == id).ToList();
            if (hdn.Count() > 0 && dgn.Count() > 0 && ndv.Count() > 0 && nts.Count() > 0)
            {
                TempData["Message"] = "Không xóa được nhà này.";
                return RedirectToAction("ThongTinNha");
            } else
            {
                TempData["Message"] = "Nhà đã được xóa.";
                db.Remove(db.ThongTinNhas.Find(id));
                db.SaveChanges();
                return RedirectToAction("ThongTinNha");
            }
        }
        #endregion

        #region HopDongNha

        [Route("NhaDichVu")]
        public IActionResult NhaDichVu(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listNha = db.NhaDichVus.AsNoTracking().OrderBy(x => x.MaNha);
            PagedList<NhaDichVu> lst = new PagedList<NhaDichVu>(listNha, pageNumber, pageSize);
            return View(lst);
        }

        [Route("ThemNhaDichVu")]
        [HttpGet]
        public IActionResult ThemNhaDichVu()
        {
            ViewBag.MaNha = new SelectList(db.ThongTinNhas.ToList(), "MaNha", "MaNha");
            ViewBag.MaDichVu = new SelectList(db.DichVus.ToList(), "MaDichVu", "TenDichVu");
            
            return View();
        }

        [Route("ThemNhaDichVu")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemNhaDichVu(NhaDichVu nhaDichVu)
        {
            if (!ModelState.IsValid)
            {
                db.NhaDichVus.Add(nhaDichVu);
                db.SaveChanges();
                return RedirectToAction("NhaDichVu");
            }
            else
            {
                return View();
            }
        }
        
        [Route("SuaNhaDichVu")]
        [HttpGet]
        public IActionResult SuaNhaDichVu(int id1, int id2)
        {
            var nha = db.NhaDichVus.Where(x => x.MaNha == id1 && x.MaDichVu == id2).FirstOrDefault();
            return View(nha);
        }

        [Route("SuaNhaDichVu")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNhaDichVu(NhaDichVu nhaDichVu)
        {
            if (!ModelState.IsValid)
            {
                db.Entry(nhaDichVu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("NhaDichVu");
            }
            else
            {
                return View();
            }
        }
        
        [Route("XoaNhaDichVu")]
        [HttpGet]
        public IActionResult XoaNhaDichVu(int id)
        {
            TempData["Message"] = "Dịch vụ đã được xóa khỏi nhà.";
            db.Remove(db.NhaDichVus.Find(id));
            db.SaveChanges();
            return RedirectToAction("NhaDichVu");
        }
        #endregion

        #region Văn Vũ

        #region ChuNha
        [Route("DanhMucChuNha")]
        public IActionResult DanhMucChuNha(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstchu = db.ChuNhas.AsNoTracking().OrderBy(x => x.MaChuNha);
            PagedList<ChuNha> lst = new PagedList<ChuNha>(lstchu, pageNumber, pageSize);
            return View(lst);
        }

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
            if (ModelState.IsValid)
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

            var tenchunha = db.ChuNhas.Where(x => x.MaChuNha == maChuNha).ToList();
            if (tenchunha.Any()) db.RemoveRange(tenchunha);
            db.Remove(db.ChuNhas.Find(maChuNha));
            db.SaveChanges();
            TempData["Message"] = "Chủ Nhà đã được xóa";
            return RedirectToAction("DanhMucChuNha", "HomeAdmin");
        }
        #endregion

        #region NguoiDung
  
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

        #endregion

        #region Ngọc Quân

        #region DichVu
        [Route("ListDichVu")]
        public IActionResult ListDichVu(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listdv = db.DichVus.AsNoTracking().OrderBy(x => x.MaDichVu);
            PagedList<DichVu> lst = new PagedList<DichVu>(listdv, pageNumber, pageSize);
            return View(lst);
        }

        [Route("AddDichVu")]
        [HttpGet]
        public IActionResult AddDichVu()
        {
            return View();
        }

        [Route("AddDichVu")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDichVu(DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                db.DichVus.Add(dichVu);
                db.SaveChanges();
                return RedirectToAction("ListDichVu");
            }
            return View();
        }

        [Route("UpdateDichVu")]
        [HttpGet]
        public IActionResult UpdateDichVu(int id)
        {
            var dichVu = db.DichVus.Find(id);
            return View(dichVu);
        }

        [Route("UpdateDichVu")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDichVu(DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dichVu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListDichVu");
            }
            return View();
        }

        [Route("DeleteDichVu")]
        [HttpGet]
        public IActionResult DeleteDichVu(int id)
        {
            TempData["Message"] = "";
            var nha_dichvu = db.NhaDichVus.Where(x => x.MaDichVu == id).ToList();
            if (nha_dichvu.Any())
                db.RemoveRange(nha_dichvu);
            db.Remove(db.DichVus.Find(id));
            db.SaveChanges();
            TempData["Message"] = "Xóa dịch vụ thành công";
            return RedirectToAction("ListDichVu");
        }
        #endregion

        #region DTSD
        [Route("ThongTinDTSD")]
        public IActionResult ThongTinDTSD(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listdtsd = db.DoiTuongSuDungs.AsNoTracking().OrderBy(x => x.MaDtsd);
            PagedList<DoiTuongSuDung> lst = new PagedList<DoiTuongSuDung>(listdtsd, pageNumber, pageSize);
            return View(lst);
        }

        [Route("ThemDoiTuongSuDung")]
        [HttpGet]
        public IActionResult ThemDoiTuongSuDung()
        {
            return View();
        }

        [Route("ThemDoiTuongSuDung")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemDoiTuongSuDung(DoiTuongSuDung doiTuongSuDung)
        {
            if (ModelState.IsValid)
            {
                db.DoiTuongSuDungs.Add(doiTuongSuDung);
                db.SaveChanges();
                return RedirectToAction("ThongTinDTSD");
            }
            return View();
        }

        [Route("SuaDoiTuongSuDung")]
        [HttpGet]
        public IActionResult SuaDoiTuongSuDung(int id)
        {
            var doiTuongSuDung = db.DoiTuongSuDungs.Find(id);
            return View(doiTuongSuDung);
        }

        [Route("SuaDoiTuongSuDung")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaDoiTuongSuDung(DoiTuongSuDung doiTuongSuDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doiTuongSuDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ThongTinDTSD");
            }
            return View();
        }

        [Route("XoaDoiTuongSuDung")]
        [HttpGet]
        public IActionResult XoaDoiTuongSuDung(int id)
        {
            TempData["Message"] = "";
            var thongTinNha = db.ThongTinNhas.Where(x => x.MaDtsd == id).ToList();
            if (thongTinNha.Any())
            {
                TempData["Message"] = "không thể xóa đối tượng sử dụng này vì đã tồn tại trong bảng thông tin nhà";
                return RedirectToAction("ThongTinDTSD");
            }
            db.Remove(db.DoiTuongSuDungs.Find(id));
            db.SaveChanges();
            TempData["Message"] = "Xóa đối tượng sử dụng thành công";
            return RedirectToAction("ThongTinDTSD");
        }
        #endregion
        #endregion

        #region Dương
        #region HDN

        [Route("ThongTinHDN")]
        [Route("ListHopDongNha")]
        public IActionResult ListHopDongNha(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listhdn = db.HopDongNhas.AsNoTracking().OrderBy(x => x.MaHopDong);
            PagedList<HopDongNha> lst = new PagedList<HopDongNha>(listhdn, pageNumber, pageSize);
            return View(lst);
        }

        [Route("AddHopDongNha")]
        [HttpGet]
        public IActionResult AddHopDongNha()
        {
            ViewBag.MaNha = new SelectList(db.ThongTinNhas.ToList(), "MaNha", "MaNha");
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDungs.ToList(), "MaNguoiDung", "MaNguoiDung");
            return View();
        }

        [Route("AddHopDongNha")]
        [HttpPost]
        public IActionResult AddHopDongNha(HopDongNha hopDongNha)
        {
            db.HopDongNhas.Add(hopDongNha);
            db.SaveChanges();
            TempData["Message"] = "Thêm mới thành công";
            return RedirectToAction("ListHopDongNha");
        }

        [Route("UpdateHopDongNha")]
        [HttpGet]
        public IActionResult UpdateHopDongNha(int id)
        {
            ViewBag.MaNha = new SelectList(db.ThongTinNhas.ToList(), "MaNha", "MaNha");
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDungs.ToList(), "MaNguoiDung", "MaNguoiDung");
            var HopDongNha = db.HopDongNhas.Find(id);
            return View(HopDongNha);
        }

        [Route("UpdateHopDongNha")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateHopDongNha(HopDongNha hopDongNha)
        {
            db.Entry(hopDongNha).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ListHopDongNha");
        }

        [Route("DeleteHopDongNha")]
        [HttpGet]
        public IActionResult DeleteHopDongNha(int id)
        {
            TempData["Message"] = "";
            db.Remove(db.HopDongNhas.Find(id));
            db.SaveChanges();
            TempData["Message"] = "Xóa hợp đồng nhà thành công";
            return RedirectToAction("ListHopDongNha");
        }
        #endregion

        #region LoaiNha
        [Route("ListLoaiNha")]
        public IActionResult ListLoaiNha(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listln = db.LoaiNhas.AsNoTracking().OrderBy(x => x.MaLoai);
            PagedList<LoaiNha> lst = new PagedList<LoaiNha>(listln, pageNumber, pageSize);
            return View(lst);
        }

        [Route("AddLoaiNha")]
        [HttpGet]
        public IActionResult AddLoaiNha()
        {
            return View();
        }

        [Route("AddLoaiNha")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddLoaiNha(LoaiNha LoaiNha)
        {
            if (ModelState.IsValid)
            {
                db.LoaiNhas.Add(LoaiNha);
                db.SaveChanges();
                return RedirectToAction("ListLoaiNha");
            }
            return View();
        }

        [Route("UpdateLoaiNha")]
        [HttpGet]
        public IActionResult UpdateLoaiNha(int id)
        {
            var LoaiNha = db.LoaiNhas.Find(id);
            return View(LoaiNha);
        }

        [Route("UpdateLoaiNha")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateLoaiNha(LoaiNha LoaiNha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(LoaiNha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListLoaiNha");
            }
            return View();
        }

        [Route("DeleteLoaiNha")]
        [HttpGet]
        public IActionResult DeleteLoaiNha(int id)
        {
            TempData["Message"] = "";
            var nha_LoaiNha = db.ThongTinNhas.Where(x => x.MaLoai == id).ToList();
            if (nha_LoaiNha.Any())
            {
                TempData["Message"] = "không thể xóa loại nhà này vì đã tồn tại trong bảng thông tin nhà";
                return RedirectToAction("ListLoaiNha");
            }
            db.Remove(db.LoaiNhas.Find(id));
            db.SaveChanges();
            TempData["Message"] = "Xóa loại nhà thành công";
            return RedirectToAction("ListLoaiNha");
        }
        #endregion
        #endregion

        #region Hải
        #region MDSD
        [Route("ThongTinMDSD")]
        public IActionResult ThongTinMDSD(int ? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstmdsd = db.MucDichSuDungs.AsNoTracking().OrderBy(x => x.MaMdsd);
            PagedList<MucDichSuDung> lst = new PagedList<MucDichSuDung>(lstmdsd, pageNumber, pageSize);
            return View(lst);
        }

        [Route("ThemMDSD")]
        [HttpGet]
        public IActionResult ThemMDSD()
        {
            return View();
        }

        [Route("ThemMDSD")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemMDSD(MucDichSuDung mucDichSuDung)
        {
            if (ModelState.IsValid)
            {
                db.MucDichSuDungs.Add(mucDichSuDung);
                db.SaveChanges();
                return RedirectToAction("ThongTinMDSD");
            }
            return View();
        }

        [Route("SuaMDSD")]
        [HttpGet]
        public IActionResult SuaMDSD(int id)
        {
            var mucDichSuDung = db.MucDichSuDungs.Find(id);
            return View(mucDichSuDung);
        }

        [Route("SuaMDSD")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaMDSD(MucDichSuDung mucDichSuDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mucDichSuDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ThongTinMDSD");
            }
            return View();
        }

        [Route("XoaMDSD")]
        [HttpGet]
        public IActionResult XoaMDSD(int id)
        {
            TempData["Message"] = "";
            var thongTinNha = db.ThongTinNhas.Where(x => x.MaMdsd == id).ToList();
            if (thongTinNha.Any())
            {
                TempData["Message"] = "không thể xóa mục đích sử dụng này vì đã tồn tại trong bảng thông tin nhà";
                return RedirectToAction("ThongTinMDSD");
            }
            db.Remove(db.MucDichSuDungs.Find(id));
            db.SaveChanges();
            TempData["Message"] = "Xóa mục đích sử dụng thành công";
            return RedirectToAction("ThongTinMDSD");
        }
        #endregion

        #region TaiSan
        [Route("ThongTinTaiSan")]
        public IActionResult ThongTinTaiSan(int ? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstts = db.TaiSans.AsNoTracking().OrderBy(x => x.MaTaiSan);
            PagedList<TaiSan> lst = new PagedList<TaiSan>(lstts, pageNumber, pageSize);
            return View(lst);
        }
        [Route("ThemTaiSan")]
        [HttpGet]
        public IActionResult ThemTaiSan()
        {
            return View();
        }

        [Route("ThemTaiSan")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemTaiSan(TaiSan taiSan)
        {
            if (ModelState.IsValid)
            {
                db.TaiSans.Add(taiSan);
                db.SaveChanges();
                return RedirectToAction("ThongTinTaiSan");
            }
            return View();
        }

        [Route("SuaTaiSan")]
        [HttpGet]
        public IActionResult SuaTaiSan(int id)
        {
            var taiSan = db.TaiSans.Find(id);
            return View(taiSan);
        }

        [Route("SuaTaiSan")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaTaiSan(TaiSan taiSan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiSan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ThongTinTaiSan");
            }
            return View();
        }

        [Route("XoaTaiSan")]
        [HttpGet]
        public IActionResult XoaTaiSan(int id)
        {
            TempData["Message"] = "";
            var thongTinNha = db.TaiSans.Where(x => x.MaTaiSan == id).ToList();
            if (thongTinNha.Any())
            {
                TempData["Message"] = "không thể xóa tài sản này vì đã tồn tại trong bảng thông tin nhà";
                return RedirectToAction("ThongTinTaiSan");
            }
            db.Remove(db.TaiSans.Find(id));
            db.SaveChanges();
            TempData["Message"] = "Xóa tài sản thành công";
            return RedirectToAction("ThongTinTaiSan");
        }

        #endregion
        #endregion
    }
}
