using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class NguoiDung
{
    public int MaNguoiDung { get; set; }

    public string TenNguoiDung { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public DateTime NgaySinh { get; set; }

    public string NgheNghiep { get; set; } = null!;

    public string? AnhNguoiDung { get; set; }

    public int IsDeleted { get; set; }

    public virtual ICollection<DanhGiaNha> DanhGiaNhas { get; } = new List<DanhGiaNha>();

    public virtual ICollection<HopDongNha> HopDongNhas { get; } = new List<HopDongNha>();
}
