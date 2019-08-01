using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace NSCWServer
{
    public class WebServer
    {
        private static ManageUrl _url;
        private RequestListener _requestListener;
        private Request _request;
        HttpListener _listener;
        private FileHandle _fileHandle;
        private Response _response;
       public WebServer(ManageUrl url)
        {
            _url = url;
            _requestListener = new RequestListener();
            _fileHandle = new FileHandle();
            _request = new Request();
            _response = new Response();
        }
        public void StartServer()
        {
            _listener = _requestListener.StartListening(_url.GetAllPrefixes());
            new Thread(_ =>
           {
               while(true)
               {
                   HttpListenerContext context = _listener.GetContext();
                   HttpListenerRequest request = context.Request;
                   HttpListenerResponse response = context.Response;
                   string url = _request.GetUrlofRequest(request);
                   string responseToSend = _fileHandle.DataInFile(_fileHandle.FilePath(url, _url.GetAllPrefixes()));
                   _response.SendResponse(response, responseToSend);
               }
           }).Start();
                
        }
        public void StopServer()
        {
            _requestListener.StopListening();
        }
        public bool IsListenerSupported()
        {
            return HttpListener.IsSupported;
        }
    }
   
}
