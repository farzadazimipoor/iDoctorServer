using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppIdentityDbContext _context;
        private DbSet<TEntity> _entities;
        public Repository(AppIdentityDbContext dbContext)
        {
            _context = dbContext;
            _entities = _context.Set<TEntity>();
        }

        #region Getting
        public virtual TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }
        #endregion

        #region Insertion
        public virtual void Insert(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Entities.Add(entity);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await Entities.AddAsync(entity);
        }

        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities) Entities.Add(entity);
        }
        #endregion

        #region Update
        public virtual void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Entities.Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
            {
                Entities.Attach(entity);

                _context.Entry(entity).State = EntityState.Modified;
            }
        }
        #endregion

        #region Deletion
        public virtual void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Entities.Remove(entity);

            _context.SaveChanges();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Entities.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
                Entities.Remove(entity);

            _context.SaveChanges();
        }
        #endregion

        #region Table
        public IQueryable<TEntity> Table => Entities;

        public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        protected virtual DbSet<TEntity> Entities => _entities ?? (_entities = _context.Set<TEntity>());
        #endregion       
    }
}
