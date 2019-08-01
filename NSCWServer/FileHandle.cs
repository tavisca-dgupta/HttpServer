using System.Collections.Generic;
using System.IO;

namespace NSCWServer
{
    public class FileHandle
    {
        private string basePath = "C://WebPages//";
        public string FilePath(string url,List<string> prefixes)
        {
            foreach(string prefix in prefixes)
            {
                if(url.Contains(prefix))
                {
                    url=url.Replace(prefix, basePath);
                    break;
                }

            }
            return url;
        }
        public string DataInFile(string filePath)
        {
            string data;
            try
            {
                data= File.ReadAllText(filePath);
            }
            catch(FileNotFoundException e)
            {
                data = "<HTML><BODY><h1>404 Not Found</h1><p>Web Page not found!!!!!!!!!!!</p></BODY></HTML>";
            }
            return data;
        }
    }
   
}
