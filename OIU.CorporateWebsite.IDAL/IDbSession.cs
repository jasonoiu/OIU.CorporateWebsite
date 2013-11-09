/* ==============================================================================
 * 类名称：IDbSession
 * 类描述：DbSession接口
 * 创建人：jason
 * 创建时间：2013/10/13 21:20:42
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

namespace OIU.CorporateWebsite.IDAL
{
    /// <summary>
    /// DbSession接口
    /// </summary>
    public interface IDbSession
    {
        //每个表对应的实体仓储对象
        IRoleRepository RoleRepository { get; }
        IBaseUserRepository BaseUserRepository { get; }

        //将当前应用程序跟数据库的会话内所有实体的变化更新会数据库
        int SaveChanges();

        int ExcuteSql(string strSql, DbParameter[] parameters);
    }
}
