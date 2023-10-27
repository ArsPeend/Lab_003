using Microsoft.EntityFrameworkCore;

namespace Lab_003.Models
{
    public class ticketRepository : ITicketRepository
    {
        private readonly MyDbContext _dbContext;
        public ticketRepository(MyDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task<IEnumerable<Ticket>> Get()
        {
            return await _dbContext.Tickets.ToListAsync();
        }
        public async Task<Ticket> GetToId(int id)
        {
            return await _dbContext.Tickets.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<Ticket> Create(Ticket ticket)
        {
            var result = await _dbContext.Tickets.AddAsync(ticket);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Ticket> Update(Ticket ticket)
        {
            var result = await _dbContext.Tickets.FirstOrDefaultAsync(e => e.Id == ticket.Id);

            if (result != null)
            {
                result.FirstName = ticket.FirstName;
                result.LastName = ticket.LastName;
                result.BoardingStation = ticket.BoardingStation;
                result.ArrivalStation = ticket.ArrivalStation;
                result.TripNumber = ticket.TripNumber;
                await _dbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public async Task<Ticket> Remove(int id)
        {
            var result = await _dbContext.Tickets.FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                _dbContext.Tickets.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
            return null;
        }
    }
}
