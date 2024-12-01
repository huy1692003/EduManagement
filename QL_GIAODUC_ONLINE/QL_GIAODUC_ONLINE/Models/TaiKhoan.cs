using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HETHONG_QUANLY_GIAODUC_MVC.Models
{
    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        [Key]
        public int? TaiKhoanId { get; set; }

        [Required]
        [StringLength(50)]
        public string? TenDangNhap { get; set; }

        [Required]
        [StringLength(100)]
        public string? MatKhau { get; set; }
        [Required]
        public int? LoaiTaiKhoan { get; set; } // 1: Quản trị viên, 2: Giảng viên, 3: Học viên
       

         
    }
}
