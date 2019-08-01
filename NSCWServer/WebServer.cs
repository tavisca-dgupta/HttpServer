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
        private ServerRequest _request;
        private HttpListener _listener;
        private FileHandle _fileHandle;
        private ServerResponse _response;
       public WebServer(ManageUrl url)
        {
            _url = url;
            _requestListener = new RequestListener();
            _fileHandle = new FileHandle();
            _request = new ServerRequest(_fileHandle,_url);
            _response = new ServerResponse();
        }
        public void StartServer()
        {
            _listener = _requestListener.StartListening(_url.GetAllPrefixes());
            while (true)
            {
                OnRequestReceived(_listener);
            }
        }

        public void OnRequestReceived(HttpListener httpListener)
        {
            HttpListenerContext context = _listener.GetContext();
            string responseToSend = _request.Process(context);
            HttpListenerResponse response = context.Response;
            _response.SendResponse(response, responseToSend);

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
