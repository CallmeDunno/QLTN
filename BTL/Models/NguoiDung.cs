using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class NguoiDung
{
    public int MaNguoiDung { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên người dùng")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Tên người dùng không hợp lệ")]
    public string TenNguoiDung { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ cái in hoa, in thường, số và ký tự đặc biệt")]
    public string MatKhau { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Số điện thoại đủ 10 số")]
    public string Sdt { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập email")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email không đúng định dạng")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
    [RegularExpression(@"^[a-zA-Z0-9\s,'-]*$", ErrorMessage = "Địa chỉ không hợp lệ")]
    public string DiaChi { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
    [RegularExpression(@"^([0-9]{2})/([0-9]{2})/([0-9]{4})$", ErrorMessage = "Ngày sinh không đúng định dạng dd/MM/yyyy.")]
    public DateTime NgaySinh { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập nghề nghiệp")]
    [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Nghề nghiệp chỉ được phép chứa ký tự chữ cái và khoảng trắng.")]
    public string NgheNghiep { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng chọn ảnh")]
    [RegularExpression(@"\.(jpg|jpeg|png|gif)$", ErrorMessage = "Vui lòng chỉ chọn file ảnh định dạng JPG, JPEG, PNG hoặc GIF.")]
    public string? AnhNguoiDung { get; set; }

    public int IsDeleted { get; set; }

    public virtual ICollection<DanhGiaNha> DanhGiaNhas { get; } = new List<DanhGiaNha>();

    public virtual ICollection<HopDongNha> HopDongNhas { get; } = new List<HopDongNha>();
}
