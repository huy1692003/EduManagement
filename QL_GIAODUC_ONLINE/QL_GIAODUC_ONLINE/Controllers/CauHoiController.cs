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
    public class CauHoiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CauHoiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CauHoi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CauHoi>>> GetCauHois()
        {
            return await _context.CauHois.ToListAsync();
        }

        // GET: api/CauHoi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CauHoi>> GetCauHoi(int id)
        {
            var cauHoi = await _context.CauHois.FindAsync(id);

            if (cauHoi == null)
            {
                return NotFound();
            }

            return cauHoi;
        }

        // GET: api/CauHoi/baikiemtra/5
        [HttpGet("baikiemtra/{id}")]
        public async Task<ActionResult<IEnumerable<CauHoi>>> GetCauHoiByBaiKiemTraId(int id)
        {
            var cauHois = await (from c in _context.CauHois
                                where c.BaiKiemTraId == id
                                select new
                                {
                                    c.CauHoiId,
                                    c.NoiDung,
                                    c.Diem,
                                    c.BaiKiemTraId,
                                    luaChons = _context.LuaChons.Where(l => l.CauHoiId == c.CauHoiId).ToList()
                                }).ToListAsync();

            return Ok(cauHois);
        }

        // PUT: api/CauHoi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCauHoi(int id, CauHoi cauHoi)
        {
            if (id != cauHoi.CauHoiId)
            {
                return BadRequest();
            }

            _context.Entry(cauHoi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CauHoiExists(id))
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

        // POST: api/CauHoi
        [HttpPost]
        public async Task<ActionResult<CauHoi>> PostCauHoi(CauHoi cauHoi)
        {
            _context.CauHois.Add(cauHoi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCauHoi", new { id = cauHoi.CauHoiId }, cauHoi);
        }

        // DELETE: api/CauHoi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCauHoi(int id)
        {
            var cauHoi = await _context.CauHois.FindAsync(id);
            if (cauHoi == null)
            {
                return NotFound();
            }

            _context.CauHois.Remove(cauHoi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CauHoiExists(int id)
        {
            return _context.CauHois.Any(e => e.CauHoiId == id);
        }
    }
}
