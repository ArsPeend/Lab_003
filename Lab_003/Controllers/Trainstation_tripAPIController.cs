using Lab_003.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_003.Controllers
{
    [Route("api/Trainstation_tripAPI")]
    [ApiController]
    public class Trainstation_tripAPIController : ControllerBase
    {
        private readonly ITripRepository genericRepository;
        public Trainstation_tripAPIController(ITripRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetTrips()
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
        public async Task<ActionResult<Trip>> CreateTrip(Trip trip)
        {
            try
            {
                if (trip == null)
                    return BadRequest();
                var createdTrip = await genericRepository.Create(trip);
                return Ok();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> RemoveTrip(int id)
        {
            try
            {
                var tripRemove = await genericRepository.GetToId(id);
                if (tripRemove == null)
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
        public async Task<ActionResult<Trip>> UpdateTrip(int id, Trip trip)
        {
            try
            {
                if (id != trip.Id)
                {
                    return BadRequest();
                }
                var tripUpdate = await genericRepository.GetToId(id);
                if(tripUpdate == null)
                {
                    return NotFound();
                }
                return await genericRepository.Update(trip);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }

}

