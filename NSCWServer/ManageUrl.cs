namespace NSCWServer
{
    public class ManageUrl
    {
        private static string[] prefixes;
        public static int count = 0;

        public void AddPrefix(string prefix)
        {
            prefixes[count] = prefix;
            count++;
        }

        public string[] GetAllPrefixes()
        {
            return prefixes;
        }
    }
   
}
