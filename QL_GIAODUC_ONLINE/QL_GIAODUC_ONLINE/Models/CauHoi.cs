using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HETHONG_QUANLY_GIAODUC_MVC.Models
{
    [Table("CauHoi")]
    public class CauHoi
    {
        [Key]
        public int? CauHoiId { get; set; }

        public int? BaiKiemTraId { get; set; }
        public BaiKiemTra? BaiKiemTra { get; set; }

        [StringLength(255)]
        public string? NoiDung { get; set; }
        
        public List<LuaChon>? luaChons { get; set; }

        [Required]
        public double? Diem { get; set; }
    }
}
