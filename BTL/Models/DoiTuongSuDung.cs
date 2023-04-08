using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class DoiTuongSuDung
{
    public int MaDtsd { get; set; }

    public string TenDtsd { get; set; } = null!;

    public virtual ICollection<ThongTinNha> ThongTinNhas { get; } = new List<ThongTinNha>();
}
