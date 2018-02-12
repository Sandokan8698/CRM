using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Common.EntityFrameWork.Extensions;
using Data.Abstract;

namespace Data.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected CRMContex _context;
        private DbSet<TEntity> _set;

        internal Repository(CRMContex context)
        {
            _context = context;
        }

        protected DbSet<TEntity> Set
        {
            get { return _set ?? (_set = _context.Set<TEntity>()); }
        }

        public virtual List<TEntity> GetAll()
        {
            return Set.ToList();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return Set.ToListAsync();
        }

        public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return Set.ToListAsync(cancellationToken);
        }

        public List<TEntity> PageAll(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToList();
        }

        public Task<List<TEntity>> PageAllAsync(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToListAsync();
        }

        public Task<List<TEntity>> PageAllAsync(CancellationToken cancellationToken, int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToListAsync(cancellationToken);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.Where(predicate).ToList();
        }

        public Task<List<TEntity>> FindAsync(CancellationToken cancellationToken, Expression<Func<TEntity, bool>> predicate)
        {
            return Set.Where(predicate).ToListAsync(cancellationToken);
        }


        public TEntity FindById(object id)
        {
            return Set.Find(id);
        }

        public Task<TEntity> FindByIdAsync(object id)
        {
            return Set.FindAsync(id);
        }

        public Task<TEntity> FindByIdAsync(CancellationToken cancellationToken, object id)
        {
            return Set.FindAsync(cancellationToken, id);
        }

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public void Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entity);
                entry = _context.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void AddOrUpdate(TEntity entity)
        {
            Set.AddOrUpdate(entity);
        }

        public void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }

        public void RemoveAll(IEnumerable<TEntity> entities)
        {
            Set.RemoveRange(entities);
        }

        public void UpdateRelated<TRelated, TKey>(
            IEnumerable<TRelated> updateRelateds, 
            Expression<Func<TRelated, bool>> predicate, 
            Func<TRelated, TKey> selector) where TRelated: class 
        {
            DbSet<TRelated> relatedDbset = _context.Set<TRelated>();

            List<TRelated> oldAssests = relatedDbset.Where(predicate).ToList();

            List<TRelated> addedAssests = updateRelateds.ExceptBy(oldAssests, selector).ToList();
            List<TRelated> deletedAssests = oldAssests.ExceptBy(updateRelateds, selector).ToList();

            List<TRelated> updateAssets = updateRelateds.ExceptBy(addedAssests, selector).ToList();
            updateAssets = oldAssests.ExceptBy(deletedAssests, selector).ToList();

            deletedAssests.ForEach(x => _context.Entry(x).State = EntityState.Deleted);
           
            addedAssests.ForEach(c =>
            {
                var entry = _context.Entry(c);
                if (entry.State == EntityState.Detached)
                {
                    relatedDbset.Attach(c);
                    entry = _context.Entry(c);
                }
                entry.State = EntityState.Added;
            });


            updateAssets.ForEach(c =>
            {
                var entry = _context.Entry(c);
                if (entry.State == EntityState.Detached)
                {
                    relatedDbset.Attach(c);
                    entry = _context.Entry(c);
                }
                entry.State = EntityState.Modified;
            });

        }
    }
}