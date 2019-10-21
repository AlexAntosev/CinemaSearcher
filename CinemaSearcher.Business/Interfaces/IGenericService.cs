using CinemaSearcher.Persisted.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CinemaSearcher.Business.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(Guid id, TEntity film);
        Task<bool> RemoveAsync(Guid id);
        Task<TEntity> GetAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> expression);
    }
}
