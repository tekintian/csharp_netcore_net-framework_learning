using System;
using System.Data;
using System.Data.SqlClient;
using TekinMssqlFLib;

namespace ConsoleFApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = 12;
            string sql = "select name from tb_area where id=@id";
            object obj = SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text, new SqlParameter("@id", DbType.Int32) { Value = id });
            Console.WriteLine(obj);

            Console.ReadKey();

        }
    }
}
