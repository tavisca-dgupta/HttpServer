using System.Net;

namespace NSCWServer
{
    public class ServerResponse
    {
        public void  SendResponse(HttpListenerResponse response,string responseToSend)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseToSend);
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
        }
    }
   
}
