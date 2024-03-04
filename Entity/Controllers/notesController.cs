using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entity.Models;

namespace Entity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class notesController : ControllerBase
    {
        private readonly EntityStartContext _context;

        public notesController(EntityStartContext context)
        {
            _context = context;
        }

        // GET: api/notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<note>>> Getnotes()
        {
            return await _context.notes.ToListAsync();
        }

        // GET: api/notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<note>> Getnote(int id)
        {
            var note = await _context.notes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        // PUT: api/notes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putnote(int id, note note)
        {
            if (id != note.id)
            {
                return BadRequest();
            }

            _context.Entry(note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!noteExists(id))
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

        // POST: api/notes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<note>> Postnote(note note)
        {
            _context.notes.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getnote", new { id = note.id }, note);
        }

        // DELETE: api/notes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletenote(int id)
        {
            var note = await _context.notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            _context.notes.Remove(note);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool noteExists(int id)
        {
            return _context.notes.Any(e => e.id == id);
        }
    }
}
