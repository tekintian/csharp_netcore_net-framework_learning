using System.Security.Cryptography;
using System.Text;

namespace LearnCSharp.security
{
    public static class MyHash
    {
        //获取字符串的hash值,支持 sha256或者 md5
        public static string GetHash(string txt, string type="sha256", string salt = "Tekin", int repeatNum = 1) {
            
            string retStr=null;

            switch (type.ToLower())
            {
                case "md5":
                    retStr = GetMd5(txt, salt);
                    if (repeatNum>1)
                    {
                        for (int i = 1; i < repeatNum; i++)
                        {
                            retStr = GetMd5(retStr, salt);
                        }
                    }
                    
                    break;
                case "sha256":
                default:
                    retStr = GetSha(txt, salt);
                    if (repeatNum > 1)
                    {
                        for (int i = 1; i < repeatNum; i++)
                        {
                            retStr = GetSha(retStr, salt);
                        }
                    }
                    break;
            }

            return retStr;
        }
        public static string GetMd5(string txt,string salt="Tekin") {
            StringBuilder sb = new StringBuilder();

            //创建一个计算MD5值得对象
            using (MD5 md5 = MD5.Create()) {
                //把字符串转换为byte数组
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(txt+salt);
                //将字符数组转换为字符串
                //string str = Encoding.UTF8.GetString(bytes);

                //调用该对象的方法进行md5计算
                byte[] md5byte = md5.ComputeHash(bytes);

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

        public static string GetSha(string txt, string salt = "Tekin")
        {
            StringBuilder sb = new StringBuilder();

            //创建一个计算SHA256值的对象
            using (SHA256 mysha = SHA256.Create())
            {
                //把字符串转换为byte数组
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(txt + salt);
                //将字符数组转换为字符串
                //string str = Encoding.UTF8.GetString(bytes);

                //调用该对象的方法进行md5计算
                byte[] shabyte = mysha.ComputeHash(bytes);

                //把结果以字符串的显示返回
                for (int i = 0; i < shabyte.Length; i++)
                {
                    //这里的 x2    x表示以小写16进制显示字符, 2表示位宽位2位不足的前面补0
                    sb.Append(shabyte[i].ToString("x2"));
                }
                //返回字符串
                return sb.ToString();
            }

        }
    }
}
