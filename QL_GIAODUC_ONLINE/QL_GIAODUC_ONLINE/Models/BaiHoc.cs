using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HETHONG_QUANLY_GIAODUC_MVC.Models
{
    [Table("BaiHoc")]
    public class BaiHoc
    {
        [Key]
        public int? BaiHocId { get; set; }

        public int? KhoaHocId { get; set; }
        public KhoaHoc? KhoaHoc { get; set; }

        [StringLength(100)]
        public string? TenBaiHoc { get; set; }

        public string? MoTa { get; set; }
        public string? noidung { get; set; }

        public int? ThoiGianHoanThanh { get; set; }  // Thời gian học bài (tính bằng phút)

        public DateTime? NgayTao { get; set; } = DateTime.Now;
        public DateTime? NgayCapNhat { get; set; } = DateTime.Now;
    }
}
