using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class TaiSan
{
    public int MaTaiSan { get; set; }

    public string TenTaiSan { get; set; } = null!;

    public virtual ICollection<NhaTaiSan> NhaTaiSans { get; } = new List<NhaTaiSan>();
}
