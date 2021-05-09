using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Getting
        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);
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
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }
        #endregion
    }
}
