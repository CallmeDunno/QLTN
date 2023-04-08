using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class ChuNha
{
    [DisplayName("Mã chủ nhà: ")]
    public int MaChuNha { get; set; }

    [DisplayName("Tên chủ nhà: ")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Tên chủ nhà không hợp lệ")]
    public string TenChuNha { get; set; } = null!;

    [DisplayName("Địa chỉ chủ nhà: ")]
    [RegularExpression(@"^[a-zA-Z0-9\s,'-]*$", ErrorMessage = "Địa chỉ không hợp lệ")]
    public string DiaChi { get; set; } = null!;

    [DisplayName("Ngày sinh: ")]
    [RegularExpression(@"^([0-9]{2})/([0-9]{2})/([0-9]{4})$", ErrorMessage = "Ngày sinh không đúng định dạng dd/MM/yyyy.")]
    public DateTime NgaySinh { get; set; }

    [DisplayName("Số điện thoại: ")]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Số điện thoại đủ 10 số")]
    public string SdtchuNha { get; set; } = null!;

    [DisplayName("Số điện thoại 2: ")]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Số điện thoại đủ 10 số")]
    public string? SdtchuNha2 { get; set; }

    [DisplayName("Email chủ nhà: ")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email không đúng định dạng")]
    public string Email { get; set; } = null!;

    [DisplayName("Ảnh chủ nhà: ")]
    [RegularExpression(@"\.(jpg|jpeg|png|gif)$", ErrorMessage = "Vui lòng chỉ chọn file ảnh định dạng JPG, JPEG, PNG hoặc GIF.")]
    public string AnhChuNha { get; set; } = null!;

    [DisplayName("Mô tả chủ nhà: ")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Mô tả chủ nhà bao gồm chữ thường, in hoa và số.")]
    public string MoTaChuNha { get; set; } = null!;

    public virtual ICollection<ThongTinNha> ThongTinNhas { get; } = new List<ThongTinNha>();
}
