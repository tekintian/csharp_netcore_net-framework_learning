namespace IISWebServerDemo
{
    public interface IMyHttpHandler
    {
        void ProcessRequest(MyHttpContext context);
    }
}