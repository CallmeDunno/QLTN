using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class DoiTuongSuDung
{
    public int MaDtsd { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên đối tượng sử dụng")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Tên đối tượng sử dụng không hợp lệ")]
    public string TenDtsd { get; set; } = null!;

    public virtual ICollection<ThongTinNha> ThongTinNhas { get; } = new List<ThongTinNha>();
}
