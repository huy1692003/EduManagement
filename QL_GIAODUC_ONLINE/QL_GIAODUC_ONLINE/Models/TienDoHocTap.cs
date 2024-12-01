using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HETHONG_QUANLY_GIAODUC_MVC.Models
{
    [Table("TienDoHocTap")]
    public class TienDoHocTap
    {
        [Key]
        public int? TienDoHocTapId { get; set; }

        public int? HocVienId { get; set; }
        public HocVien? HocVien { get; set; }  // Mối quan hệ với học viên

        public int? KhoaHocId { get; set; }
        public KhoaHoc? KhoaHoc { get; set; }  // Mối quan hệ với khóa học

        public int? BaiHocId { get; set; }
        public BaiHoc? BaiHoc { get; set; }  // Mối quan hệ với bài học

        public int? TrangThai { get; set; }  // Trạng thái học (ví dụ: "Đang học", "Hoàn thành", v.v.)

        public DateTime? NgayHoanThanh { get; set; }  // Ngày hoàn thành bài học nếu có
    }
}
