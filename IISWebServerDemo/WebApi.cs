using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISWebServerDemo
{
    public class WebApi : IMyHttpHandler
    {
        public void ProcessRequest(MyHttpContext context)
        {
            string str = $"<!DOCTYPE html><html lang=en> <head><meta charset=UTF-8>" +
              $"<meta name=viewport content=\"width = device - width, initial - scale = 1.0\">" +
              $"<title> C# webapi</title></head> " +
              $"<body> <h1>Weocome to C# webapi page!</h1>" +
              $"<h2>{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}</h2> " +
              $"<h3>{AppDomain.CurrentDomain.ToString()}</h3> " +
              $"</body> </html>";
            context.Response.StateCode = "200";
            context.Response.StateDes = "OK";
            context.Response.ContentType = "text/html";
            context.Response.Body = Encoding.UTF8.GetBytes(str);
        }
    }
}
