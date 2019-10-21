using CinemaSearcher.Persisted.Context;
using CinemaSearcher.Persisted.Entities;
using CinemaSearcher.Persisted.Interfaces;

namespace CinemaSearcher.Persisted.Repositories
{
    public class FilmRepository : GenericRepository<Film>, IFilmRepository
    {
        public FilmRepository(CinemaContext context) : base(context)
        {

        }
    }
}
