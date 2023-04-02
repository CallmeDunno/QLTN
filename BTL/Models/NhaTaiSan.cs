using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class NhaTaiSan
{
    public int MaNha { get; set; }

    public int MaTaiSan { get; set; }

    public int SoLuong { get; set; }

    public decimal GiaTri { get; set; }

    public virtual ThongTinNha MaNhaNavigation { get; set; } = null!;

    public virtual TaiSan MaTaiSanNavigation { get; set; } = null!;
}
