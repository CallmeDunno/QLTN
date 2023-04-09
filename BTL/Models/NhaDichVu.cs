using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BTL.Models;

public partial class NhaDichVu
{
    public int MaNha { get; set; }

    public int MaDichVu { get; set; }

    [DisplayName("Ghi chú: ")]
    public string? GhiChu { get; set; }

    public virtual DichVu MaDichVuNavigation { get; set; } = null!;

    public virtual ThongTinNha MaNhaNavigation { get; set; } = null!;
}
