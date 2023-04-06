namespace BTL.Models
{
    public class HouseDetail
    {

        public ThongTinNha thongTinNha { get; set; }

        public ChuNha chuNha { get; set; }

        public DoiTuongSuDung Dtsd { get; set; }

        public MucDichSuDung Mdsd { get; set; }

        public LoaiNha loaiNha { get; set; }

        public List<string> ListDichVu { get; set; }

        public List<string> ListTaiSan { get; set; }

        public List<DanhGiaNha> ListDanhGia { get; set;}

        public List<NguoiDung> ListNguoiDung { get; set;}
    }
}
