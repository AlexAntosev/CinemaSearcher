using System.Threading.Tasks;

namespace CinemaSearcher.Persisted.Interfaces
{
    public interface IUnitOfWork
    {
        ITicketRepository TicketRepository { get; }

        Task CommitAsync();
    }
}
