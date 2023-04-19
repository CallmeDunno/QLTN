using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class LoaiNha
{
    [DisplayName("Mã loại nhà: ")]
    public int MaLoai { get; set; }

    [DisplayName("Tên loại nhà:")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Tên loại nhà không hợp lệ")]
    public string TenLoai { get; set; } = null!;

    public virtual ICollection<ThongTinNha> ThongTinNhas { get; } = new List<ThongTinNha>();
}
