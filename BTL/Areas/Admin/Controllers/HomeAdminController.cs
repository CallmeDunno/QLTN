using BTL.Models;
using Microsoft.AspNetCore.Mvc;

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

        #region NguoiDung
        [Route("ThongTinNguoiDung")]
        public IActionResult ThongTinNguoiDung()
        {
            return View();
        }
        #endregion

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
