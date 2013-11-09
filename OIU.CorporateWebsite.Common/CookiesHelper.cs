/* ==============================================================================
 * 类名称：CookiesHelper
 * 类描述：Cookies操作类
 * 创建人：jason
 * 创建时间：2013/10/20 18:59:07
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OIU.CorporateWebsite.Common
{
    /// <summary>
    /// Cookies操作类
    /// </summary>
    public class CookiesHelper
    {
        private CookiesHelper()
        {

        }

        #region saveCookies

        /// <summary>
        /// saveCookies
        /// </summary>
        /// <param name="_cookiesName"></param>
        /// <param name="_cookiesKey"></param>
        /// <param name="_cookiesValue"></param>
        /// <param name="_cookiesExpires"></param>
        public static void SaveCookies(string _cookiesName, string _cookiesKey,
            string _cookiesValue, DateTime _cookiesExpires)
        {
            HttpCookie cookies = HttpContext.Current.Response.Cookies[_cookiesName];
            cookies.Values.Add(_cookiesKey, UrlEncodeUTF8(_cookiesValue));
            cookies.Expires = _cookiesExpires;
            HttpContext.Current.Response.AppendCookie(cookies);
        }

        public static void SaveCookies(string _cookiesName, string _cookiesValue,
            DateTime _cookiesExpires)
        {
            HttpCookie cookies = HttpContext.Current.Response.Cookies[_cookiesName];
            cookies.Value = UrlEncodeUTF8(_cookiesValue);
            cookies.Expires = _cookiesExpires;
            HttpContext.Current.Response.AppendCookie(cookies);
        }

        #endregion

        #region delcookies

        /// <summary>
        /// 删除Cookies
        /// </summary>
        /// <param name="page"></param>
        public static void DelCookies(string _cookiesName)
        {
            if (HttpContext.Current.Response.Cookies[_cookiesName] != null)
            {
                HttpCookie cookies = HttpContext.Current.Response.Cookies[_cookiesName];
                cookies.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.SetCookie(cookies);
            }
        }

        #endregion


        #region ¼ÓÃÜ·½·¨

        /// <summary>
        /// ¼ÓÃÜ·½·¨
        /// </summary>
        /// <param name="pToEncrypt">ÐèÒª¼ÓÃÜ×Ö·û´®</param>
        /// <param name="sKey">ÃÜÔ¿£¨Êý×Ö¼ÓÓ¢ÎÄ°ËÎ»£©</param>
        /// <returns>¼ÓÃÜºóµÄ×Ö·û´®</returns>
        public static string Encrypt(string pToEncrypt, string sKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                
                byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);

                des.Key = Encoding.ASCII.GetBytes(sKey);
                des.IV = Encoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                ret.ToString();
                return ret.ToString();
            }
            catch (Exception)
            {
                return "";
            }

            
        }

        #endregion

        #region ½âÃÜ·½·¨

        /// <summary>
        /// ½âÃÜ·½·¨
        /// </summary>
        /// <param name="pToDecrypt">ÐèÒª½âÃÜµÄ×Ö·û´®</param>
        /// <param name="sKey">ÃÜ³×</param>
        /// <returns>½âÃÜºóµÄ×Ö·û´®</returns>
        public static string Decrypt(string pToDecrypt, string sKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = new byte[pToDecrypt.Length/2];
                for (int x = 0; x < pToDecrypt.Length/2; x++)
                {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x*2, 2), 16));
                    inputByteArray[x] = (byte) i;
                }

                //½¨Á¢¼ÓÃÜ¶ÔÏóµÄÃÜÔ¿ºÍÆ«ÒÆÁ¿£¬´ËÖµÖØÒª£¬²»ÄÜÐÞ¸Ä
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                //½¨Á¢StringBuild¶ÔÏó£¬CreateDecryptÊ¹ÓÃµÄÊÇÁ÷¶ÔÏó£¬±ØÐë°Ñ½âÃÜºóµÄÎÄ±¾±ä³ÉÁ÷¶ÔÏó
                StringBuilder ret = new StringBuilder();
                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                //  JS.Alert("¶ÁÈ¡ÅäÖÃÐÅÏ¢Ê§°Ü£¬ÏêÏ¸ÐÅÏ¢£º" + ex.Message.Replace("\r\n", "").Replace("'", ""));
            }
            return "";
        }

        #endregion

        #region //UrlEncode

        public static string UrlEncodeUTF8(string str)
        {
            return UrlEncode(str, System.Text.Encoding.UTF8);
        }

        public static string UrlEncode(string str, System.Text.Encoding encode)
        {
            return System.Web.HttpUtility.UrlEncode(str, encode);
        }

        #endregion

        #region //UrlDecode

        public static string UrlDecodeUTF8(string str)
        {
            return UrlDecode(str, System.Text.Encoding.UTF8);
        }

        public static string UrlDecode(string str, System.Text.Encoding encode)
        {
            return System.Web.HttpUtility.UrlDecode(str, encode);
        }

        #endregion

        #region GetCookies

        public static string GetCurrentCookies(string _cookiesName, string _key)
        {
            try
            {
                if (HttpContext.Current.Request.Cookies[_cookiesName] == null)
                {
                    return "";
                }
                return UrlDecodeUTF8(HttpContext.Current.Request.Cookies[_cookiesName].Values[_key] + "");
            }
            catch
            {
                return "";
            }
        }

        public static string GetCurrentCookies(string _cookiesName)
        {
            try
            {
                if (HttpContext.Current.Request.Cookies[_cookiesName] == null)
                {
                    return "";
                }
                return UrlDecodeUTF8(HttpContext.Current.Request.Cookies[_cookiesName].Value + "");
            }
            catch
            {
                return "";
            }
        }

        #endregion

        /// <summary>
        /// 八位加密字符串
        /// </summary>
        public static string CookiesKey
        {
            get
            {
                return "OIU66998";
            }
        }
    }
}