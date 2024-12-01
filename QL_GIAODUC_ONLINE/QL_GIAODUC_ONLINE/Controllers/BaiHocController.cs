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
    public class BaiHocController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BaiHocController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BaiHoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaiHoc>>> GetBaiHocs()
        {
            return await _context.BaiHocs.ToListAsync();
        }

        // GET: api/BaiHoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaiHoc>> GetBaiHoc(int id)
        {
            var baiHoc = await _context.BaiHocs.FindAsync(id);

            if (baiHoc == null)
            {
                return NotFound();
            }

            return baiHoc;
        }

        // GET: api/BaiHoc/khoahoc/5
        [HttpGet("khoahoc/{khoaHocId}")]
        public async Task<ActionResult<IEnumerable<BaiHoc>>> GetBaiHocByKhoaHoc(int khoaHocId)
        {
            var baiHocs = await _context.BaiHocs
                .Where(b => b.KhoaHocId == khoaHocId)
                .ToListAsync();           

            return baiHocs;
        }

        // PUT: api/BaiHoc/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaiHoc(int id, BaiHoc baiHoc)
        {
            if (id != baiHoc.BaiHocId)
            {
                return BadRequest();
            }

            _context.Entry(baiHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaiHocExists(id))
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

        // POST: api/BaiHoc
        [HttpPost]
        public async Task<ActionResult<BaiHoc>> PostBaiHoc(BaiHoc baiHoc)
        {
            baiHoc.BaiHocId = null;
            _context.BaiHocs.Add(baiHoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaiHoc", new { id = baiHoc.BaiHocId }, baiHoc);
        }

        // DELETE: api/BaiHoc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaiHoc(int id)
        {
            var baiHoc = await _context.BaiHocs.FindAsync(id);
            if (baiHoc == null)
            {
                return NotFound();
            }

            _context.BaiHocs.Remove(baiHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaiHocExists(int id)
        {
            return _context.BaiHocs.Any(e => e.BaiHocId == id);
        }
    }
}
