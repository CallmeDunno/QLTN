using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class DanhGiaNha
{
    [DisplayName("Mã đánh giá: ")]
    public int MaDanhGia { get; set; }

    [DisplayName("Nội dung đánh giá: ")]
    [Required(ErrorMessage = "Vui lòng nhập nội dung đánh giá")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Nội dung đánh giá bao gồm chữ thường, in hoa và số.")]
    public string NoiDung { get; set; } = null!;

    [DisplayName("Ngày đánh giá: ")]
    [Required(ErrorMessage = "Vui lòng nhập ngày đánh giá")]
    [RegularExpression(@"^([0-9]{2})/([0-9]{2})/([0-9]{4})$", ErrorMessage = "Ngày đánh giá không đúng định dạng dd/MM/yyyy.")]
    public DateTime NgayDanhGia { get; set; }

    public int MaNguoiDung { get; set; }

    public int MaNha { get; set; }

    public int IsDeleted { get; set; }

    public virtual NguoiDung MaNguoiDungNavigation { get; set; } = null!;

    public virtual ThongTinNha MaNhaNavigation { get; set; } = null!;
}
