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
    public class MessagesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public PlayersController(ApplicationDbContext context)
        public MessagesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Players
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        public async Task<IActionResult> GetMessages()
        {
            //return await _context.Players.ToListAsync();
            var messages = await _unitOfWork.Messages.GetAll();
            return Ok(messages);
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Player>> GetPlayer(int id)
        public async Task<IActionResult> GetMessage(int id)
        {
            //var player = await _context.Players.FindAsync(id);
            var message = await _unitOfWork.Messages.Get(q => q.Id == id);

            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int id, Message message)
        {
            if (id != message.Id)
            {
                return BadRequest();
            }

            //_context.Entry(player).State = EntityState.Modified;
            _unitOfWork.Messages.Update(message);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!PlayerExists(id))
                if (!await MessageExists(id))
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
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
            //_context.Players.Add(player);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Messages.Insert(message);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetMessage", new { id = message.Id }, message);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            //var player = await _context.Players.FindAsync(id);
            var message = await _unitOfWork.Messages.Get(q => q.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            //_context.Players.Remove(player);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Messages.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool PlayerExists(int id)
        private async Task<bool> MessageExists(int id)
        {
            //return _context.Players.Any(e => e.Id == id);
            var message = await _unitOfWork.Messages.Get(q => q.Id == id);
            return message != null;
        }
    }
}
