using System.Net;

namespace NSCWServer
{
    public class Request
    {
        
        public string GetUrlofRequest(HttpListenerRequest request)
        {
            return request.Url.ToString();
        }
    }
   
}
