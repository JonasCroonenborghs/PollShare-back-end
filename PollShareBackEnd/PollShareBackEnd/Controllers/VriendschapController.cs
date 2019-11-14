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
    public class VriendschapController : ControllerBase
    {
        private readonly PollShareContext _context;

        public VriendschapController(PollShareContext context)
        {
            _context = context;
        }

        // GET: api/Vriendschap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vriendschap>>> GetVriendschappen()
        {
            return await _context.Vriendschappen.ToListAsync();
        }

        // GET: api/Vriendschap/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vriendschap>> GetVriendschap(long id)
        {
            var vriendschap = await _context.Vriendschappen.FindAsync(id);

            if (vriendschap == null)
            {
                return NotFound();
            }

            return vriendschap;
        }

        // GET: api/Vriendschap/gebruiker/id
        [HttpGet("gebruiker/{id}")]
        public async Task<ActionResult<IEnumerable<Gebruiker>>> GetVriendenByGebruikerID(long gebruikerID)
        {
            var vriendschappen = await _context.Vriendschappen.ToListAsync();
            var vriendenLijst = new List<Gebruiker>();

            foreach (var vriendschap in vriendschappen)
            {
                if (vriendschap.gebruikerID == gebruikerID) 
                {
                    var vriend = await _context.Gebruikers.FindAsync(vriendschap.vriendID);
                    vriendenLijst.Add(vriend);
                }
                else if (vriendschap.vriendID == gebruikerID)
                {
                    var vriend = await _context.Gebruikers.FindAsync(vriendschap.gebruikerID);
                    vriendenLijst.Add(vriend);

                }
            }

            return vriendenLijst;
        }

        // PUT: api/Vriendschap/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVriendschap(long id, Vriendschap vriendschap)
        {
            if (id != vriendschap.vriendschapID)
            {
                return BadRequest();
            }

            _context.Entry(vriendschap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VriendschapExists(id))
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

        // POST: api/Vriendschap
        [HttpPost]
        public async Task<ActionResult<Vriendschap>> PostVriendschap(Vriendschap vriendschap)
        {
            _context.Vriendschappen.Add(vriendschap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVriendschap", new { id = vriendschap.vriendschapID }, vriendschap);
        }

        // DELETE: api/Vriendschap/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vriendschap>> DeleteVriendschap(long id)
        {
            var vriendschap = await _context.Vriendschappen.FindAsync(id);
            if (vriendschap == null)
            {
                return NotFound();
            }

            _context.Vriendschappen.Remove(vriendschap);
            await _context.SaveChangesAsync();

            return vriendschap;
        }

        private bool VriendschapExists(long id)
        {
            return _context.Vriendschappen.Any(e => e.vriendschapID == id);
        }
    }
}
