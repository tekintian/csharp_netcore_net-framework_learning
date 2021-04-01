using System;
using MySqlConnector;
using System.Data;
using System.Configuration;

namespace TekinMysqlFLib
{
    public static class MysqlHelper
    {
        /*
         * App.config配置信息
         <connectionStrings>
		   <add name = "mysql" connectionString="Server=192.168.2.8;Port=3306;User ID=netdemo;Password=netdemo888;Database=netdemo;Charset=utf8;" />
	      </connectionStrings>
        */
        //从App.config配置文件获取mysql的配置信息
        // public static readonly string conStr = "server=192.168.2.8;user=netdemo;password=netdemo888;database=netdemo;charset=utf8;Allow User Variables=true";
        public static readonly string conStr = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
        public static DataTable ExecuteDatatable(string sql,CommandType comType = CommandType.Text, params MySqlParameter[] pms)
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    if (pms !=null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(pms);
                    }
                    //设置命令类型 默认Text
                    adapter.SelectCommand.CommandType = comType;
                    // 填充数据
                    adapter.Fill(dt);

                    return dt;
                }
            }

        }
        //返回一行数据
        public static DataRow GetDataRow(string sql, CommandType comType = CommandType.Text, params MySqlParameter[] pms)
        {
            DataRow row = null;
            using (DataTable dt = ExecuteDatatable(sql,comType,pms))
            {
                if (dt.Rows.Count > 0)
                    row = dt.Rows[0];
            }
            return row;
        }

        public static int ExecuteNonQuery(string sql, CommandType cmdType = CommandType.Text, params MySqlParameter[] pms)
        {
            int ret;
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        cmd.CommandType = cmdType;

                        //判断是否有参数,有则增加参数
                        if (null != pms)
                        {
                            cmd.Parameters.AddRange(pms);
                        }

                        con.Open(); //打开链接

                        ret = Convert.ToInt32(cmd.ExecuteNonQuery());
                    }
                    catch (Exception e)
                    {
                        //关闭链接
                        con.Close();
                        con.Dispose();
                        ret = -2;

                        throw; //把当前catch中捕获的异常抛出给上层调用者
                        // throw new MyException(e.Message()); // 抛出一个自定义的异常
                    }
                }

            }

            return ret;
        }

        /**
         * 返回第一行第一例的值  object
         * string sql  要执行的sql语句
         * params MySqlParameter[] pms 可变参数数组
         */
        public static object ExecuteScalar(string sql, CommandType cmdType = CommandType.Text, params MySqlParameter[] pms)
        {
            //定义返回对象
            object ret;

            // 创建链接对象
            using (MySqlConnection con = new MySqlConnection(conStr))
            {

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        cmd.CommandType = cmdType;

                        if (null != pms)
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

                        ret = null;
                        throw;
                    }
                }
            }

            return ret;
        }
        /*
        * 注意 reader使用的时候一定要使用using语句来使用, 否则会造成链接和资源无法正确关闭
        * string sql ="select * from student";
        * using (SqlDataReader reader=SqlHelper.ExecuteReader(sql,CommandType.Text)){
        *  if(reader.HasRows) {  while(reader.Read()){   reader["id"]//获取id的值 }    }
        * }
        * 
        */
        public static MySqlDataReader ExecuteReader(string sql, CommandType cmdType = CommandType.Text, params MySqlParameter[] pms)
        {
            //初始化链接 注意这里的 SqlConnection不能使用using 会报 Cannot access a disposed object.错误
            MySqlConnection con = new MySqlConnection(conStr);
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                try
                {
                    cmd.CommandType = cmdType;

                    if (null != pms)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();

                    // System.Data.CommandBehavior.CloseConnection 表示 执行命令时，关闭关联的 DataReader 对象时，关联的 Connection 对象也会关闭。
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                }
                catch (Exception e)
                {
                    //错误时关闭资源
                    con.Close();
                    con.Dispose();

                    throw;
                }
            }

        }
       
    }
}
