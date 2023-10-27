namespace Lab_003.Models
{
    public interface ITripRepository
    {
        Task<Trip> GetToId(int id);
        Task<Trip> Create(Trip trip);
        Task<Trip> Remove(int id);
        Task<Trip> Update(Trip trip);
        Task<IEnumerable<Trip>> Get();



    }
}
