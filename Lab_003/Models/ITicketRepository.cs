namespace Lab_003.Models
{
    public interface ITicketRepository
    {
        Task<Ticket> GetToId(int id);
        Task<Ticket> Create(Ticket ticket);
        Task<Ticket> Remove(int id);
        Task<Ticket> Update(Ticket ticket);
        Task<IEnumerable<Ticket>> Get();



    }
}
