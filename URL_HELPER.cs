using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class URL_HELPER
    {

        /// <summary>
        /// 读取首页网站
        /// </summary>
        /// <returns></returns>
        public string Get_First_Page()
        {
            string url = System.Configuration.ConfigurationManager.AppSettings["FIRST_PAGE_URL"].ToString();
            return url;
        }

        /// <summary>
        /// 读取收藏夹类型
        /// </summary>
        /// <returns></returns>
        public DataTable Get_URL(string type)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID",typeof(string));
            dt.Columns.Add("TYPE", typeof(string));
            dt.Columns.Add("UTL_NAME", typeof(string));
            dt.Columns.Add("UTL", typeof(string));
            string url_type = System.Configuration.ConfigurationManager.AppSettings[type].ToString();
            ArrayList arr = new ArrayList(url_type.Split('|'));
            int index = 1;
            foreach (string item in arr)
            {
                dt.Rows.Add(new object[] { index, type, item.Split('@')[1], item.Split('@')[0] });
            }
            return dt;
        }


        /// <summary>
        /// 读取类型下面的子网址
        /// </summary>
        /// <returns></returns>
        public string Get_URL_TYPE()
        {
            string url_type = System.Configuration.ConfigurationManager.AppSettings["TYPE"].ToString();
            return url_type;
        }
    }
}
