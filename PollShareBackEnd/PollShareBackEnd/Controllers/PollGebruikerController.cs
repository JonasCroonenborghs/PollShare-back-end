using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PollShareBackEnd.Models;

namespace PollShareBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollGebruikerController : ControllerBase
    {
        private readonly PollShareContext _context;

        public PollGebruikerController(PollShareContext context)
        {
            _context = context;
        }

        // GET: api/PollGebruiker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PollGebruiker>>> GetPollGebruikers()
        {
            return await _context.PollGebruikers.ToListAsync();
        }

        // GET: api/PollGebruiker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PollGebruiker>> GetPollGebruiker(long id)
        {
            var pollGebruiker = await _context.PollGebruikers.FindAsync(id);

            if (pollGebruiker == null)
            {
                return NotFound();
            }

            return pollGebruiker;
        }

        // GET: api/Poll/poll/naam
        [HttpGet("pollID")]
        public async Task<ActionResult<IEnumerable<PollGebruiker>>> GetPollGebruikersByPollID(long pollID)
        {
            var pollGebruikers = await _context.PollGebruikers.ToListAsync();
            var pollGebruikersLijst = new List<PollGebruiker>();

            foreach (var pollGebruiker in pollGebruikers)
            {
                if (pollGebruiker.pollID == pollID)
                {
                    pollGebruikersLijst.Add(pollGebruiker);
                }
            }

            return pollGebruikersLijst;
        }

        // PUT: api/PollGebruiker/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPollGebruiker(long id, PollGebruiker pollGebruiker)
        {
            if (id != pollGebruiker.pollGebruikerID)
            {
                return BadRequest();
            }

            _context.Entry(pollGebruiker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollGebruikerExists(id))
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

        // POST: api/PollGebruiker
        [HttpPost]
        public async Task<ActionResult<PollGebruiker>> PostPollGebruiker(PollGebruiker pollGebruiker)
        {
            _context.PollGebruikers.Add(pollGebruiker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPollGebruiker", new { id = pollGebruiker.pollGebruikerID }, pollGebruiker);
        }

        // DELETE: api/PollGebruiker/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PollGebruiker>> DeletePollGebruiker(long id)
        {
            var pollGebruiker = await _context.PollGebruikers.FindAsync(id);
            if (pollGebruiker == null)
            {
                return NotFound();
            }

            _context.PollGebruikers.Remove(pollGebruiker);
            await _context.SaveChangesAsync();

            return pollGebruiker;
        }

        private bool PollGebruikerExists(long id)
        {
            return _context.PollGebruikers.Any(e => e.pollGebruikerID == id);
        }
    }
}
