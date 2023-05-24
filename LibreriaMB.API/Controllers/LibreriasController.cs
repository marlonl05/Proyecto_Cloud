using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibreriaMB.Modelos;

namespace LibreriaMB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibreriasController : ControllerBase
    {
        private readonly DataContext _context;

        public LibreriasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Librerias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libreria>>> GetLibreria()
        {
          if (_context.Libreria == null)
          {
              return NotFound();
          }
            return await _context.Libreria.Include(p=> p.Libros).ToListAsync();
        }

        // GET: api/Librerias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libreria>> GetLibreria(int id)
        {
          if (_context.Libreria == null)
          {
              return NotFound();
          }
            var libreria = _context.Libreria.Include(p=>p.Libros).First
                (p=>p.LibreriaId==id);

            if (libreria == null)
            {
                return NotFound();
            }

            return libreria;
        }

        // PUT: api/Librerias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibreria(int id, Libreria libreria)
        {
            if (id != libreria.LibreriaId)
            {
                return BadRequest();
            }

            _context.Entry(libreria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibreriaExists(id))
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

        // POST: api/Librerias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Libreria>> PostLibreria(Libreria libreria)
        {
          if (_context.Libreria == null)
          {
              return Problem("Entity set 'DataContext.Libreria'  is null.");
          }
            _context.Libreria.Add(libreria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibreria", new { id = libreria.LibreriaId }, libreria);
        }

        // DELETE: api/Librerias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibreria(int id)
        {
            if (_context.Libreria == null)
            {
                return NotFound();
            }
            var libreria = await _context.Libreria.FindAsync(id);
            if (libreria == null)
            {
                return NotFound();
            }

            _context.Libreria.Remove(libreria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibreriaExists(int id)
        {
            return (_context.Libreria?.Any(e => e.LibreriaId == id)).GetValueOrDefault();
        }
    }
}
