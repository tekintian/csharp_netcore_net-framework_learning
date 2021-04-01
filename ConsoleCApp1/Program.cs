using System;
using System.Data;
using System.Data.SQLite;
using TekinSQLiteFLib;

namespace ConsoleCApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = 13;
            string sql = "select id,pid,name from tb_area where pid=@id";

            //object obj = SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text, new SqlParameter("@id", DbType.Int32) { Value = id });

            //创建sqlite查询参数,注意:如果有多个参数就要初始化多个参数对象new SQLiteParameter(){}, 多个以逗号隔开
            //SQLiteParameter[] pms = new SQLiteParameter[] { new SQLiteParameter("@id", DbType.Int32) { Value = id } };

            /*DataTable dt = TekinSQLiteFLib.SQLiteHelper.ExecuteDataTable(sql, pms);
            foreach (DataRow item in dt.Rows)
            {
                Console.WriteLine(item["name"]);
            }*/

            /*  //reader 必须要使用using
              using (SQLiteDataReader reader = SQLiteHelper.ExecuteReader(sql,pms))
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
            /* int idUp = 13;
             string newName = "Chongqing2";

             try
             {
                 string connectionString = @"Data Source = ../../../lib/mydb.db3; Version = 3";

                 using (var conn = new SQLiteConnection(connectionString))
                 {
                     using (var cmd = new SQLiteCommand())
                     {
                         cmd.Connection = conn;
                         cmd.CommandText = "update tb_area set name=@name where id=@id";

                         conn.Open();
                         SQLiteParameter[] pms2 = {
                  new SQLiteParameter("@id", DbType.Int32) { Value = idUp },
                  new SQLiteParameter("@name",DbType.String){ Value=newName }
              };
                         cmd.Parameters.AddRange(pms2);
                         //cmd.Parameters.AddWithValue("@KEY", key.Text);
                         var reader = cmd.ExecuteNonQuery();
                          Console.WriteLine("执行:{0}", reader);
                     }
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }
 */


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

            Console.ReadKey();
        }
    }
}
