/* ==============================================================================
 * 类名称：DbSessionFactory
 * 类描述：
 * 创建人：jason
 * 创建时间：2013/10/13 21:31:48
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using OIU.CorporateWebsite.IDAL;

namespace OIU.CorporateWebsite.DAL
{
    /// <summary>
    /// DbSession工厂,实现DbSession线程内唯一
    /// </summary>
    public class DbSessionFactory
    {
        /// <summary>
        /// 获得当前DbSession，保证了线程内DbSession实例唯一
        /// </summary>
        /// <returns></returns>
        public static IDbSession GetCurrentDbSession()
        {
            var dbSession = CallContext.GetData("DbSession") as IDbSession;
            if (dbSession == null)
            {
                dbSession=new DbSession();
                CallContext.SetData("DbSession",dbSession);
            }
            return dbSession;
        }
    }
}
