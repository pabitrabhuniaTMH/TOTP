using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;

namespace OTPServices.ServiceHelper
{
    static class Helper
    {
        public static string GetLocalAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString() + host.HostName.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z2-7]+", "", RegexOptions.Compiled);
        }
    }
}
