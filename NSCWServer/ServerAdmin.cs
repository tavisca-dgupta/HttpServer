using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSCWServer
{
    class ServerAdmin
    {
        public static void Main(string[] args)
        {
            ManageUrl url = new ManageUrl();
            Console.WriteLine("enter the prefixes you want you server to listen to type 'start' to start server after that");

            while (true)
            {
                string prefix = Console.ReadLine();
                //string prefix = "http://localhost:8186/";
                if (prefix.ToLower().Equals("start"))
                {
                    break;
                }
                url.AddPrefix(prefix);
            }
            WebServer webServer = new WebServer(url);
            try
            {
                webServer.StartServer();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey(true);
            //Console.WriteLine("enter 'stop' to stop server");
            //string input=Console.ReadLine();
            //if(input.ToLower().Equals("stop"))
            //{
            //    webServer.StopServer();
            //}
        }
    }
   
}
