using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Yarn_Feed.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string PostContent { get; set; }
        public string TypeOfPost { get; set; }
        public string PostedByUserName { get; set; }
        public DateTime TimePosted { get; set; }

        [ForeignKey("Crafter")]
        public int? CrafterId { get; set; }
        public Crafter Crafter { get; set; }

        //[ForeignKey("PostProject")]
        //public int? ProjectId { get; set; }
        //public PostProject PostProject { get; set; }

        //[ForeignKey("PostPattern")]
        //public int? PatternId { get; set; }
        //public PostPattern PostPattern { get; set; }

        //[ForeignKey("SavedStash")]
        //public int? StashId { get; set; }
        //public PostStash SavedStash { get; set; }

        //[ForeignKey("PostShop")]
        //public int? ShopId { get; set; }
        //public PostShop PostShop { get; set; }

        public bool stash_has_photo { get; set; }
        public int? stash_API_id { get; set; }
        public int? user_id { get; set; }
        public string stash_name { get; set; }
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
