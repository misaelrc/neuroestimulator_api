using System.Linq.Expressions;
using NeuroEstimulator.Framework.Database.EfCore.PagedResult;

namespace NeuroEstimulator.Framework.Database.EfCore.Interface;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    void Add(TEntity entity);

    void Delete(TEntity entity);

    void DeleteRange(IList<TEntity> entiies);

    PagedList<TEntity> GetPagination(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "");

    Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>,
        IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "");

    Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
        , params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity> GetByIdAsync(object id);

    Task<TEntity> GetByIdAsync(object id, params Expression<Func<TEntity, object>>[] includes);

    IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);

    void Update(TEntity entity);

    void UpdateRange(IList<TEntity> entiies);
}
