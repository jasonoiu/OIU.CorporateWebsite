/* ==============================================================================
 * 类名称：DbSession
 * 类描述：一次跟数据库交互的会话，封装了所有仓储的属性，根据DbSession可以拿到仓储的属性
 * 创建人：jason
 * 创建时间：2013/10/13 20:13:59
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using OIU.CorporateWebsite.IDAL;

namespace OIU.CorporateWebsite.DAL
{
    /// <summary>
    /// 一次跟数据库交互的会话，封装了所有仓储的属性，根据DbSession可以拿到仓储的属性
    /// </summary>
    public class DbSession:IDbSession //代表应用程序跟数据库之间的一次会话，也是数据库访问层的统一入口
    {
        public IDAL.IRoleRepository RoleRepository
        {
            get{return new RoleRepository();}
        }

        public IDAL.IBaseUserRepository BaseUserRepository
        {
            get { return new BaseUserRepository(); }
        }
        /// <summary>
        /// 当前应用程序跟数据库的会话内所有的实体的变化，更新回数据库
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return EFContextFactory.GetCurrentDbContext().SaveChanges();
        }
        /// <summary>
        /// 执行Sql脚本的方法
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExcuteSql(string strSql, DbParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
