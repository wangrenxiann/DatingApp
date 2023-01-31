using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatingApp.Server.Data;
using DatingApp.Shared.Domain;
using DatingApp.Server.IRepository;

namespace DatingApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public PlayersController(ApplicationDbContext context)
        public PlayersController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Players
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        public async Task<IActionResult> GetPlayers()
        {
            //return await _context.Players.ToListAsync();
            var players = await _unitOfWork.Players.GetAll();
            return Ok(players);
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Player>> GetPlayer(int id)
        public async Task<IActionResult> GetPlayer(int id)
        {
            //var player = await _context.Players.FindAsync(id);
            var player = await _unitOfWork.Players.Get(q => q.Id == id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            //_context.Entry(player).State = EntityState.Modified;
            _unitOfWork.Players.Update(player);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!PlayerExists(id))
                if (!await PlayerExists(id)) 
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

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            //_context.Players.Add(player);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Players.Insert(player);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            //var player = await _context.Players.FindAsync(id);
            var player = await _unitOfWork.Players.Get(q => q.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            //_context.Players.Remove(player);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Players.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool PlayerExists(int id)
        private async Task<bool> PlayerExists(int id)
        {
            //return _context.Players.Any(e => e.Id == id);
            var player = await _unitOfWork.Players.Get(q => q.Id == id);
            return player != null;
        }
    }
}
