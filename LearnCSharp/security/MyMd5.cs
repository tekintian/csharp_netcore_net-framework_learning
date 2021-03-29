using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp.security
{
     public static class MyMd5
    {
        public static string GetMd5(string txt,string salt="Tekin",int repeatNum=1) {
            StringBuilder sb = new StringBuilder();

            //创建一个计算MD5值得对象
            using (MD5 md5 = MD5.Create()) {
                //把字符串转换为byte数组
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(txt+salt);
                //将字符数组转换为字符串
                //string str = Encoding.UTF8.GetString(bytes);

                //调用该对象的方法进行md5计算
                byte[] md5byte = md5.ComputeHash(bytes);

                if (repeatNum>1)
                {
                    for (int i = 1; i < repeatNum; i++)
                    {
                        md5byte = md5.ComputeHash(md5byte);
                    }
                }

                //把结果以字符串的显示返回
                for (int i = 0; i < md5byte.Length; i++)
                {
                    //这里的 x2    x表示以小写16进制显示字符, 2表示位宽位2位不足的前面补0
                    sb.Append(md5byte[i].ToString("x2"));
                }
                //返回字符串
                return sb.ToString();
            }

        }
    }
}
