using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yarn_Feed.Models
{
    public class PostProject
    {
        public Project project { get; set; }
        public object[] comments { get; set; }
    }

    public class Project
    {
        public int comments_count { get; set; }
        public string completed { get; set; }
        public int craft_id { get; set; }
        public string created_at { get; set; }
        public int favorites_count { get; set; }
        public int id { get; set; }
        public string made_for { get; set; }
        public object made_for_user_id { get; set; }
        public string name { get; set; }
        public object pattern_id { get; set; }
        public string permalink { get; set; }
        public int progress { get; set; }
        public string project_status_changed { get; set; }
        public int project_status_id { get; set; }
        public int rating { get; set; }
        public string size { get; set; }
        public string started { get; set; }
        public string updated_at { get; set; }
        public int user_id { get; set; }
        public Links links { get; set; }
        public Personal_Attributes personal_attributes { get; set; }
        public object pattern_name { get; set; }
        public string craft_name { get; set; }
        public string status_name { get; set; }
        public object[] tag_names { get; set; }
        public string notes_html { get; set; }
        public string notes { get; set; }
        public Needle_Sizes[] needle_sizes { get; set; }
        public int photos_count { get; set; }
        public object ends_per_inch { get; set; }
        public object picks_per_inch { get; set; }
        public object gauge { get; set; }
        public object row_gauge { get; set; }
        public object gauge_repeats { get; set; }
        public object gauge_divisor { get; set; }
        public string gauge_pattern { get; set; }
        public object private_notes_html { get; set; }
        public object private_notes { get; set; }
        public Photo[] photos { get; set; }
        public Pack[] packs { get; set; }
        public User user { get; set; }
        public object[] tools { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Personal_Attributes
    {
        public bool favorited { get; set; }
        public object bookmark_id { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string tiny_photo_url { get; set; }
        public string small_photo_url { get; set; }
        public string photo_url { get; set; }
    }

    public class Needle_Sizes
    {
        public int id { get; set; }
        public string us { get; set; }
        public float metric { get; set; }
        public object us_steel { get; set; }
        public bool crochet { get; set; }
        public bool knitting { get; set; }
        public string hook { get; set; }
        public string name { get; set; }
        public string pretty_metric { get; set; }
    }

    public class Photo
    {
        public int id { get; set; }
        public int sort_order { get; set; }
        public int x_offset { get; set; }
        public int y_offset { get; set; }
        public string square_url { get; set; }
        public string medium_url { get; set; }
        public string thumbnail_url { get; set; }
        public string small_url { get; set; }
        public object flickr_url { get; set; }
        public string shelved_url { get; set; }
        public string medium2_url { get; set; }
        public string small2_url { get; set; }
        public object caption { get; set; }
        public object caption_html { get; set; }
        public object copyright_holder { get; set; }
    }

    public class Pack
    {
        public int id { get; set; }
        public object primary_pack_id { get; set; }
        public int project_id { get; set; }
        public float? skeins { get; set; }
        public object stash_id { get; set; }
        public int? total_grams { get; set; }
        public float? total_meters { get; set; }
        public float? total_ounces { get; set; }
        public float? total_yards { get; set; }
        public int yarn_id { get; set; }
        public string yarn_name { get; set; }
        public Yarn_Weight yarn_weight { get; set; }
        public string colorway { get; set; }
        public string shop_name { get; set; }
        public Yarn yarn { get; set; }
        public string quantity_description { get; set; }
        public object personal_name { get; set; }
        public string dye_lot { get; set; }
        public int color_family_id { get; set; }
        public int grams_per_skein { get; set; }
        public float yards_per_skein { get; set; }
        public float meters_per_skein { get; set; }
        public float ounces_per_skein { get; set; }
        public bool prefer_metric_weight { get; set; }
        public bool prefer_metric_length { get; set; }
        public object shop_id { get; set; }
        public object thread_size { get; set; }
    }

    public class Yarn_Weight
    {
        public string crochet_gauge { get; set; }
        public int id { get; set; }
        public string knit_gauge { get; set; }
        public object max_gauge { get; set; }
        public object min_gauge { get; set; }
        public string name { get; set; }
        public string ply { get; set; }
        public string wpi { get; set; }
    }

    public class Yarn
    {
        public string permalink { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string yarn_company_name { get; set; }
        public int yarn_company_id { get; set; }
    }
}
