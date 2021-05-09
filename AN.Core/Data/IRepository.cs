using AN.Core.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AN.Core.Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Getting
        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> GetByIdNoTrackingAsync(int id);
        IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        IQueryable<TEntity> GenericQuery(QueryModel<TEntity> model);
        IQueryable<TEntity> GenericPaginatedQuery(QueryModel<TEntity> model);
        IQueryable<TEntity> Match(IQueryable<TEntity> data, string searchTerm, IEnumerable<Expression<Func<TEntity, string>>> filterProperties);
        IQueryable<TEntity> GetPaginated(int pageIndex = 0, int pageSize = 10);
        Task<long> GetPagesCountAsync(int pageSize = 10);
        Task<long> GetPagesCountAsync(QueryModel<TEntity> model);
        Task<bool> IsExistAsync(int id);
        bool IsExist(int id);
        #endregion

        #region Insertion
        void Insert(TEntity entity);

        Task InsertAsync(TEntity entity);

        void Insert(IEnumerable<TEntity> entities);
        #endregion

        #region Update
        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);
        #endregion

        #region Deletion
        void Delete(TEntity entity);

        Task DeleteAsync(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);
        #endregion

        #region Table
        DatabaseFacade Database { get; }

        IQueryable<TEntity> Table { get; }

        IQueryable<TEntity> TableNoTracking { get; }
        #endregion
    }
}
