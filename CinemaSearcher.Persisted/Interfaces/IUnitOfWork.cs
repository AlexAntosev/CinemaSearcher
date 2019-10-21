using System.Threading.Tasks;

namespace CinemaSearcher.Persisted.Interfaces
{
    public interface IUnitOfWork
    {
        IFilmRepository FilmRepository { get; }

        Task CommitAsync();
    }
}
