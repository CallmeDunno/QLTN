using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class MucDichSuDung
{
    public int MaMdsd { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập mục đích sử dụng")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Mục đích sử dụng không hợp lệ")]
    public string TenMdsd { get; set; } = null!;

    public virtual ICollection<ThongTinNha> ThongTinNhas { get; } = new List<ThongTinNha>();
}
