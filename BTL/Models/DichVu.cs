using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class DichVu
{
    [DisplayName("Mã dịch vụ: ")]
    public int MaDichVu { get; set; }

    [DisplayName("Tên dịch vụ: ")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Tên dịch vụ không hợp lệ")]
    public string TenDichVu { get; set; } = null!;

    public virtual ICollection<NhaDichVu> NhaDichVus { get; } = new List<NhaDichVu>();
}
