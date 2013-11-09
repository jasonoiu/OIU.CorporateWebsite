/* ==============================================================================
 * 类名称：LoginResult
 * 类描述：登录结果枚举
 * 创建人：jason
 * 创建时间：2013/10/14 20:48:35
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
    /// 登录结果枚举
    /// </summary>
    public enum LoginResult
    {
        /// <summary>
        /// 密码错误
        /// </summary>
        [Descrition("密码错误")]
        PassWordError,
        /// <summary>
        /// 用户不存在
        /// </summary>
        [Descrition("用户不存在")]
        UserNotExist,
        /// <summary>
        /// 用户名为空
        /// </summary>
        [Descrition("用户名为空")]
        UserNameIsNull,
        /// <summary>
        /// 密码为空
        /// </summary>
        [Descrition("密码为空")]
        PassWordIsNUll,
        /// <summary>
        /// 登录成功
        /// </summary>
        [Descrition("登录成功")]
        Success
    }
}
