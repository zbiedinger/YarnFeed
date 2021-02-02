using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yarn_Feed.Models
{

    public class PostStash
    {
        public Stash stash { get; set; }
        public User1 user { get; set; }
    }

    public class Stash
    {
        public int comments_count { get; set; }
        public string created_at { get; set; }
        public string dye_lot { get; set; }
        public int favorites_count { get; set; }
        public bool handspun { get; set; }
        public bool has_photo { get; set; }
        public int id { get; set; }
        public string location { get; set; }
        public string permalink { get; set; }
        public string updated_at { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public string notes_html { get; set; }
        public Stash_Status stash_status { get; set; }
        public string colorway_name { get; set; }
        public string color_family_name { get; set; }
        public string yarn_weight_name { get; set; }
        public string long_yarn_weight_name { get; set; }
        public object personal_yarn_weight { get; set; }
        public Photo1[] photos { get; set; }
        public Yarn yarn { get; set; }
        public Pack[] packs { get; set; }
        public User user { get; set; }
    }

    public class Stash_Status
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Yarn
    {
        public bool discontinued { get; set; }
        public int gauge_divisor { get; set; }
        public int grams { get; set; }
        public int id { get; set; }
        public object machine_washable { get; set; }
        public object max_gauge { get; set; }
        public float min_gauge { get; set; }
        public string name { get; set; }
        public string permalink { get; set; }
        public float rating_average { get; set; }
        public int rating_count { get; set; }
        public int rating_total { get; set; }
        public string texture { get; set; }
        public object thread_size { get; set; }
        public object wpi { get; set; }
        public int yardage { get; set; }
        public string notes_html { get; set; }
        public object min_needle_size { get; set; }
        public object max_needle_size { get; set; }
        public object min_hook_size { get; set; }
        public object max_hook_size { get; set; }
        public object personal_attributes { get; set; }
        public Yarn_Company yarn_company { get; set; }
        public Yarn_Weight yarn_weight { get; set; }
        public Yarn_Fibers[] yarn_fibers { get; set; }
        public Photo[] photos { get; set; }
    }

    public class Yarn_Company
    {
        public int id { get; set; }
        public string name { get; set; }
        public string permalink { get; set; }
        public string url { get; set; }
        public int yarns_count { get; set; }
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

    public class Yarn_Fibers
    {
        public int id { get; set; }
        public int percentage { get; set; }
        public Fiber_Type fiber_type { get; set; }
        public Fiber_Category fiber_category { get; set; }
    }

    public class Fiber_Type
    {
        public bool animal_fiber { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public bool synthetic { get; set; }
        public bool vegetable_fiber { get; set; }
    }

    public class Fiber_Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string permalink { get; set; }
        public Parent parent { get; set; }
    }

    public class Parent
    {
        public int id { get; set; }
        public string name { get; set; }
        public string permalink { get; set; }
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

    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string tiny_photo_url { get; set; }
        public string small_photo_url { get; set; }
        public string photo_url { get; set; }
    }

    public class Photo1
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
        public int? primary_pack_id { get; set; }
        public int? project_id { get; set; }
        public float skeins { get; set; }
        public int stash_id { get; set; }
        public int total_grams { get; set; }
        public float total_meters { get; set; }
        public float total_ounces { get; set; }
        public float total_yards { get; set; }
        public int yarn_id { get; set; }
        public string shop_name { get; set; }
        public string colorway { get; set; }
        public string quantity_description { get; set; }
        public object personal_name { get; set; }
        public string dye_lot { get; set; }
        public int? color_family_id { get; set; }
        public int? grams_per_skein { get; set; }
        public float? yards_per_skein { get; set; }
        public float? meters_per_skein { get; set; }
        public float? ounces_per_skein { get; set; }
        public bool prefer_metric_weight { get; set; }
        public bool prefer_metric_length { get; set; }
        public int? shop_id { get; set; }
        public object thread_size { get; set; }
        public object[] color_attributes { get; set; }
    }

    public class User1
    {
        public int id { get; set; }
        public string username { get; set; }
        public string tiny_photo_url { get; set; }
        public string small_photo_url { get; set; }
        public string photo_url { get; set; }
    }
}
