

using AN.Core.Data;
using AN.Core.Data.Data;
using AN.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AN.DAL
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly BanobatDbContext _context;
        private DbSet<TEntity> _entities;
        public EfRepository(BanobatDbContext accountingDbContext)
        {
            _context = accountingDbContext;
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

        public virtual async Task<TEntity> GetByIdNoTrackingAsync(int id)
        {
            var entity = await TableNoTracking.FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }

        public virtual IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public virtual IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = Entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var property in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(property);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }

        public virtual IQueryable<TEntity> GenericQuery(QueryModel<TEntity> model)
        {
            return ParseQuery(model);
        }

        public virtual IQueryable<TEntity> GenericPaginatedQuery(QueryModel<TEntity> model)
        {
            var query = ParseQuery(model);

            return query.Skip(model.PageSize * model.PageIndex).Take(model.PageSize);
        }

        public virtual IQueryable<TEntity> Match(IQueryable<TEntity> data, string searchTerm, IEnumerable<Expression<Func<TEntity, string>>> filterProperties)
        {
            return PredicateBuilder.Match(data, searchTerm, filterProperties);
        }

        public virtual IQueryable<TEntity> GetPaginated(int pageIndex = 0, int pageSize = 10)
        {
            return Entities.Skip(pageSize * pageIndex).Take(pageSize);
        }

        public virtual async Task<long> GetPagesCountAsync(int pageSize = 10)
        {
            var totalItems = await Entities.LongCountAsync();

            var count = totalItems / pageSize + (totalItems % pageSize > 0 ? 1 : 0);

            return count;
        }

        public virtual async Task<long> GetPagesCountAsync(QueryModel<TEntity> model)
        {
            var query = ParseQuery(model);

            var totalItems = await query.LongCountAsync();

            var count = totalItems / model.PageSize + (totalItems % model.PageSize > 0 ? 1 : 0);

            return count;
        }

        public virtual async Task<bool> IsExistAsync(int id)
        {
            var exist = await Entities.AnyAsync(x => x.Id == id);

            return exist;
        }

        public virtual bool IsExist(int id)
        {
            var exist = Entities.Any(x => x.Id == id);

            return exist;
        }
        #endregion

        #region Insertion
        public virtual void Insert(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Entities.Add(entity);

            _context.SaveChanges();
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await Entities.AddAsync(entity);

            await _context.SaveChangesAsync();
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

            _context.SaveChanges();
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
            {
                Entities.Attach(entity);

                _context.Entry(entity).State = EntityState.Modified;
            }

            _context.SaveChanges();
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
        public DatabaseFacade Database => _context.Database;

        public IQueryable<TEntity> Table => Entities;

        public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        protected virtual DbSet<TEntity> Entities => _entities ?? (_entities = _context.Set<TEntity>());
        #endregion

        #region Helpers
        private IQueryable<TEntity> ParseQuery(QueryModel<TEntity> queryModel)
        {
            IQueryable<TEntity> query = Entities;

            foreach (var predicate in queryModel.Predicates)
            {
                query = query.Where(predicate);
            }

            if (!string.IsNullOrEmpty(queryModel.SearchString))
            {
                query = Match(query, queryModel.SearchString, queryModel.SearchStringFilterProperties);
            }

            if (queryModel.OrderBy != null)
            {
                query = queryModel.IsOrderByDesc ? query.OrderByDescending(queryModel.OrderBy) : query.OrderBy(queryModel.OrderBy);
            }

            return query;
        }
        #endregion
    }
}

