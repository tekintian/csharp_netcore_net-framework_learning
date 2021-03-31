using System;
using System.Data.SqlClient;
using System.Data;
using TekinMssqlCLib;

namespace ConsoleCApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = 13;
            string sql = "select name from tb_area where id=@id";
            object obj = SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text, new SqlParameter("@id", DbType.Int32) { Value = id });
            Console.WriteLine(obj);

            Console.ReadKey();
        }
    }
}
