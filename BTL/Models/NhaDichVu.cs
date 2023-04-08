using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class NhaDichVu
{
    [DisplayName("Mã nhà:")]
    public int MaNha { get; set; }

    [DisplayName("Mã dịch vụ: ")]
    public int MaDichVu { get; set; }

    [DisplayName("Ghi chú: ")]
    [Required(ErrorMessage = "Vui lòng nhập ghi chú")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Ghi chú bao gồm chữ thường, in hoa và số.")]
    public string? GhiChu { get; set; }

    public virtual DichVu MaDichVuNavigation { get; set; } = null!;

    public virtual ThongTinNha MaNhaNavigation { get; set; } = null!;
}
