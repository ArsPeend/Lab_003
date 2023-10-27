using Microsoft.EntityFrameworkCore;

namespace Lab_003.Models
{
    public class tripRepository : ITripRepository
    {
       private readonly MyDbContext _dbContext;
       public tripRepository(MyDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task<IEnumerable<Trip>> Get()
        {
            return await _dbContext.Trips.ToListAsync();
        }
        public async Task<Trip> GetToId(int id)
        {
            return await _dbContext.Trips.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<Trip> Create(Trip trip)
        {
            var result = await _dbContext.Trips.AddAsync(trip);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Trip> Update(Trip trip)
        {
            var result = await _dbContext.Trips.FirstOrDefaultAsync(e => e.Id == trip.Id);

            if (result != null)
            {
                result.ArrivalStation = trip.ArrivalStation;
                result.DepartureStation = trip.DepartureStation;
                await _dbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public async Task<Trip> Remove(int id)
        {
            var result = await _dbContext.Trips.FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                _dbContext.Trips.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
            return null;
        }
    }
}