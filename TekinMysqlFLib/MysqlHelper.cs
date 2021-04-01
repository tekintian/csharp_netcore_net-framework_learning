using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Configuration;

namespace TekinMysqlFLib
{
    class MysqlHelper
    {
        /*
         * App.config配置信息
         <connectionStrings>
		   <add name = "mysql" connectionString="Server=192.168.2.8;Port=3306;User ID=netdemo;Password=netdemo888;Database=netdemo;Charset=utf8;" />
	      </connectionStrings>
        */
        //从App.config配置文件获取mysql的配置信息
        public static readonly string ConnStr = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
        public static DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            MySqlConnection conn = new MySqlConnection(ConnStr);
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                adapter.Fill(dt);
            }
            catch
            {
                ;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }

            return dt;
        }
        public static DataRow GetDataRow(string sql)
        {
            DataRow row = null;
            DataTable dt = GetDataTable(sql);
            try
            {
                if (dt.Rows.Count > 0)
                    row = dt.Rows[0];
            }
            finally
            {
                dt.Dispose(); dt = null;
            }
            return row;
        }
        /// <summary>
        /// 执行 Insert Delete Update
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="paramNames">参数名数组</param>
        /// <param name="paramValues">参数值数组</param>
        /// <returns>成功-1;失败-0</returns>
        public static int DoExecute(string sql, string[] paramNames, object[] paramValues)
        {
            if (paramNames != null)
            {
                if (paramNames.Length != paramValues.Length)
                {
                    return 0;
                }
            }
            int ret = 0;
            MySqlConnection conn = new MySqlConnection(ConnStr);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Clear();
            cmd.CommandText = sql;
            try
            {
                if (paramNames != null)
                {
                    for (int i = 0; i < paramNames.Length; i++)
                    {
                        MySqlParameter param = null;
                        if (paramValues[i] != null)
                        {
                            param = new MySqlParameter(paramNames[i], paramValues[i]);
                        }
                        else
                        {
                            if (paramNames[i].ToUpper().Contains("F_SYMBOL"))
                            {
                                param = new MySqlParameter(paramNames[i], SqlDbType.Image);
                                param.Value = DBNull.Value;
                            }
                            else if (paramNames[i].ToUpper().Contains("F_PHOTO"))
                            {
                                param = new MySqlParameter(paramNames[i], SqlDbType.Image);
                                param.Value = DBNull.Value;
                            }
                            else
                            {
                                param = new MySqlParameter(paramNames[i], DBNull.Value);
                            }
                        }
                        cmd.Parameters.Add(param);
                    }
                }
                conn.Open();
                cmd.ExecuteNonQuery();
                ret = 1;
            }
            catch (Exception err) {; }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return ret;
        }
        /// <summary>
        /// 执行Insert
        /// </summary>
        /// <param name="ATable"></param>
        /// <param name="AFields"></param>
        /// <param name="AValues"></param>
        /// <returns></returns>
        public static int DoInsert(string ATable, string[] AFields, object[] AValues)
        {
            string sql = "Insert into " + ATable + "(";
            for (int i = 0; i < AFields.Length; i++)
            {
                sql += AFields[i] + " ,";
            }
            sql = sql.Substring(0, sql.Length - 1) + ") values (";
            string[] APs = new string[AFields.Length];

            for (int i = 0; i < AFields.Length; i++)
            {
                APs[i] = "@AP_" + AFields[i];

                sql += APs[i] + " ,";

            }
            sql = sql.Substring(0, sql.Length - 1) + ") ";
            return DoExecute(sql, APs, AValues);
        }
        /// <summary>
        /// 更新数据表
        /// </summary>
        /// <param name="ATable"></param>
        /// <param name="AFields"></param>
        /// <param name="AValues"></param>
        /// <param name="ACondFields"></param>
        /// <param name="ACondValues"></param>
        /// <returns></returns>
        public static int DoUpdate(string ATable, string[] AFields, object[] AValues,
                string[] ACondFields, object[] ACondValues
            )
        {
            string[] APs = new string[AFields.Length + ACondFields.Length];
            object[] AVs = new object[AValues.Length + ACondValues.Length];
            string sql = "Update " + ATable + " Set ";
            for (int i = 0; i < AFields.Length; i++)
            {
                APs[i] = "@AF_" + AFields[i];
                AVs[i] = AValues[i];
                sql += AFields[i] + " =" + APs[i] + " ,";
            }
            sql = sql.Substring(0, sql.Length - 1);
            if (ACondValues != null)
            {
                sql += " where (1>0) ";
                for (int i = 0; i < ACondFields.Length; i++)
                {
                    APs[i + AFields.Length] = "@AP_" + ACondFields[i];
                    AVs[i + AFields.Length] = ACondValues[i];
                    sql += " and " + ACondFields[i] + " =" + APs[i + AFields.Length];
                }
            }
            return DoExecute(sql, APs, AVs);
        }
        public static int DoDelete(string ATable, string[] ACondFields, object[] ACondValues)
        {
            string[] APs = new string[ACondFields.Length];
            object[] AVs = new object[ACondValues.Length];
            string sql = "Delete From  " + ATable + "  ";

            if (ACondValues != null)
            {
                sql += " where (1>0) ";
                for (int i = 0; i < ACondFields.Length; i++)
                {
                    APs[i] = "@AP_" + ACondFields[i];
                    AVs[i] = ACondValues[i];
                    sql += " and " + ACondFields[i] + " =" + APs[i];
                }
            }
            return DoExecute(sql, APs, AVs);
        }
    }
}
