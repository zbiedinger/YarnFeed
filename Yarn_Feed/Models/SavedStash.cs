using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yarn_Feed.Models
{
    public class SavedStash
    {
        [Key]
        public int Id { get; set; }
        public bool has_photo { get; set; }
        public int? stash_API_id { get; set; }
        public int? user_id { get; set; }
        public string name { get; set; }
        public string colorway_name { get; set; }
        public string color_family_name { get; set; }
        public string yarn_weight_name { get; set; }
        public string shelved_url { get; set; }
        public string medium_url { get; set; }
        public string company_name { get; set; }
        public int? fiber1Percent { get; set; }
        public string fiber1 { get; set; }
        public int? fiber2Percent { get; set; }
        public string fiber2 { get; set; }
        public int? fiber3Percent { get; set; }
        public string fiber3 { get; set; }
    }
}
