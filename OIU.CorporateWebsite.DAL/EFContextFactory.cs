/* ==============================================================================
 * 类名称：EFContextFactory
 * 类描述：
 * 创建人：jason
 * 创建时间：2013/10/13 20:21:04
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.DAL
{
    /// <summary>
    /// EF上下文工厂
    /// </summary>
    public class EFContextFactory
    {
        /// <summary>
        /// 返回当前线程内的数据库上下文，如果当前线程内没有上下文，那么创建一个上下文，并保证实例在线程内部是唯一的
        /// </summary>
        /// <returns></returns>
        public static DataModelContainer GetCurrentDbContext()
        {
            //CallContext：是线程内部唯一的独用的数据槽（一块内存空间）
            //传递DbContext进去获取实例的信息，在这里进行强制转换。
            var dbContext = CallContext.GetData("DbContext") as DataModelContainer;
            if (dbContext == null)
            {
                dbContext = new DataModelContainer();
                CallContext.SetData("DbContext", dbContext);
            }
            return dbContext;
        }
    }
}
