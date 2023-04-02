using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class DanhGiaNha
{
    public int MaDanhGia { get; set; }

    public string NoiDung { get; set; } = null!;

    public DateTime NgayDanhGia { get; set; }

    public int MaNguoiDung { get; set; }

    public int MaNha { get; set; }

    public int IsDeleted { get; set; }

    public virtual NguoiDung MaNguoiDungNavigation { get; set; } = null!;

    public virtual ThongTinNha MaNhaNavigation { get; set; } = null!;
}
