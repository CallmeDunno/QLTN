using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class MucDichSuDung
{
    [DisplayName("Mã mục đích sử dụng: ")]
    public int MaMdsd { get; set; }

    [DisplayName("Tên mục đích sử dụng: ")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Mục đích sử dụng không hợp lệ")]
    public string TenMdsd { get; set; } = null!;

    public virtual ICollection<ThongTinNha> ThongTinNhas { get; } = new List<ThongTinNha>();
}
