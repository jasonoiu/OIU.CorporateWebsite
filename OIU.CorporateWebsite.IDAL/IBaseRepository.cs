using System;
using System.Linq;
using System.Linq.Expressions;

namespace OIU.CorporateWebsite.IDAL
{
    /// <summary>
    /// 数据库的访问方法的基类接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T : class, new()
    {
        T AddEntity(T entity);
        bool UpdateEntity(T entity);
        bool DeleteEntity(T entity);
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderByLambda);
    }
}
