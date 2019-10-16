using CinemaSearcher.Persisted.Context;
using CinemaSearcher.Persisted.Interfaces;
using System.Threading.Tasks;

namespace CinemaSearcher.Persisted.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CinemaContext _context;

        private ITicketRepository _ticketRepository;

        public UnitOfWork(CinemaContext context)
        {
            _context = context;
        }

        public ITicketRepository TicketRepository => _ticketRepository ?? (_ticketRepository = new TicketRepository(_context));

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
