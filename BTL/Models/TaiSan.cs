using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class TaiSan
{
    [DisplayName("Mã tài sản: ")]
    public int MaTaiSan { get; set; }

    [DisplayName("Tên tài sản: ")]
    [Required(ErrorMessage = "Vui lòng nhập tên tài sản")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Tên tài sản có thể gồm chữ thường, in hoa và số.")]
    public string TenTaiSan { get; set; } = null!;

    public virtual ICollection<NhaTaiSan> NhaTaiSans { get; } = new List<NhaTaiSan>();
}
