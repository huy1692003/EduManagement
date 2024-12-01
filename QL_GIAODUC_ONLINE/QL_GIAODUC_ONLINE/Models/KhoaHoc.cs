using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HETHONG_QUANLY_GIAODUC_MVC.Models
{
    [Table("KhoaHoc")]
    public class KhoaHoc
    {
        [Key]
        public int KhoaHocId { get; set; }

        [Required]
        [StringLength(100)]
        public string? TenKhoaHoc { get; set; }

        [StringLength(255)]
        public string? MoTa { get; set; }
        public string? noidung { get; set; }

        [Required]
        public int? GiangVienId { get; set; }
        public GiangVien? GiangVien { get; set; }
        public string? Image { get; set; }
    }
}
