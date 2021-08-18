using System.IO;
using System.Net;

namespace UmbrellaAutomation.Extensions
{
    public static class HttpWebRequestExtension
    {
        public static string ReadResponse(this HttpWebRequest request)
        {
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
