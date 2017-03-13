using System.Text;
using System.Linq;

namespace Evol.Util.Hash
{
    public static class HashUtil
    {
        public static string Md5(string input)
        {
            var md5Hasher = System.Security.Cryptography.MD5.Create();
            var bytes = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            var result = bytes.Select(b => $"{b:x2}").ToArray();
            var output = string.Join(string.Empty, result);
            return output;
        }
    }
}
