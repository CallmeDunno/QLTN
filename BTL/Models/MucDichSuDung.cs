using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class MucDichSuDung
{
    public int MaMdsd { get; set; }

    public string TenMdsd { get; set; } = null!;

    public virtual ICollection<ThongTinNha> ThongTinNhas { get; } = new List<ThongTinNha>();
}
