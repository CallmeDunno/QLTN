using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class NhaDichVu
{
    public int MaNha { get; set; }

    public int MaDichVu { get; set; }

    public string? GhiChu { get; set; }

    public virtual DichVu MaDichVuNavigation { get; set; } = null!;

    public virtual ThongTinNha MaNhaNavigation { get; set; } = null!;
}
