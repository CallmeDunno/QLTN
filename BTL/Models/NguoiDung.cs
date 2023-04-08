using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class NguoiDung
{
    public int MaNguoiDung { get; set; }

    public string TenNguoiDung { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public virtual ICollection<HopDongNha> HopDongNhas { get; } = new List<HopDongNha>();
}
