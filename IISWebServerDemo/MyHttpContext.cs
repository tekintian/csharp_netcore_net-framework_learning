using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISWebServerDemo
{
   public class MyHttpContext
    {
        public MyHttpRequest Request { get; set; }
        public MyHttpResponse Response { get; set; }

        public MyHttpContext(string requestStr)
        {
            Request = new MyHttpRequest(requestStr);
            Response = new MyHttpResponse();
        }

    }
}
