using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class DichVu
{
    public int MaDichVu { get; set; }

    public string TenDichVu { get; set; } = null!;

    public virtual ICollection<NhaDichVu> NhaDichVus { get; } = new List<NhaDichVu>();
}
