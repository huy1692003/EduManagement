using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HETHONG_QUANLY_GIAODUC_MVC.Models
{
    [Table("HocVien_KhoaHoc")]
    public class HocVien_KhoaHoc
    {
        [Key]
        public int? HocVien_KhoaHocId { get; set; }

        [Required]
        public int? HocVienId { get; set; }
        public HocVien? HocVien { get; set; }

        [Required]
        public int? KhoaHocId { get; set; }
        public KhoaHoc? KhoaHoc { get; set; }
    }
}
