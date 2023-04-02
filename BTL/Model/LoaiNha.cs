using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class LoaiNha
{
    public int MaLoai { get; set; }

    public string TenLoai { get; set; } = null!;

    public virtual ICollection<ThongTinNha> ThongTinNhas { get; } = new List<ThongTinNha>();
}
