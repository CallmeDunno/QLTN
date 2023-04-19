using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class NguoiDung
{
    [DisplayName("Mã người dùng: ")]
    public int MaNguoiDung { get; set; }

    [DisplayName("Tên người dùng: ")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Tên người dùng không hợp lệ")]
    public string TenNguoiDung { get; set; } = null!;

    [DisplayName("Số điện thoại: ")]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Số điện thoại đủ 10 số")]
    public string Sdt { get; set; } = null!;

    [DisplayName("Email: ")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email không đúng định dạng")]
    public string Email { get; set; } = null!;

    [DisplayName("Địa chỉ: ")]
    [RegularExpression(@"^[a-zA-Z0-9\s,'-]*$", ErrorMessage = "Địa chỉ không hợp lệ")]
    public string DiaChi { get; set; } = null!;

    public virtual ICollection<HopDongNha> HopDongNhas { get; } = new List<HopDongNha>();
}
