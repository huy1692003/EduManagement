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
    public class BaiKiemTraController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BaiKiemTraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BaiKiemTra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaiKiemTra>>> GetBaiKiemTras()
        {
            return await _context.BaiKiemTras.ToListAsync();
        }

        // GET: api/BaiKiemTra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaiKiemTra>> GetBaiKiemTra(int id)
        {
            var baiKiemTra = await _context.BaiKiemTras.FindAsync(id);

            if (baiKiemTra == null)
            {
                return NotFound();
            }

            return baiKiemTra;
        }

        // GET: api/BaiKiemTra/search/{maBKT}
        [HttpGet("search/{maBKT}")]
        public async Task<ActionResult<BaiKiemTra>> GetBaiKiemTraByMa(string maBKT)
        {
            var baiKiemTra = await _context.BaiKiemTras
                .FirstOrDefaultAsync(b => b.MaBKT == maBKT);

            if (baiKiemTra == null)
            {
                return NotFound();
            }

            return baiKiemTra;
        }

        // PUT: api/BaiKiemTra/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaiKiemTra(int id, BaiKiemTra baiKiemTra)
        {
            if (id != baiKiemTra.BaiKiemTraId)
            {
                return BadRequest();
            }

            _context.Entry(baiKiemTra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaiKiemTraExists(id))
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

        // POST: api/BaiKiemTra
        [HttpPost]
        public async Task<ActionResult<BaiKiemTra>> PostBaiKiemTra(BaiKiemTra baiKiemTra)
        {
            _context.BaiKiemTras.Add(baiKiemTra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaiKiemTra", new { id = baiKiemTra.BaiKiemTraId }, baiKiemTra);
        }
        [HttpGet("giangvien/{id}")]
        public async Task<ActionResult<IEnumerable<BaiKiemTra>>> GetBaiKiemTraByGiangVienId(int id)
        {
            var baiKiemTras = await _context.BaiKiemTras
                .Include(b => b.KhoaHoc)
                .Where(b => b.KhoaHoc.GiangVienId == id)
                .ToListAsync();

            return Ok(baiKiemTras);
        }

        // DELETE: api/BaiKiemTra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaiKiemTra(int id)
        {
            var baiKiemTra = await _context.BaiKiemTras.FindAsync(id);
            if (baiKiemTra == null)
            {
                return NotFound();
            }

            _context.BaiKiemTras.Remove(baiKiemTra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaiKiemTraExists(int id)
        {
            return _context.BaiKiemTras.Any(e => e.BaiKiemTraId == id);
        }
    }
}
