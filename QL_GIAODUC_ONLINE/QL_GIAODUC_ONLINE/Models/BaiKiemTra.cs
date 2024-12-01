using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HETHONG_QUANLY_GIAODUC_MVC.Models
{
    [Table("BaiKiemTra")]
    public class BaiKiemTra
    {
        [Key]
        public int BaiKiemTraId { get; set; }
        public string MaBKT { get; set; }

        [StringLength(100)]
        public string? TenBaiKiemTra { get; set; }

        public int? KhoaHocId { get; set; } 
        public int? GiangVienID { get; set; }
        public KhoaHoc? KhoaHoc { get; set; }

        public int? ThoiLuong { get; set; } // Tính bằng phút

        public DateTime? NgayTao { get; set; } = DateTime.Now;
    }
}
