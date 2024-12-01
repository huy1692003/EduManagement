using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HETHONG_QUANLY_GIAODUC_MVC.Models
{
    [Table("GiangVien")]
    public class GiangVien
    {
        [Key]
        public int? GiangVienId { get; set; }

        [ForeignKey("TaiKhoanId")]
        public int? TaiKhoanId { get; set; }
        public TaiKhoan? TaiKhoan { get; set; }

        [StringLength(100)]
        public string? TenGiangVien { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(15)]
        public string? SoDienThoai { get; set; }
        public string? Image { get; set; }
    }
}
