/* ==============================================================================
 * 类名称：EnumManager
 * 类描述：
 * 创建人：jason
 * 创建时间：2013/10/14 21:59:07
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OIU.CorporateWebsite.Common
{
    /// <summary>
    /// 枚举管理
    /// </summary>
    /// <typeparam name="T">枚举类型</typeparam>
    public static class EnumManager<T> 
    {
        /// <summary>
        /// 由枚举创建DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable()
        {
            Type enumType = typeof(T);
            FieldInfo[] enumFields = enumType.GetFields();

            DataTable table = new DataTable();
            table.Columns.Add("Name", Type.GetType("System.String"));       //创建列
            table.Columns.Add("Value", Type.GetType("System.Int32"));       //创建列

            foreach (FieldInfo field in enumFields)
            {
                if (!field.IsSpecialName)
                {
                    DataRow row = table.NewRow();
                    row[0] = field.Name;
                    row[1] = Convert.ToInt32(field.GetRawConstantValue());
                    //row[1] = (int)Enum.Parse(enumType, field.Name); //也可以这样
                    table.Rows.Add(row);
                }
            }

            return table;
        }

        /// <summary>
        /// get enum description by name
        /// </summary>
        /// <param name="enumItemName">the enum name</param>
        /// <returns></returns>
        public static string GetDescriptionByName(T enumItemName)
        {
            var fi = enumItemName.GetType().GetField(enumItemName.ToString());

            var attributes = (DescritionAttribute[])fi.GetCustomAttributes(
                typeof(DescritionAttribute), false);

            return attributes.Length > 0 ? attributes[0].DescritionContent : enumItemName.ToString();
        }


        // 设置列表
        //public static void SetListControl(ListControl list)
        //{
        //    list.DataSource = getDataTable();      // 获取DataTable
        //    list.DataTextField = "Name";
        //    list.DataValueField = "Value";
        //    list.DataBind();
        //}

        //public static void SetListControl(Repeater rpt)
        //{
        //    rpt.DataSource = getDataTable();
        //    rpt.DataBind();
        //}
    }
}
