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
    public class GiangVienController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GiangVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GiangVien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiangVien>>> GetGiangViens()
        {
            var giangViens = await _context.GiangViens
                .Include(g => g.TaiKhoan)
                .ToListAsync();
            return Ok(giangViens);
        }

        // GET: api/GiangVien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GiangVien>> GetGiangVien(int id)
        {
            var giangVien = await _context.GiangViens
                .Include(g => g.TaiKhoan)
                .FirstOrDefaultAsync(g => g.GiangVienId == id);

            if (giangVien == null)
            {
                return NotFound();
            }

            return giangVien;
        }

        // GET: api/GiangVien/5/baikiemtra
       
        // PUT: api/GiangVien/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiangVien(int id, GiangVien giangVien)
        {
            if (id != giangVien.GiangVienId)
            {
                return BadRequest();
            }

            _context.Entry(giangVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiangVienExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/GiangVien
        [HttpPost]
        public async Task<ActionResult<GiangVien>> PostGiangVien(GiangVien giangVien)
        {
            giangVien.GiangVienId = null;
            giangVien.TaiKhoan.TaiKhoanId = null;
            giangVien.TaiKhoan.LoaiTaiKhoan = 2;
            _context.GiangViens.Add(giangVien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGiangVien", new { id = giangVien.GiangVienId }, giangVien);
        }

        // DELETE: api/GiangVien/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiangVien(int id)
        {
            var giangVien = await _context.GiangViens.FindAsync(id);
            if (giangVien == null)
            {
                return NotFound();
            }

            _context.GiangViens.Remove(giangVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiangVienExists(int id)
        {
            return _context.GiangViens.Any(e => e.GiangVienId == id);
        }
    }
}
