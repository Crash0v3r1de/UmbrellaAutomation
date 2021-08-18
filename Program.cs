using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UmbrellaAutomation.Extensions;
using UmbrellaAutomation.Lists;
using UmbrellaAutomation.Web;

namespace UmbrellaAutomation
{
    class Program
    {
        /// <summary>
        /// Automatically parses threat feed DNS block list, updates Cisco Umbrella and then exits
        /// Currently only parses one feed but could easily be modified for multiple feeds
        /// </summary>
        /// <param name="args"></param>

        private static int AddedDomains = 0;
        static void Main(string[] args)
        {
            OutputConsole(LogType.Info,"Parsing the threat feed domain block list....");
            var ms_items = ThreatFeed.GetDomains();
            OutputConsole(LogType.Info, "Parsed successfully!");
            OutputConsole(LogType.Info, "Updating Umbrella threat feed block destination list...");
            ProcessDomains(ms_items, JsonConvert.DeserializeObject<DestListItems>(APICore.GetListItems("<list-id>")));
            if(AddedDomains != 0) OutputConsole(LogType.Info, $"Added {AddedDomains} domain(s) to the threat feed destination list!");
            else OutputConsole(LogType.Info, "No new domains to add to the threat feed destination list!");

            Environment.Exit(0);
        }

        private static void ProcessDomains(List<string> domains,DestListItems items)
        {
            if (domains.Count != 0)
            {
                List<Destination> PendingDestinations = new List<Destination>();
                foreach (var dom in domains)
                {
                    if (!String.IsNullOrWhiteSpace(dom))
                    {
                        var currentItems = JsonConvert.DeserializeObject<DestListItems>(APICore.GetListItems("<list-id>"));
                        List<string> doms = new List<string>();
                        foreach (var current in currentItems.data)
                        {
                            doms.Add(current.destination);
                        }

                        if (!doms.Contains(dom)) // Domain is not currently in the destination list - add it
                        {
                            Destination dest = new Destination();
                            dest.comment = $"Added {DateTime.Now.ToString("MM/dd/yyyy")}";
                            dest.destination = dom;
                            PendingDestinations.Add(dest);
                            AddedDomains++;
                        }
                    }
                }

                if (PendingDestinations.Count != 0)
                {
                    APICore.AddDestinationItem("<list-id>", PendingDestinations);
                }
            }
        }

        private static void OutputConsole(LogType type,string msg)
        {
            switch (type)
            {
                case LogType.Info:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(msg);
                    Logger.LogInfo(msg);
                    Console.ForegroundColor = default;
                    break;
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(msg);
                    Logger.LogWarning(msg);
                    Console.ForegroundColor = default;
                    break;
                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(msg);
                    Logger.LogError(msg);
                    Console.ForegroundColor = default;
                    break;
            }
        }
    }
}
