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

        //Stash Values
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


        // Shop Values
        public string Address { get; set; }
        public string City { get; set; }
        public string facebook_page { get; set; }
        public int? shop_id { get; set; }
        public float? latitude { get; set; }
        public string location { get; set; }
        public float? longitude { get; set; }
        public string shop_name { get; set; }
        public string shop_permalink { get; set; }
        public string phone { get; set; }
        public bool? pos_online { get; set; }
        public bool? ravelry_retailer { get; set; }
        public string shop_email { get; set; }
        public string twitter_id { get; set; }
        public string url { get; set; }
        public string zip { get; set; }
        public string notes_html { get; set; }
        public string country { get; set; }
        public string state { get; set; }

        //Project Values
        public string completed { get; set; }
        public string created_at { get; set; }
        public int? project_id { get; set; }
        public string made_for { get; set; }
        public string project_name { get; set; }
]        public int? progress { get; set; }
        public string project_status_changed { get; set; }
        public int? rating { get; set; }
        public string size { get; set; }
        public string started { get; set; }
        public string updated_at { get; set; }
        public string craft_name { get; set; }
        public string status_name { get; set; }
        public string needle_sizes { get; set; }
        public string needle_sizes2 { get; set; }
        public string needle_sizes3 { get; set; }
        public int? photos_count { get; set; }

        //Pattern Values
        public string currency { get; set; }
        public float? difficulty_average { get; set; }
        public int? difficulty_count { get; set; }
        public bool? downloadable { get; set; }
        public int? favorites_count { get; set; }
        public bool? free { get; set; }
        public int? pattern_id { get; set; }
        public string pattern_name { get; set; }
        public float? price { get; set; }
        public int? projects_count { get; set; }
        public int? queued_projects_count { get; set; }
        public float? rating_average { get; set; }
        public int? rating_count { get; set; }
        public int? yardage { get; set; }
        public int? yardage_max { get; set; }
        public string sizes_available { get; set; }
        public int? product_id { get; set; }
        public string currency_symbol { get; set; }
        public string gauge_description { get; set; }
        public string yarn_weight_description { get; set; }
        public string yardage_description { get; set; }

        //public string pattern_categories { get; set; }
        public string pattern_author { get; set; }

    }
}
