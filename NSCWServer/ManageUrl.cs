using System.Collections.Generic;

namespace NSCWServer
{
    public class ManageUrl
    {
        private static List<string> prefixes;
        public ManageUrl()
        {
            prefixes = new List<string>();
        }
        public void AddPrefix(string prefix)
        {
            prefixes.Add(prefix);
        }

        public List<string> GetAllPrefixes()
        {
            return prefixes;
        }
    }
   
}
