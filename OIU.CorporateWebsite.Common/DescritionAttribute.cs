/* ==============================================================================
 * 类名称：DescritionAttribute
 * 类描述：描述属性
 * 创建人：jason
 * 创建时间：2013/10/14 21:48:42
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OIU.CorporateWebsite.Common
{
    /// <summary>
    /// 附加属性类
    /// 描述属性
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class DescritionAttribute : Attribute
    {
        readonly string _descContent;
        /// <summary>
        /// 带内容参数的附加属性方法
        /// </summary>
        /// <param name="content">内容</param>
        public DescritionAttribute(string content)
        {
            this._descContent = content;
        }
        /// <summary>
        /// 描述的内容
        /// </summary>
        public string DescritionContent
        {
            get { return this._descContent; }
        }
    }
}
