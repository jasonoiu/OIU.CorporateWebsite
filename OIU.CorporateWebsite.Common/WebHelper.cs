/* ==============================================================================
 * 类名称：WebHelper
 * 类描述：辅助工具类
 * 创建人：jason
 * 创建时间：2013/10/20 19:59:07
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace OIU.CorporateWebsite.Common
{
    /// <summary>
    /// 辅助工具类
    /// </summary>
    public class WebHelper
    {
        /// <summary>
        /// 判断是否是数字类型
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool IsNumeric(object o)
        {
            int i;
            return int.TryParse(o.ToString(), out i);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static string GetMd5Password(string pass)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "MD5").ToLower();
        }
    }
}
