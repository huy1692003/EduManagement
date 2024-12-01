using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HETHONG_QUANLY_GIAODUC_MVC.DATA;
using HETHONG_QUANLY_GIAODUC_MVC.Models;
using static HETHONG_QUANLY_GIAODUC_MVC.DATA.DBContext;

namespace QL_GIAODUC_ONLINE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoaHocController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KhoaHocController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/KhoaHoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhoaHoc>>> GetKhoaHocs()
        {
            var khoaHocs = await _context.KhoaHocs
                .Include(k => k.GiangVien) // Include thông tin giảng viên
                .ToListAsync();
            return Ok(khoaHocs);
        }

        // GET: api/KhoaHoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhoaHoc>> GetKhoaHoc(int id)
        {
            var khoaHoc = await _context.KhoaHocs.FindAsync(id);

            if (khoaHoc == null)
            {
                return NotFound();
            }

            return khoaHoc;
        }

        // GET: api/KhoaHoc/user/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<KhoaHoc>>> GetKhoaHocByUser(int userId)
        {
            var giangVien = await _context.GiangViens
                .FirstOrDefaultAsync(g => g.TaiKhoanId == userId);

            if (giangVien == null)
            {
                return Ok(new List<KhoaHoc>());
            }

            var khoaHocs = await _context.KhoaHocs
                .Where(k => k.GiangVienId == giangVien.GiangVienId)
                .Include(k => k.GiangVien)
                .ToListAsync();

            return Ok(khoaHocs);
        }

        // PUT: api/KhoaHoc/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhoaHoc(int id, KhoaHoc khoaHoc)
        {
            if (id != khoaHoc.KhoaHocId)
            {
                return BadRequest();
            }

            _context.Entry(khoaHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhoaHocExists(id))
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

        // POST: api/KhoaHoc
        [HttpPost]
        public async Task<ActionResult<KhoaHoc>> PostKhoaHoc(KhoaHoc khoaHoc)
        {
            _context.KhoaHocs.Add(khoaHoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKhoaHoc", new { id = khoaHoc.KhoaHocId }, khoaHoc);
        }

        // DELETE: api/KhoaHoc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoaHoc(int id)
        {
            var khoaHoc = await _context.KhoaHocs.FindAsync(id);
            if (khoaHoc == null)
            {
                return NotFound();
            }

            _context.KhoaHocs.Remove(khoaHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhoaHocExists(int id)
        {
            return _context.KhoaHocs.Any(e => e.KhoaHocId == id);
        }
    }
}
