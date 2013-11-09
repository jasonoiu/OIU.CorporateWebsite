/* ==============================================================================
 * 类名称：IBaseService
 * 类描述：
 * 创建人：jason
 * 创建时间：2013/10/13 18:59:00
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Linq;
using System.Linq.Expressions;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.IBLL
{
    /// <summary>
    /// IBaseService
    /// </summary>
    public interface IBaseService<T> where T : class ,new()
    {
        T AddEntity(T entity);

        bool UpdateEntity(T entity);

        bool DeleteEntity(T entity);

        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderByLambda);
    }
}
