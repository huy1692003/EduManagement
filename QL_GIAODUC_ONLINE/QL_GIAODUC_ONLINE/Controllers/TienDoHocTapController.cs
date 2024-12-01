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
    public class TienDoHocTapController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TienDoHocTapController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TienDoHocTap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TienDoHocTap>>> GetTienDoHocTaps()
        {
            return await _context.TienDoHocTaps
                .Include(t => t.HocVien)
                .Include(t => t.KhoaHoc)
                .Include(t => t.BaiHoc)
                .ToListAsync();
        }

        // GET: api/TienDoHocTap/khoahoc/{khoaHocId}/hocvien/{hocVienId}
        [HttpGet("khoahoc/{khoaHocId}/hocvien/{hocVienId}")]
        public async Task<ActionResult<IEnumerable<TienDoHocTap>>> GetTienDoByKhoaHocAndHocVien(int khoaHocId, int hocVienId)
        {
            var tienDoList = await _context.TienDoHocTaps
                .Include(t => t.HocVien)
                .Include(t => t.KhoaHoc)
                .Include(t => t.BaiHoc)
                .Where(t => t.KhoaHocId == khoaHocId && t.HocVienId == hocVienId)
                .ToListAsync();

            if (tienDoList == null || !tienDoList.Any())
            {
                return Ok(new List<TienDoHocTap>());
            }

            return tienDoList;
        }

        // GET: api/TienDoHocTap/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TienDoHocTap>> GetTienDoHocTap(int id)
        {
            var tienDoHocTap = await _context.TienDoHocTaps
                .Include(t => t.HocVien)
                .Include(t => t.KhoaHoc)
                .Include(t => t.BaiHoc)
                .FirstOrDefaultAsync(t => t.TienDoHocTapId == id);

            if (tienDoHocTap == null)
            {
                return NotFound();
            }

            return tienDoHocTap;
        }

        // POST: api/TienDoHocTap
        [HttpPost]
        public async Task<ActionResult<TienDoHocTap>> PostTienDoHocTap(TienDoHocTap tienDoHocTap)
        {
            var existingTienDo = await _context.TienDoHocTaps
                .FirstOrDefaultAsync(t => t.HocVienId == tienDoHocTap.HocVienId 
                    && t.KhoaHocId == tienDoHocTap.KhoaHocId
                    && t.BaiHocId == tienDoHocTap.BaiHocId);

            if (existingTienDo != null)
            {
                return Ok();
            }

            tienDoHocTap.NgayHoanThanh=DateTime.Now;
            _context.TienDoHocTaps.Add(tienDoHocTap);
            await _context.SaveChangesAsync();
        
            return CreatedAtAction("GetTienDoHocTap", new { id = tienDoHocTap.TienDoHocTapId }, tienDoHocTap);
        }

        // PUT: api/TienDoHocTap/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTienDoHocTap(int id, TienDoHocTap tienDoHocTap)
        {
            if (id != tienDoHocTap.TienDoHocTapId)
            {
                return BadRequest();
            }

            _context.Entry(tienDoHocTap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TienDoHocTapExists(id))
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

        // PUT: api/TienDoHocTap/5/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateTrangThai(int id, [FromBody] int trangThai)
        {
            var tienDoHocTap = await _context.TienDoHocTaps.FindAsync(id);

            if (tienDoHocTap == null)
            {
                return NotFound();
            }

            tienDoHocTap.TrangThai = trangThai;
            if (trangThai==1)
            {
                tienDoHocTap.NgayHoanThanh = DateTime.Now;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TienDoHocTapExists(id))
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

        private bool TienDoHocTapExists(int id)
        {
            return _context.TienDoHocTaps.Any(e => e.TienDoHocTapId == id);
        }
    }
}
