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
    public class LuaChonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LuaChonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LuaChon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LuaChon>>> GetLuaChons()
        {
            return await _context.LuaChons.ToListAsync();
        }

        // GET: api/LuaChon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LuaChon>> GetLuaChon(int id)
        {
            var luaChon = await _context.LuaChons.FindAsync(id);

            if (luaChon == null)
            {
                return NotFound();
            }

            return luaChon;
        }

        // GET: api/LuaChon/cauhoi/5
        [HttpGet("cauhoi/{id}")]
        public async Task<ActionResult<IEnumerable<LuaChon>>> GetLuaChonByCauHoiId(int id)
        {
            var luaChons = await _context.LuaChons
                .Where(l => l.CauHoiId == id)
                .ToListAsync();

            return Ok(luaChons);
        }

        // PUT: api/LuaChon/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLuaChon(int id, LuaChon luaChon)
        {
            if (id != luaChon.LuaChonId)
            {
                return BadRequest();
            }

            _context.Entry(luaChon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LuaChonExists(id))
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

        // POST: api/LuaChon
        [HttpPost]
        public async Task<ActionResult<LuaChon>> PostLuaChon(LuaChon luaChon)
        {
            _context.LuaChons.Add(luaChon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLuaChon", new { id = luaChon.LuaChonId }, luaChon);
        }

        // DELETE: api/LuaChon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLuaChon(int id)
        {
            var luaChon = await _context.LuaChons.FindAsync(id);
            if (luaChon == null)
            {
                return NotFound();
            }

            _context.LuaChons.Remove(luaChon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LuaChonExists(int id)
        {
            return _context.LuaChons.Any(e => e.LuaChonId == id);
        }
    }
}
