# SQLite 链接库

##NuGet依赖库安装:

System.Configuration.ConfigurationManager  用于读取项目中的配置文件

System.Data.SQLite.Core 链接驱动库核心包(如果你要安装 System.Data.SQLiteh 这个也是可以的,不过这个会多安装很多的相关依赖包)


注意: 这里是System.Data.SQLite.Core , 一定要安装的这个包,否则可能出错,  还有System.Data.SQLite包里面有个隐藏的SQLite.Interop类库, 因为只有在编译的时候才会生成, 所以需要在引用本类库的项目中也要使用NuGet安装一个 System.Data.SQLite.Core 驱动库的依赖. 否则运行是会报SQLite.Interop.dll模块无法加载等的错误.


## 调用类库项目App.config配置
~~~config
<?xml version="1.0" encoding="utf-8"?>
<configuration>

 <!-- SQLite连接配置 -->
 <connectionStrings>
    <add name="sqlite" connectionString="Data Source=../../lib/catemanager.db3;" />
  </connectionStrings>

  <!-- 其他配置项目 .... -->
</configuration>
~~~

注意这里的Data Source=后面跟的是sqlite数据库的路径, 可以使用相对路径,也可以使用绝对路径.
相对路径是相对的你的项目中的 bin/debug/ 的路径(.net framework项目); 
如果是netcore的项目,则相对路径是相对于 bin/debug/netxx/的路径


使用示例:
~~~cs
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
~~~

示例sqlite数据库
~~~sql

-- ----------------------------
-- Table structure for tb_area
-- ----------------------------
DROP TABLE IF EXISTS "tb_area";
CREATE TABLE "tb_area" (
  "id" INTEGER(11) NOT NULL,
  "pid" INTEGER(11),
  "name" TEXT(50),
  PRIMARY KEY ("id")
);

-- ----------------------------
-- Records of tb_area
-- ----------------------------
BEGIN;
INSERT INTO "tb_area" VALUES (11, 0, '北京');
INSERT INTO "tb_area" VALUES (12, 0, '天津');
INSERT INTO "tb_area" VALUES (1101, 11, '北京市辖');
INSERT INTO "tb_area" VALUES (1102, 11, '北京县辖');
INSERT INTO "tb_area" VALUES (1201, 12, '天津市辖');
INSERT INTO "tb_area" VALUES (1202, 12, '天津县辖');
COMMIT;
~~~














