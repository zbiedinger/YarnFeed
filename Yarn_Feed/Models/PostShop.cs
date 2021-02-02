using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yarn_Feed.Models
{

    public class Rootobject
    {
        public Shop shop { get; set; }
        public Brand[] brands { get; set; }
        public object ad { get; set; }
    }

    public class Shop
    {
        public string address { get; set; }
        public string city { get; set; }
        public bool closed { get; set; }
        public string facebook_page { get; set; }
        public bool free_wifi { get; set; }
        public int id { get; set; }
        public float latitude { get; set; }
        public string location { get; set; }
        public float longitude { get; set; }
        public string name { get; set; }
        public object parking { get; set; }
        public string permalink { get; set; }
        public string phone { get; set; }
        public bool pos_online { get; set; }
        public bool ravelry_retailer { get; set; }
        public bool seating { get; set; }
        public string shop_email { get; set; }
        public string twitter_id { get; set; }
        public string url { get; set; }
        public object wheelchair_access { get; set; }
        public string zip { get; set; }
        public object distance { get; set; }
        public string notes_html { get; set; }
        public Country country { get; set; }
        public State state { get; set; }
    }

    public class Country
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class State
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Brand
    {
        public string permalink { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public bool verified { get; set; }
        public bool advertised { get; set; }
        public object[] yarns { get; set; }
        public string most_recent_purchase { get; set; }
    }
}
