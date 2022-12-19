using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseMeme;

namespace DatabaseMeme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemeController : ControllerBase
    {
        private readonly MemeDbContext _context;

        public MemeController(MemeDbContext context)
        {
            _context = context;
        }

        //// GET: api/Meme
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Meme>>> GetMemes()
        //{
        //  if (_context.Memes == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Memes.ToArrayAsync();
        //}

        // GET: api/Meme/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meme>> GetMeme(long id)
        {
          if (_context.Memes == null)
          {
              return NotFound();
          }
            var meme = await _context.Memes.FindAsync(id);

            if (meme == null)
            {
                return NotFound();
            }

            return meme;
        }

        // PUT: api/Meme/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> PutMeme(long id, Meme meme)
        {
            if (id != meme.Id)
            {
                return BadRequest();
            }

            _context.Entry(meme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemeExists(id))
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

        // POST: api/Meme
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Meme>> PostMeme(MemeData meme)
        {
          if (_context.Memes == null)
          {
              return Problem("Entity set 'MemeDbContext.Memes'  is null.");
          }
            var m = new Meme();
            m.Id = meme.Id;
            m.Description = meme.Description;
            m.IdUser = meme.IdUser;
            _context.Memes.Add(m);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeme", new { id = m.Id }, m);
        }

        // DELETE: api/Meme/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeme(long id)
        {
            if (_context.Memes == null)
            {
                return NotFound();
            }
            var meme = await _context.Memes.FindAsync(id);
            if (meme == null)
            {
                return NotFound();
            }

            _context.Memes.Remove(meme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MemeExists(long id)
        {
            return (_context.Memes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
