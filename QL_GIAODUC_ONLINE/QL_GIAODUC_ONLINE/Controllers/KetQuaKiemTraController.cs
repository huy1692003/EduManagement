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
    public class KetQuaKiemTraController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KetQuaKiemTraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/KetQuaKiemTra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KetQuaKiemTra>>> GetKetQuaKiemTras()
        {
            return await _context.KetQuaKiemTras.ToListAsync();
        }

        // GET: api/KetQuaKiemTra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KetQuaKiemTra>> GetKetQuaKiemTra(int id)
        {
            var ketQuaKiemTra = await _context.KetQuaKiemTras.FindAsync(id);

            if (ketQuaKiemTra == null)
            {
                return NotFound();
            }

            return ketQuaKiemTra;
        }

        // POST: api/KetQuaKiemTra
        [HttpPost]
        public async Task<ActionResult<KetQuaKiemTra>> PostKetQuaKiemTra(KetQuaKiemTra ketQuaKiemTra)
        {
            _context.KetQuaKiemTras.Add(ketQuaKiemTra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKetQuaKiemTra", new { id = ketQuaKiemTra.KetQuaKiemTraId }, ketQuaKiemTra);
        }

        // DELETE: api/KetQuaKiemTra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKetQuaKiemTra(int id)
        {
            var ketQuaKiemTra = await _context.KetQuaKiemTras.FindAsync(id);
            if (ketQuaKiemTra == null)
            {
                return NotFound();
            }

            _context.KetQuaKiemTras.Remove(ketQuaKiemTra);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

