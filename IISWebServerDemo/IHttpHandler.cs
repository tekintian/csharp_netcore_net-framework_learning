namespace IISWebServerDemo
{
    public interface IHttpHandler
    {
        void ProcessRequest(MyHttpContext context);
    }
}