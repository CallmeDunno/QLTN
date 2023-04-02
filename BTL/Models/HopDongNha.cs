using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class HopDongNha
{
    public int MaHopDong { get; set; }

    public DateTime ThoiGianBatDau { get; set; }

    public DateTime ThoiGianKetThuc { get; set; }

    public int MaNha { get; set; }

    public int MaNguoiDung { get; set; }

    public int IsDeleted { get; set; }

    public virtual NguoiDung MaNguoiDungNavigation { get; set; } = null!;

    public virtual ThongTinNha MaNhaNavigation { get; set; } = null!;
}
