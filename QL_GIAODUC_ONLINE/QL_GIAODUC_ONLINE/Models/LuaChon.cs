using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HETHONG_QUANLY_GIAODUC_MVC.Models
{
    [Table("LuaChon")]
    public class LuaChon
    {
        [Key]
        public int? LuaChonId { get; set; }

        [Required]
        public int? CauHoiId { get; set; }
        public CauHoi? CauHoi { get; set; }

        [Required]
        [StringLength(255)]
        public string? NoiDung { get; set; }

        [Required]
        public bool? LaDapAnDung { get; set; } // true: Ðúng, false: Sai
    }
}
