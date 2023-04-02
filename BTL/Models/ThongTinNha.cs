using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class ThongTinNha
{
    public int MaNha { get; set; }

    public string DiaChiNha { get; set; } = null!;

    public string DienTich { get; set; } = null!;

    public decimal GiaPhong { get; set; }

    public decimal TienDien { get; set; }

    public decimal TienNuoc { get; set; }

    public decimal TienDatCoc { get; set; }

    public int TinhTrangThue { get; set; }

    public string AnhMinhHoa { get; set; } = null!;

    public DateTime NgayDangTai { get; set; }

    public string MoTaNha { get; set; } = null!;

    public int MaDtsd { get; set; }

    public int MaLoai { get; set; }

    public int MaChuNha { get; set; }

    public int MaMdsd { get; set; }

    public virtual ICollection<DanhGiaNha> DanhGiaNhas { get; } = new List<DanhGiaNha>();

    public virtual ICollection<HopDongNha> HopDongNhas { get; } = new List<HopDongNha>();

    public virtual ChuNha MaChuNhaNavigation { get; set; } = null!;

    public virtual DoiTuongSuDung MaDtsdNavigation { get; set; } = null!;

    public virtual LoaiNha MaLoaiNavigation { get; set; } = null!;

    public virtual MucDichSuDung MaMdsdNavigation { get; set; } = null!;

    public virtual ICollection<NhaTaiSan> NhaTaiSans { get; } = new List<NhaTaiSan>();

    public virtual ICollection<DichVu> MaDichVus { get; } = new List<DichVu>();
    
}
