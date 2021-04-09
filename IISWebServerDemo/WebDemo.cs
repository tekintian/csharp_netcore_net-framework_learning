using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISWebServerDemo
{
    public class WebDemo : IMyHttpHandler
    {
        public void ProcessRequest(MyHttpContext context)
        {
            string str = $"<!DOCTYPE html><html lang=en> <head><meta charset=UTF-8>" +
               $"<meta name=viewport content=\"width = device - width, initial - scale = 1.0\">" +
               $"<title>Hello World Aspx from C#</title></head> " +
               $"<body> <h1>Hello world!</h1>" +
               $"<h2>当前时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}</2> " +
               $"</body> </html>";
            context.Response.StateCode = "200";
            context.Response.StateDes = "OK";
            context.Response.ContentType = "text/html";
            context.Response.Body = Encoding.UTF8.GetBytes(str);
        }
    }
}
