using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class ChuNha
{
    public int MaChuNha { get; set; }

    public string TenChuNha { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public DateTime NgaySinh { get; set; }

    public string SdtchuNha { get; set; } = null!;

    public string? SdtchuNha2 { get; set; }

    public string Email { get; set; } = null!;

    public string AnhChuNha { get; set; } = null!;

    public string MoTaChuNha { get; set; } = null!;

    public virtual ICollection<ThongTinNha> ThongTinNhas { get; } = new List<ThongTinNha>();
}
