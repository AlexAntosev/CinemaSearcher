using CinemaSearcher.Persisted.Context;
using CinemaSearcher.Persisted.Entities;
using CinemaSearcher.Persisted.Interfaces;

namespace CinemaSearcher.Persisted.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(CinemaContext context) : base(context)
        {

        }
    }
}
