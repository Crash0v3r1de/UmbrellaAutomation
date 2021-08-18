using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbrellaAutomation.Lists
{
    public class DstLstStatus
    {
        public int code { get; set; }
        public string text { get; set; }
    }

    public class DstLstMeta
    {
        public int page { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
    }

    public class DstLstDatum
    {
        public string id { get; set; }
        public string destination { get; set; }
        public string type { get; set; }
        public object comment { get; set; }
        public string createdAt { get; set; }
    }

    public class DestListItems
    {
        public DstLstStatus status { get; set; }
        public DstLstMeta meta { get; set; }
        public List<DstLstDatum> data { get; set; }
    }

}
