using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HETHONG_QUANLY_GIAODUC_MVC.Models
{
    [Table("HocVien")]
    public class HocVien
    {
        [Key]
        public int? HocVienId { get; set; }

        [Required]
        [ForeignKey("TaiKhoanId")]

        public int? TaiKhoanId { get; set; }
        public TaiKhoan? TaiKhoan { get; set; }

        [Required]
        [StringLength(100)]
        public string? TenHocVien { get; set; }

        [Required]
        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(15)]
        public string? SoDienThoai { get; set; }
    }
}
