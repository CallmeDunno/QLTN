using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class ChuNha
{
    public int MaChuNha { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên chủ nhà")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Tên chủ nhà không hợp lệ")]
    public string TenChuNha { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
    [RegularExpression(@"^[a-zA-Z0-9\s,'-]*$", ErrorMessage = "Địa chỉ không hợp lệ")]
    public string DiaChi { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
    [RegularExpression(@"^([0-9]{2})/([0-9]{2})/([0-9]{4})$", ErrorMessage = "Ngày sinh không đúng định dạng dd/MM/yyyy.")]
    public DateTime NgaySinh { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập số điện thoại 1")]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Số điện thoại đủ 10 số")]
    public string SdtchuNha { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập số điện thoại 2")]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Số điện thoại đủ 10 số")]
    public string? SdtchuNha2 { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập email")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email không đúng định dạng")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng chọn ảnh")]
    [RegularExpression(@"\.(jpg|jpeg|png|gif)$", ErrorMessage = "Vui lòng chỉ chọn file ảnh định dạng JPG, JPEG, PNG hoặc GIF.")]
    public string AnhChuNha { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập mô tả chủ nhà")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Mô tả chủ nhà bao gồm chữ thường, in hoa và số.")]
    public string MoTaChuNha { get; set; } = null!;

    public virtual ICollection<ThongTinNha> ThongTinNhas { get; } = new List<ThongTinNha>();
}
