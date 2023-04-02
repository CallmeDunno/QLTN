using BTL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BTL.Controllers
{
    public class HomeController : Controller
    {
        QltnContext db = new QltnContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var timkiem = db.Searches.FromSqlRaw("SELECT LoaiNha.TenLoai, DoiTuongSuDung.TenDTSD, MucDichSuDung.TenMDSD, DiaChiNha, DienTich, GiaPhong, ThongTinNha.MaLoai, ThongTinNha.MaDTSD, ThongTinNha.MaMDSD FROM ThongTinNha JOIN LoaiNha ON ThongTinNha.MaLoai = LoaiNha.MaLoai JOIN DoiTuongSuDung ON ThongTinNha.MaDTSD = DoiTuongSuDung.MaDTSD JOIN MucDichSuDung ON ThongTinNha.MaMDSD = MucDichSuDung.MaMDSD").ToList();
            var loainha = db.LoaiNhas.ToList();
            var dtsd = db.DoiTuongSuDungs.ToList();
            var mdsd = db.MucDichSuDungs.ToList();
            //var ttn = db.ThongTinNhas.ToList();
            //var ttn = db.ThongTinNhas.Select(x => x.DiaChiNha).Distinct().ToList();
            //var thongTinNha = db.ThongTinNhas.Select(ttn => new { ttn.DiaChiNha, ttn.DienTich, ttn.GiaPhong }).Distinct().ToList();
            //var dc = db.ThongTinNhas.FromSqlRaw("select distinct DiaChiNha from ThongTinNha").ToList();
            //var dt = db.ThongTinNhas.FromSqlRaw("select distinct cast(DienTich as nvarchar(max)) from ThongTinNha").ToList();
            //var gia = db.ThongTinNhas.FromSqlRaw("select distinct GiaPhong from ThongTinNha").ToList();
            //ViewBag.Data = thongTinNha;

        
            ViewModelSearch viewModelSearch = new ViewModelSearch { LoaiNhaList = loainha, DoiTuongSuDungList = dtsd, MucDichSuDungList = mdsd };
            viewModelSearch.DiaChiNhaList = db.ThongTinNhas.Select(x => x.DiaChiNha).Distinct().ToList();
            //viewModelSearch.DienTichList = db.ThongTinNhas.Select(x => x.DienTich).Distinct().ToList();
            //viewModelSearch.GiaPhongList = db.ThongTinNhas.Select(x => x.GiaPhong).Distinct().ToList();
            return View(viewModelSearch);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}