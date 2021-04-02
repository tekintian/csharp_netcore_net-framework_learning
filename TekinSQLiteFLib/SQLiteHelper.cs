using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace TekinSQLiteFLib
{
    public static class SQLiteHelper
    {
        //从项目的配置文件App.config 获取配置信息
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["sqlite"].ConnectionString;

      // 执行 insert  update  delete 的方法  返回受影响的行数
       public static int ExecuteNonQuery(string sql,  params SQLiteParameter[] pms)
        {
            int ret=-1;
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    try
                    {
                      //判断是否有参数,有则增加参数
                      if (pms.Length > 0) cmd.Parameters.AddRange(pms);

                       con.Open(); //打开链接
                       ret = cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                       //关闭链接
                       con.Close();
                       con.Dispose();

                        throw e; //把当前catch中捕获的异常抛出给上层调用者
                      // throw new MyException(e.Message()); // 抛出一个自定义的异常
                     }
                }

            }

            return ret;
        }

        //返回第一行第一例的值
        public static object ExecuteScalar(string sql, params SQLiteParameter[] pms)
        {
            //定义返回对象
            object ret=null;

            // 创建链接对象
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {

                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    try
                    {
                        if (pms.Length > 0)
                        {
                            cmd.Parameters.AddRange(pms);
                        }
                        con.Open();//打开链接
                        ret = cmd.ExecuteScalar();
                    }
                    catch (Exception e)
                    {
                        //如果发生异常,则关闭资源
                        con.Close();
                        con.Dispose();

                        throw;
                    }
                }
            }

            return ret;
        }


        //返回DataTable数据
        public static DataTable ExecuteDataTable(string sql, params SQLiteParameter[] pms)
        {
            //创建dt对象
            DataTable dt = new DataTable();
            //创建链接对象
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                //创建Adapter适配器
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, con);
                //如果有参数增加参数
                if (pms.Length > 0)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                //执行数据填充
                adapter.Fill(dt);
            }
            return dt;
        }
        /*
        * 注意 reader使用的时候一定要使用using语句来使用, 否则会造成链接和资源无法正确关闭
        * string sql ="select * from student";
        * using (SqlDataReader reader=SqlHelper.ExecuteReader(sql,CommandType.Text)){
        *  if(reader.HasRows) {  while(reader.Read()){   reader["id"]//获取id的值 }    }
        * }
        *
        */
        public static SQLiteDataReader ExecuteReader(string sql, params SQLiteParameter[] pms)
        {
            //创建链接,注意这里的链接不能使用using否则返回的reader将无法使用
            SQLiteConnection con = new SQLiteConnection(conStr);
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                //这里使用try catch确保在发生错误时能正确关闭资源
                try
                {
                    if (pms.Length > 0) cmd.Parameters.AddRange(pms);

                    con.Open();

                    // System.Data.CommandBehavior.CloseConnection 表示 执行命令时，关闭关联的 DataReader 对象时，关联的 Connection 对象也会关闭。
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                }
                catch(Exception ex)
                {
                    con.Close();
                    con.Dispose();

                    throw ex;
                }
            }
        }

    }
}
