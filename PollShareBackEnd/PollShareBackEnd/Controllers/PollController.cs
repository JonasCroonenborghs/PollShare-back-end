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
    public class PollController : ControllerBase
    {
        private readonly PollShareContext _context;

        public PollController(PollShareContext context)
        {
            _context = context;
        }

        // GET: api/Poll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poll>>> GetPolls()
        {
            return await _context.Polls.ToListAsync();
        }

        // GET: api/Poll/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poll>> GetPoll(long id)
        {
            var poll = await _context.Polls.FindAsync(id);

            if (poll == null)
            {
                return NotFound();
            }

            return poll;
        }

        // GET: api/Poll/poll/naam
        [HttpGet("naam")]
        public async Task<ActionResult<Poll>> GetPollByNaam(string naam)
        {
            var polls = await _context.Polls.ToListAsync();
            var poll = new Poll();

            foreach (var p in polls)
            {
                if (p.naam == naam)
                {
                    poll = p;
                }
            }

            return poll;
        }

        // GET: api/Poll/pollGebruikerID
        [HttpGet("pollGebruikerID")]
        public async Task<ActionResult<IEnumerable<Poll>>> GetPollsByGebruikerID(long gebruikerID)
        {
            var pollGebruikers = await _context.PollGebruikers.ToListAsync();
            var pollLijst = new List<Poll>();

            foreach (var pollGebruiker in pollGebruikers)
            {
                if (pollGebruiker.gebruikerID == gebruikerID)
                {
                    var poll = await _context.Polls.FindAsync(pollGebruiker.pollID);
                    pollLijst.Add(poll);
                }
            }

            return pollLijst;
        }

        // GET: api/Poll/makerID
        [HttpGet("makerID")]
        public async Task<ActionResult<IEnumerable<Poll>>> GetPollsByMakerID(long makerID)
        {
            var polls = await _context.Polls.ToListAsync();
            var pollLijst = new List<Poll>();

            foreach (var poll in polls)
            {
                if (poll.makerID == makerID)
                {
                    pollLijst.Add(poll);
                }
            }

            return pollLijst;
        }

        // PUT: api/Poll/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoll(long id, Poll poll)
        {
            if (id != poll.pollID)
            {
                return BadRequest();
            }

            _context.Entry(poll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollExists(id))
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

        // POST: api/Poll
        [HttpPost]
        public async Task<ActionResult<Poll>> PostPoll(Poll poll)
        {
            _context.Polls.Add(poll);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoll", new { id = poll.pollID }, poll);
        }

        // DELETE: api/Poll/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Poll>> DeletePoll(long id)
        {
            var poll = await _context.Polls.FindAsync(id);
            if (poll == null)
            {
                return NotFound();
            }

            _context.Polls.Remove(poll);
            await _context.SaveChangesAsync();

            return poll;
        }

        private bool PollExists(long id)
        {
            return _context.Polls.Any(e => e.pollID == id);
        }
    }
}
