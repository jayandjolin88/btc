using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ACCESS_HELPER
    {

        /// <summary>
        /// 读取表数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetData(string sql)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\BIM\\other\\GW\\Database1.accdb;Persist Security Info=False"); 
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            if (dr.HasRows)
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    dt.Columns.Add(dr.GetName(i));
                }
                dt.Rows.Clear();
            }
            while (dr.Read())
            {
                DataRow row = dt.NewRow();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    row[i] = dr[i];
                }
                dt.Rows.Add(row);
            }
            cmd.Dispose();
            conn.Close();
            return dt;
        }

        /// <summary>
        /// 插入表数据
        /// </summary>
        /// <returns></returns>
        public int InsertData(string sql)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\BIM\\other\\GW\\Database1.accdb;Persist Security Info=False");
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            return i;
        }

        /// <summary>
        /// 删除表数据
        /// </summary>
        /// <returns></returns>
        public int DeleteData(string sql)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\BIM\\other\\GW\\Database1.accdb;Persist Security Info=False");
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            return i;
        }

    }
}
