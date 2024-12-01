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
    public class HocVien_KhoaHocController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HocVien_KhoaHocController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HocVien_KhoaHoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HocVien_KhoaHoc>>> GetHocVien_KhoaHocs()
        {
            var hocVienKhoaHocs = await _context.HocVien_KhoaHocs
                .Include(hk => hk.KhoaHoc)
                .Include(hk => hk.HocVien)
                .ToListAsync();
            return Ok(hocVienKhoaHocs);
        }

        // GET: api/HocVien_KhoaHoc/hocvien/{hocvienId}
        [HttpGet("hocvien/{hocvienId}")]
        public async Task<ActionResult<IEnumerable<HocVien_KhoaHoc>>> GetHocVienKhoaHocsByHocVienId(int hocvienId)
        {
            var hocVienKhoaHocs = await _context.HocVien_KhoaHocs
                .Include(hk => hk.KhoaHoc)
                .Include(hk => hk.HocVien)
                .Where(hk => hk.HocVienId == hocvienId)
                .ToListAsync();

            return Ok(hocVienKhoaHocs);
        }

        // GET: api/HocVien_KhoaHoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HocVien_KhoaHoc>> GetHocVien_KhoaHoc(int id)
        {
            var hocVien_KhoaHoc = await _context.HocVien_KhoaHocs.FindAsync(id);

            if (hocVien_KhoaHoc == null)
            {
                return NotFound();
            }

            return hocVien_KhoaHoc;
        }

        // PUT: api/HocVien_KhoaHoc/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHocVien_KhoaHoc(int id, HocVien_KhoaHoc hocVien_KhoaHoc)
        {
            if (id != hocVien_KhoaHoc.HocVien_KhoaHocId)
            {
                return BadRequest();
            }

            _context.Entry(hocVien_KhoaHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HocVien_KhoaHocExists(id))
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

        // POST: api/HocVien_KhoaHoc
        [HttpPost]
        public async Task<ActionResult<HocVien_KhoaHoc>> PostHocVien_KhoaHoc(HocVien_KhoaHoc hocVien_KhoaHoc)
        {
            

            if (_context.HocVien_KhoaHocs.FirstOrDefault(s=>s.HocVienId==hocVien_KhoaHoc.HocVienId&&s.KhoaHocId==hocVien_KhoaHoc.KhoaHocId)!=null)
            {
                return BadRequest();
            }    
            _context.HocVien_KhoaHocs.Add(hocVien_KhoaHoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHocVien_KhoaHoc", new { id = hocVien_KhoaHoc.HocVien_KhoaHocId }, hocVien_KhoaHoc);
        }

        // DELETE: api/HocVien_KhoaHoc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHocVien_KhoaHoc(int id)
        {
            var hocVien_KhoaHoc = await _context.HocVien_KhoaHocs.FindAsync(id);
            if (hocVien_KhoaHoc == null)
            {
                return NotFound();
            }

            _context.HocVien_KhoaHocs.Remove(hocVien_KhoaHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HocVien_KhoaHocExists(int id)
        {
            return _context.HocVien_KhoaHocs.Any(e => e.HocVien_KhoaHocId == id);
        }
    }
}
