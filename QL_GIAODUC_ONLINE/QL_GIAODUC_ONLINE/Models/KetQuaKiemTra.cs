using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HETHONG_QUANLY_GIAODUC_MVC.Models
{
    [Table("KetQuaKiemTra")]
    public class KetQuaKiemTra
    {
        [Key]
        public int? KetQuaKiemTraId { get; set; }

        
        public int? HocVienId { get; set; }
        public HocVien? HocVien { get; set; }

        
        public int? BaiKiemTraId { get; set; }
        public BaiKiemTra? BaiKiemTra { get; set; }

    

       
        
        
        public double? Diem { get; set; }
    }
}
