using CinemaSearcher.Persisted.Context;
using CinemaSearcher.Persisted.Interfaces;
using System.Threading.Tasks;

namespace CinemaSearcher.Persisted.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CinemaContext _context;

        private IFilmRepository _filmRepository;

        public UnitOfWork(CinemaContext context)
        {
            _context = context;
        }

        public IFilmRepository FilmRepository => _filmRepository ?? (_filmRepository = new FilmRepository(_context));

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
