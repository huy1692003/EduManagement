using HETHONG_QUANLY_GIAODUC_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace HETHONG_QUANLY_GIAODUC_MVC.DATA
{
    public class DBContext
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }

            // Khai báo các DbSet tương ứng với các bảng trong database
            public DbSet<TaiKhoan> TaiKhoans { get; set; }
            public DbSet<GiangVien> GiangViens { get; set; }
            public DbSet<HocVien> HocViens { get; set; }
            public DbSet<KhoaHoc> KhoaHocs { get; set; }
            public DbSet<HocVien_KhoaHoc> HocVien_KhoaHocs { get; set; }
            public DbSet<BaiKiemTra> BaiKiemTras { get; set; }
            public DbSet<CauHoi> CauHois { get; set; }
            public DbSet<LuaChon> LuaChons { get; set; }
            public DbSet<KetQuaKiemTra> KetQuaKiemTras { get; set; }
            public DbSet<BaiHoc> BaiHocs { get; set; }
            public DbSet<TienDoHocTap> TienDoHocTaps { get; set; }
        }
    }
}
