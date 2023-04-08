using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class QuanTriVien
{
    [DisplayName("Mã quản trị viên: ")]
    public int Id { get; set; }

    [DisplayName("Tên quản trị viên: ")]
    [Required(ErrorMessage = "Vui lòng nhập tên quản trị viên")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Tên admin không hợp lệ")]
    public string NameAd { get; set; } = null!;

    [DisplayName("Mật khẩu: ")]
    [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ cái in hoa, in thường, số và ký tự đặc biệt")]
    public string PassAd { get; set; } = null!;

    public int IsDeleted { get; set; }
}
