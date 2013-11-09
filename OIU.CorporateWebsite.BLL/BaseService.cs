/* ==============================================================================
 * 类名称：BaseService
 * 类描述：
 * 创建人：jason
 * 创建时间：2013/10/13 18:35:27
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Linq;
using System.Linq.Expressions;
using OIU.CorporateWebsite.DAL;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.BLL
{
    /// <summary>
    /// 业务逻辑基类
    /// </summary>
    public abstract class BaseService<T> where T : class ,new()
    {
        /// <summary>
        /// 当前仓储
        /// </summary>
        public IDAL.IBaseRepository<T> CurrentRepository { get; set; }
        /// <summary>
        /// DbSession的存放
        /// </summary>
        public DbSession dbSession = new DbSession();
        //基类的构造函数
        public BaseService()
        {
            //构造函数里面去调用了，此设置当前仓储的抽象方法
            SetCurrentRepository();
        }

        /// <summary>
        /// 设置当前工厂类 约束 子类必须实现
        /// </summary>
        public abstract void SetCurrentRepository();

        public T AddEntity(T entity)
        {
            var addEntity = CurrentRepository.AddEntity(entity);
            dbSession.SaveChanges();
            return addEntity;
        }

        public bool UpdateEntity(T entity)
        {
            CurrentRepository.UpdateEntity(entity);
            return dbSession.SaveChanges() > 0;
        }

        public bool DeleteEntity(T entity)
        {
            CurrentRepository.DeleteEntity(entity);
            return dbSession.SaveChanges() > 0;
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentRepository.LoadEntities(whereLambda);
        }

        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderByLambda)
        {
            return CurrentRepository.LoadPageEntities(pageIndex, pageSize, out total, whereLambda, isAsc, orderByLambda);
        }

        public DataModelContainer Db
        {
            get
            {
                return EFContextFactory.GetCurrentDbContext();
            }
        }

    }
}
