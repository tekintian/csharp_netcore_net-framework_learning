﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MsSqlHelper
{
    public static class SqlHelper
    {
        // 从配置文件中读取sql链接字符串
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["mssql"].ConnectionString;

        //命令类型: 默认 Text 正常SQL语句; StoredProcedure 存储过程
        // CommandType cmdType = CommandType.Text;

        // 执行 insert  update  delete 的方法  返回受影响的行数
        public static int ExecuteNonQuery(string sql, CommandType cmdType = CommandType.Text, params SqlParameter[] pms)
        {
            int ret;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
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
         * params SqlParameter[] pms 可变参数数组
         */
        public static object ExecuteScalar(string sql, CommandType cmdType = CommandType.Text, params SqlParameter[] pms)
        {
            //定义返回对象
            object ret;

            // 创建链接对象
            using (SqlConnection con = new SqlConnection(conStr))
            {

                using (SqlCommand cmd = new SqlCommand(sql, con))
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

        public static SqlDataReader ExecuteReader(string sql, CommandType cmdType = CommandType.Text, params SqlParameter[] pms)
        {
            //初始化一个返回对象
            SqlDataReader retReader = null;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
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
                        retReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    }
                    catch (Exception e)
                    {
                        con.Close();
                        con.Dispose();

                        throw;
                    }
                }

            }
            return retReader;
        }

        //查询数据并返回DataTable
        public static DataTable ExecuteDataTable(string sql, CommandType cmdType = CommandType.Text, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conStr))
            {
                adapter.SelectCommand.CommandType = cmdType; //设置命令类型
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }

                adapter.Fill(dt);
            }
            return dt;
        }
    }
}