﻿using BTL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace BTL.Controllers
{
    public class HouseController : Controller
    {
        private readonly ILogger<HouseController> _logger;
        QltnContext db = new QltnContext();

        public HouseController(ILogger<HouseController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber=  page == null || page < 0 ? 1 : page.Value;
            var lstphong = db.ThongTinNhas.AsNoTracking().OrderBy(x => x.MaNha);
            PagedList<ThongTinNha> lst = new PagedList<ThongTinNha>(lstphong, pageNumber, pageSize);
            return View(lst);
        }

        public IActionResult HouseDetail(int MaNha)
        {
            var nha = db.ThongTinNhas.Where(x => x.MaNha == MaNha).FirstOrDefault();

            var chuNha =  (from chunha in db.ChuNhas join n in db.ThongTinNhas on chunha.MaChuNha equals n.MaChuNha
                          where n.MaNha == MaNha
                             select chunha).FirstOrDefault();
            var tenDtsd = (from t in db.DoiTuongSuDungs join n in db.ThongTinNhas on t.MaDtsd equals n.MaDtsd
                           where n.MaNha == MaNha
                           select t).FirstOrDefault();
            var tenMdsd = (from t in db.MucDichSuDungs
                           join n in db.ThongTinNhas on t.MaMdsd equals n.MaMdsd
                           where n.MaNha == MaNha
                           select t).FirstOrDefault();
            var loaiNha = (from l in db.LoaiNhas join n in db.ThongTinNhas on l.MaLoai equals n.MaLoai
                           where n.MaNha == MaNha
                           select l).FirstOrDefault();
            List<string> dichvu = (from d in db.NhaDichVus join n in db.ThongTinNhas on d.MaNha equals n.MaNha
                                   join dv in db.DichVus on d.MaDichVu equals dv.MaDichVu
                                   where n.MaNha == MaNha
                                   select dv.TenDichVu).ToList();
            List<string> taisan = (from d in db.NhaTaiSans
                                   join n in db.ThongTinNhas on d.MaNha equals n.MaNha
                                   join dv in db.TaiSans on d.MaTaiSan equals dv.MaTaiSan
                                   where n.MaNha == MaNha
                                   select dv.TenTaiSan).ToList();
            List<DanhGiaNha> danhGiaNha = (from dgn in db.DanhGiaNhas join n in db.ThongTinNhas on dgn.MaNha equals n.MaNha
                                           where n.MaNha == MaNha
                                           select dgn).ToList();
            List<NguoiDung> nguoidung = (from nd in db.NguoiDungs
                             join dgn in db.DanhGiaNhas on nd.MaNguoiDung equals dgn.MaNguoiDung
                             where dgn.MaNha == MaNha
                             select nd).ToList();
            HouseDetail house = new HouseDetail
            {
                thongTinNha = nha,
                chuNha = chuNha,
                Dtsd = tenDtsd,
                Mdsd = tenMdsd,
                loaiNha = loaiNha,
                ListDichVu = dichvu,
                ListTaiSan = taisan,
                ListDanhGia = danhGiaNha,
                ListNguoiDung = nguoidung,
            };

            if (house == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(house);
            }
        }
    }

}
