namespace FluentTc.Engine
{
    public interface IHttpClientWrapperFactory
    {
        IHttpClientWrapper CreateHttpClientWrapper();
    }

    internal class HttpClientWrapperFactory : IHttpClientWrapperFactory
    {
        public IHttpClientWrapper CreateHttpClientWrapper()
        {
            return new HttpClientWrapper();
        }
    }
}