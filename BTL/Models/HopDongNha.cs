using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class HopDongNha
{
    public int MaHopDong { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập thời gian bắt đầu hợp đồng")]
    [RegularExpression(@"^([0-9]{2})/([0-9]{2})/([0-9]{4})$", ErrorMessage = "Thời gian bắt đầu hợp đồng không đúng định dạng dd/MM/yyyy.")]
    public DateTime ThoiGianBatDau { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập thời gian kết thúc hợp đồng")]
    [RegularExpression(@"^([0-9]{2})/([0-9]{2})/([0-9]{4})$", ErrorMessage = "Thời gian kết thúc hợp đồng không đúng định dạng dd/MM/yyyy.")]
    public DateTime ThoiGianKetThuc { get; set; }

    public int MaNha { get; set; }

    public int MaNguoiDung { get; set; }

    public int IsDeleted { get; set; }

    public virtual NguoiDung MaNguoiDungNavigation { get; set; } = null!;

    public virtual ThongTinNha MaNhaNavigation { get; set; } = null!;
}
