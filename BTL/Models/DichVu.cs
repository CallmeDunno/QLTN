using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class DichVu
{
    public int MaDichVu { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên dịch vụ")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Tên dịch vụ không hợp lệ")]
    public string TenDichVu { get; set; } = null!;

    public virtual ICollection<NhaDichVu> NhaDichVus { get; } = new List<NhaDichVu>();
}
