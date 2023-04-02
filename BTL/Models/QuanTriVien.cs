using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class QuanTriVien
{
    public int Id { get; set; }

    public string NameAd { get; set; } = null!;

    public string PassAd { get; set; } = null!;

    public int IsDeleted { get; set; }
}
