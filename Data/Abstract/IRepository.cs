using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        List<TEntity> GetAllAsNoTracking();

        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);

        List<TEntity> PageAll(int skip, int take);
        Task<List<TEntity>> PageAllAsync(int skip, int take);
        Task<List<TEntity>> PageAllAsync(CancellationToken cancellationToken, int skip, int take);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> FindAsync(CancellationToken cancellationToken, Expression<Func<TEntity, bool>> predicate);
        TEntity FindById(object id);
        Task<TEntity> FindByIdAsync(object id);
        Task<TEntity> FindByIdAsync(CancellationToken cancellationToken, object id);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveAll(IEnumerable<TEntity> entities);

        void UpdateRelated<TRelated, TKey>(
            IEnumerable<TRelated> updateRelateds, Expression<Func<TRelated, bool>> predicate,
            Func<TRelated, TKey> selector) where TRelated:class;
    }
}
