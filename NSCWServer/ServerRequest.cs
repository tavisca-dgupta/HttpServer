using System.Net;

namespace NSCWServer
{
    public class ServerRequest
    {
        private FileHandle _fileHandle;
        private ManageUrl _url;
        public ServerRequest(FileHandle fileHandle,ManageUrl url)
        {
            _fileHandle = fileHandle;
            _url = url;
        }
        public string GetUrlofRequest(HttpListenerRequest request)
        {
            return request.Url.ToString();
        }

        public string Process(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            string url = GetUrlofRequest(request);
            string responseToSend = _fileHandle.DataInFile(_fileHandle.FilePath(url, _url.GetAllPrefixes()));
            return responseToSend;
        }
    }
   
}
