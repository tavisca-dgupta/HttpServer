using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NSCWServer
{
    public class RequestListener
    {
        private static HttpListener listener;
        
        public HttpListener StartListening(string[] prefixes)
        {
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            // Create a listener.
            listener = new HttpListener();
            // Add the prefixes.
            foreach (string prefix in prefixes)
            {
                listener.Prefixes.Add(prefix);
            }
            listener.Start();
            Console.WriteLine("Hey I am Listening...");
            return listener;
        }
    }
}
