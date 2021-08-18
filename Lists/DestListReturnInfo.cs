using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbrellaAutomation.Lists
{
    public class Status
    {
        public int code { get; set; }
        public string text { get; set; }
    }

    public class Meta
    {
        public int page { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
        public int destinationCount { get; set; }
        public int domainCount { get; set; }
        public int urlCount { get; set; }
        public int ipv4Count { get; set; }
        public int applicationCount { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public int organizationId { get; set; }
        public string access { get; set; }
        public bool isGlobal { get; set; }
        public string name { get; set; }
        public object thirdpartyCategoryId { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime modifiedAt { get; set; }
        public bool isMspDefault { get; set; }
        public bool markedForDeletion { get; set; }
        public int bundleTypeId { get; set; }
        public Meta meta { get; set; }
    }

    public class DestListReturnInfo
    {
        public Status status { get; set; }
        public Meta meta { get; set; }
        public List<Datum> data { get; set; }
    }

}
