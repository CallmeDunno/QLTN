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
    [RegularExpression(@"^[a-zA-Z\s\u00C0-\u00FF]+$", ErrorMessage = "Tên tài sản có thể gồm chữ thường hoặc in hoa.")]
    public string TenTaiSan { get; set; } = null!;

    public virtual ICollection<NhaTaiSan> NhaTaiSans { get; } = new List<NhaTaiSan>();
}
