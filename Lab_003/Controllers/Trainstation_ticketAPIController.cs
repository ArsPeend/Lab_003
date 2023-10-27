using Lab_003.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_003.Controllers
{
    [Route("api/Trainstation_ticketAPI")]
    [ApiController]
    public class Trainstation_ticketAPIController : ControllerBase
    {
        private readonly ITicketRepository genericRepository;
        public Trainstation_ticketAPIController(ITicketRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetTickets()
        {
            try
            {
                return Ok(await genericRepository.Get());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Ticket>> CreateTicket(Ticket ticket)
        {
            try
            {
                if (ticket == null)
                    return BadRequest();
                var createdTicket = await genericRepository.Create(ticket);
                return Ok();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> RemoveTicket(int id)
        {
            try
            {
                var ticketRemove = await genericRepository.GetToId(id);
                if (ticketRemove == null)
                {
                    return NotFound();
                }
                await genericRepository.Remove(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Ticket>> UpdateTicket(int id, Ticket ticket)
        {
            try
            {
                if (id != ticket.Id)
                {
                    return BadRequest();
                }
                var ticketUpdate = await genericRepository.GetToId(id);
                if (ticketUpdate == null)
                {
                    return NotFound();
                }
                return await genericRepository.Update(ticket);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
