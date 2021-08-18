using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using UmbrellaAutomation.Extensions;
using UmbrellaAutomation.Lists;

namespace UmbrellaAutomation.Web
{
    public static class APICore
    {
        private static string EncKey = Convert.ToBase64String(Encoding.ASCII.GetBytes("apiKey:secretKey"));
        private static string OrgID = "<org-id>";
        public static string GetLists()
        {
            try
            {
                var web = WebRequest.CreateHttp(
                    $"https://management.api.umbrella.com/v1/organizations/{OrgID}/destinationlists");
                web.Method = "GET";
                web.Headers[HttpRequestHeader.Authorization] = $"Basic {EncKey}";
                return web.ReadResponse();
            }
            catch(Exception ex)
            {
                Logger.LogError("Failure obtaining destination lists from Umbrella...");
            }
            return null;
        }

        public static string GetListItems(string ListID)
        {
            try
            {
                var web = WebRequest.CreateHttp(
                    $"https://management.api.umbrella.com/v1/organizations/{OrgID}/destinationlists/{ListID}/destinations");
                web.Method = "GET";
                web.Headers[HttpRequestHeader.Authorization] = $"Basic {EncKey}";
                return web.ReadResponse();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Failure obtaining list {ListID}'s items...");
            }
            return null;
        }

        public static bool AddDestinationItem(string ListID,List<Destination> dest)
        {
            try
            {
                var raw = JsonConvert.SerializeObject(dest);
                var data = Encoding.ASCII.GetBytes(raw);
                var web = WebRequest.CreateHttp(
                    $"https://management.api.umbrella.com/v1/organizations/{OrgID}/destinationlists/{ListID}/destinations");
                web.Method = "POST";
                web.Headers[HttpRequestHeader.Authorization] = $"Basic {EncKey}";
                web.ContentType = "application/json";
                web.ContentLength = data.Length;
                using (var stream = web.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length); // Assigning POST data
                }

                var returned = web.ReadResponse();
                
                return true;
            }
            catch(Exception ex)
            {
                Logger.LogError($"Failed adding items to {ListID}...");
                return false;
            }
        }

    }
}
