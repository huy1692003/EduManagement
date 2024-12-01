using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HETHONG_QUANLY_GIAODUC_MVC.DATA;
using HETHONG_QUANLY_GIAODUC_MVC.Models;
using static HETHONG_QUANLY_GIAODUC_MVC.DATA.DBContext;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace QL_GIAODUC_ONLINE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocVienController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HocVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HocVien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HocVien>>> GetHocViens()
        {
            return await _context.HocViens.Include(s=>s.TaiKhoan).ToListAsync();
        }

        // GET: api/HocVien/khoahoc/{khoahocId}
        [HttpGet("khoahoc/{khoahocId}")]
        public async Task<ActionResult<IEnumerable<HocVien>>> GetHocViensByKhoaHoc(int khoahocId)
        {
            var hocViens = await _context.HocVien_KhoaHocs
                .Where(hk => hk.KhoaHocId == khoahocId)
                .Include(hk => hk.HocVien)
                    .ThenInclude(h => h.TaiKhoan)
                .Include(hk => hk.KhoaHoc)
                .Select(hk => hk.HocVien)
                .ToListAsync();

            if (!hocViens.Any())
            {
                return Ok(new List<HocVien>());
            }

            return Ok(hocViens);
        }

        // GET: api/HocVien/giangvien/{giangvienId}
        [HttpGet("giangvien/{giangvienId}")]
        public async Task<ActionResult<IEnumerable<HocVien>>> GetHocViensByGiangVien(int giangvienId)
        {
            var hocViens = await _context.HocVien_KhoaHocs
                .Where(hk => hk.KhoaHoc.GiangVienId == giangvienId)
                .Include(hk => hk.HocVien)
                    .ThenInclude(h => h.TaiKhoan)
                .Include(hk => hk.KhoaHoc)
                .Select(hk => hk.HocVien)
                .Distinct()
                .ToListAsync();

            if (!hocViens.Any())
            {
                return NotFound();
            }

            return Ok(hocViens);
        }

        // GET: api/HocVien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HocVien>> GetHocVien(int id)
        {
            var hocVien = await _context.HocViens.FindAsync(id);

            if (hocVien == null)
            {
                return NotFound();
            }

            return hocVien;
        }

        // GET: api/HocVien/ketqua/{id}
        [HttpGet("ketqua/{id}")]
        public async Task<IActionResult> GetKetQuaHocTap(int id)
        {
            var hocVien = await _context.HocViens
                .Include(h => h.TaiKhoan)
                .FirstOrDefaultAsync(h => h.HocVienId == id);

            if (hocVien == null)
            {
                return NotFound();
            }

            var ketQuaKiemTras = await _context.KetQuaKiemTras
                .Include(k => k.BaiKiemTra)
                    .ThenInclude(b => b.KhoaHoc)
                .Where(k => k.HocVienId == id)
                .ToListAsync();

            // Tạo PDF document
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                // Đăng ký font chữ
                string fontPath = Path.Combine(Directory.GetCurrentDirectory(), "fonts", "arial.ttf");
                BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                document.Open();

                // Thêm tiêu đề
                Font titleFont = new Font(baseFont, 18, Font.BOLD);
                Paragraph title = new Paragraph("KẾT QUẢ HỌC TẬP", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph("\n"));

                // Thông tin học viên
                Font normalFont = new Font(baseFont, 12);
                document.Add(new Paragraph($"Học viên: {hocVien.TenHocVien}", normalFont));
                document.Add(new Paragraph($"Email: {hocVien.Email}", normalFont));
                document.Add(new Paragraph($"Số điện thoại: {hocVien.SoDienThoai}", normalFont));
                document.Add(new Paragraph("\n"));

                // Tạo bảng kết quả
                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;

                // Header của bảng
                table.AddCell(new PdfPCell(new Phrase("Khóa học", normalFont)));
                table.AddCell(new PdfPCell(new Phrase("Bài kiểm tra", normalFont)));
                table.AddCell(new PdfPCell(new Phrase("Điểm", normalFont)));
                table.AddCell(new PdfPCell(new Phrase("Ngày thi", normalFont)));

                // Dữ liệu bảng
                double diemTrungBinh = 0;
                int soLuongBaiKiemTra = 0;
                foreach (var ketQua in ketQuaKiemTras)
                {
                    table.AddCell(new PdfPCell(new Phrase(ketQua.BaiKiemTra?.KhoaHoc?.TenKhoaHoc ?? "", normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(ketQua.BaiKiemTra?.TenBaiKiemTra ?? "", normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(ketQua.Diem?.ToString() ?? "0", normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(ketQua.BaiKiemTra?.NgayTao?.ToString("dd/MM/yyyy") ?? "", normalFont)));
                    
                    if (ketQua.Diem.HasValue)
                    {
                        diemTrungBinh += ketQua.Diem.Value;
                        soLuongBaiKiemTra++;
                    }
                }

                document.Add(table);
                document.Add(new Paragraph("\n"));

                // Thêm nhận xét
                if (soLuongBaiKiemTra > 0)
                {
                    diemTrungBinh /= soLuongBaiKiemTra;
                    Font commentFont = new Font(baseFont, 12, Font.BOLD);
                    document.Add(new Paragraph("NHẬN XÉT:", commentFont));
                    document.Add(new Paragraph($"Điểm trung bình: {diemTrungBinh:F2}", normalFont));
                    
                    string nhanXet = "";
                    if (diemTrungBinh >= 8.5)
                    {
                        nhanXet = "Xuất sắc - Học viên có kết quả học tập rất tốt, cần duy trì phong độ này.";
                    }
                    else if (diemTrungBinh >= 7.0)
                    {
                        nhanXet = "Khá - Học viên có kết quả học tập tốt, cần cố gắng hơn nữa để đạt kết quả cao hơn.";
                    }
                    else if (diemTrungBinh >= 5.5)
                    {
                        nhanXet = "Trung bình - Học viên cần nỗ lực nhiều hơn trong việc học tập.";
                    }
                    else
                    {
                        nhanXet = "Cần cải thiện - Học viên cần đầu tư thêm thời gian và nỗ lực để cải thiện kết quả học tập.";
                    }
                    
                    document.Add(new Paragraph($"Đánh giá: {nhanXet}", normalFont));
                }
                else
                {
                    document.Add(new Paragraph("Học viên chưa có kết quả kiểm tra nào.", normalFont));
                }

                document.Close();

                byte[] pdfBytes = ms.ToArray();
                return File(pdfBytes, "application/pdf", $"KetQuaHocTap_{hocVien.TenHocVien}.pdf");
            }
        }

        // PUT: api/HocVien/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHocVien(int id, HocVien hocVien)
        {
            if (id != hocVien.HocVienId)
            {
                return BadRequest();
            }

            _context.Entry(hocVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HocVienExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HocVien
        [HttpPost]
        public async Task<ActionResult<HocVien>> PostHocVien(HocVien hocVien)
        {
            hocVien.HocVienId = null;
            hocVien.TaiKhoan.TaiKhoanId = null;
            _context.HocViens.Add(hocVien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHocVien", new { id = hocVien.HocVienId }, hocVien);
        }

        // DELETE: api/HocVien/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHocVien(int id)
        {
            var hocVien = await _context.HocViens.FindAsync(id);
            if (hocVien == null)
            {
                return NotFound();
            }

            _context.HocViens.Remove(hocVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HocVienExists(int id)
        {
            return _context.HocViens.Any(e => e.HocVienId == id);
        }
    }
}
