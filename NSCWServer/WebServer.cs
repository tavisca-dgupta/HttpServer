using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace NSCWServer
{
    public class WebServer
    {
        private ManageUrl _url;
        private RequestListener _requestListener;
        HttpListener _listener;
       public WebServer(RequestListener listener)
        {
            _url = new ManageUrl();
            _requestListener = listener;
        }
        public void StartServer()
        {
            _listener = _requestListener.StartListening(_url.GetAllPrefixes());
            while (_listener.IsListening)
            {
                // Note: The GetContext method blocks while waiting for a request. 
                HttpListenerContext context = _listener.GetContext();
                HttpListenerRequest request = context.Request;
                // Obtain a response object.
                HttpListenerResponse response = context.Response;
                // Construct a response.
                string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
            }
        }
        public static void StopServer()
        {

        }
        public bool IsListenerSupported()
        {
            return HttpListener.IsSupported;
        }
    }
   
}
