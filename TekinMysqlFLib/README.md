# C# mysql连接类库封装


## NuGet包安装

### MySqlConnector.1.3.2
System.Threading.Tasks.Extensions.4.3.0
MySqlConnector.1.3.2

- Mysql 连接字符串:
"server=YOURSERVER;user=YOURUSERID;password=YOURPASSWORD;database=YOURDATABASE"
或者
"host=127.0.0.1;port=3306;user id=mysqltest;password=Password123;database=mysqldb"

示例:
"server=192.168.2.8;user=netdemo;password=netdemo888;database=netdemo"


官方文档 https://mysqlconnector.net/tutorials/connect-to-mysql/

### System.Configuration.ConfigurationManager
依赖包:
System.Security.Principal.Windows.5.0.0
System.Security.AccessControl.5.0.0
System.Security.Permissions.5.0.0
System.Configuration.ConfigurationManager.5.0.0

## 配置文件示例 App.config
~~~config
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <!--数据库连接配置信息-->
	<connectionStrings>
		<add name="mysql" connectionString="server=192.168.2.8;user=netdemo;password=netdemo888;database=netdemo;charset=utf8mb4;" />
	</connectionStrings>
</configuration>
~~~

## 使用示例:
~~~cs
//int id = 13;
//string sql = "select id,pid,name from tb_area where id=@id";

//MySqlParameter[] pms = { 
//    new MySqlParameter("@id", MySqlDbType.Int32) { Value = id }
//};

/*DataTable dt= MysqlHelper.ExecuteDatatable(sql,CommandType.Text,pms);

 foreach (DataRow item in dt.Rows)
 {
     Console.WriteLine(item["name"]);
 }

 //获取第一行数据
 DataRow row = MysqlHelper.GetDataRow(sql, CommandType.Text, pms);
 if (row.ItemArray.Length>0)
 {
     Console.WriteLine("id={0},name={1},pid={2}", row["id"], row["name"], row["pid"]);
 }*/


//var elements = new Dictionary<string, DBVal>();
//elements.Add("@id", new DBVal() { Val = "12", Type = "int" });

/*//reader 必须要使用using
using (MySqlDataReader reader = MysqlHelper.ExecuteReader(sql, CommandType.Text, pms))
{
    if (reader.HasRows)
    {
        while (reader.Read())
        {
            Console.WriteLine(reader["name"]);
        }
    }
    else
    {
        Console.WriteLine("未查询到数据");
    }

}*/


/*//只返回一个值 第一行第一例的值
object obj = SQLiteHelper.ExecuteScalar(sql, pms);
Console.WriteLine("查询到的数据是{0}", obj);*/

//查询参数
int idUp = 13;
string newName = "Chongqing";

// 
string sqlUpdate = "update tb_area set name=@name where id=@id";

//绑定多个参数
SQLiteParameter[] pms2 = new SQLiteParameter[] {
                   new SQLiteParameter("@id", DbType.Int32) { Value = idUp },
                   new SQLiteParameter("@name",DbType.String){ Value= newName }
               };

int afNum = SQLiteHelper.ExecuteNonQuery(sqlUpdate, pms2);
if (afNum > 0)
{
    Console.WriteLine("执行成功,一共更新了{0}条数据", afNum);
}
else
{
    Console.WriteLine("执行失败,错误代码:{0}", afNum);
}

~~~



## 进一步封装示例
~~~cs
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
        public static readonly string conStr = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
        public static DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            MySqlConnection conn = new MySqlConnection(conStr);
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
            MySqlConnection conn = new MySqlConnection(conStr);
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

~~~
