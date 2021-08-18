using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UmbrellaAutomation.Extensions;

namespace UmbrellaAutomation.Web
{
    public static class ThreatFeed
    {
        public static List<string> GetDomains()
        {
            try
            {
                var items = new WebClient().DownloadString("<url to thread feed here>");
                // To have more then one thread feed you can tweak this pretty easily to those needs
                List<string> listed = new List<string>();
                if (!String.IsNullOrWhiteSpace(items))
                {
                    foreach (var line in items.Split('\n'))
                    {
                        listed.Add(line.Replace("\r", "")); // it still leaves the \r since I did not add that into the split above
                    }
                }
                return listed;
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed parsing threat feed DNS block list feed....please manually check");
                return null;
            }
        }
    }
}
