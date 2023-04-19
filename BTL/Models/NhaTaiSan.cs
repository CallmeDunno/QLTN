using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class NhaTaiSan
{
    [DisplayName("Mã nhà:")]
    public int MaNha { get; set; }

    [DisplayName("Mã tài sản")]
    public int MaTaiSan { get; set; }

    [DisplayName("Số lượng:")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Số lượng là các chữ số.")]
    public int SoLuong { get; set; }

    [DisplayName("Giá trị:")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Giá trị chỉ được chứa các chữ số.")]
    public decimal GiaTri { get; set; }

    public virtual ThongTinNha MaNhaNavigation { get; set; } = null!;

    public virtual TaiSan MaTaiSanNavigation { get; set; } = null!;
}
