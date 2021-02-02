using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yarn_Feed.Models
{

    public class PostPattern
    {
        public Pattern pattern { get; set; }
    }

    public class Pattern
    {
        public int comments_count { get; set; }
        public string created_at { get; set; }
        public string currency { get; set; }
        public float difficulty_average { get; set; }
        public int difficulty_count { get; set; }
        public bool downloadable { get; set; }
        public int favorites_count { get; set; }
        public bool free { get; set; }
        public float gauge { get; set; }
        public int gauge_divisor { get; set; }
        public string gauge_pattern { get; set; }
        public string generally_available { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string pdf_url { get; set; }
        public string permalink { get; set; }
        public float price { get; set; }
        public int projects_count { get; set; }
        public string published { get; set; }
        public int queued_projects_count { get; set; }
        public float rating_average { get; set; }
        public int rating_count { get; set; }
        public float row_gauge { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public int yardage { get; set; }
        public int yardage_max { get; set; }
        public object personal_attributes { get; set; }
        public string sizes_available { get; set; }
        public int product_id { get; set; }
        public string currency_symbol { get; set; }
        public bool ravelry_download { get; set; }
        public Download_Location download_location { get; set; }
        public bool pdf_in_library { get; set; }
        public object volumes_in_library { get; set; }
        public string gauge_description { get; set; }
        public string yarn_weight_description { get; set; }
        public string yardage_description { get; set; }
        public Pattern_Needle_Sizes[] pattern_needle_sizes { get; set; }
        public string notes_html { get; set; }
        public string notes { get; set; }
        public Pack[] packs { get; set; }
        public Printing[] printings { get; set; }
        public Yarn_Weight yarn_weight { get; set; }
        public Craft craft { get; set; }
        public Pattern_Categories[] pattern_categories { get; set; }
        public Pattern_Attributes[] pattern_attributes { get; set; }
        public Pattern_Author pattern_author { get; set; }
        public Photo[] photos { get; set; }
        public Pattern_Type pattern_type { get; set; }
    }

    public class Download_Location
    {
        public string type { get; set; }
        public bool free { get; set; }
        public string url { get; set; }
    }

    public class Yarn_Weight
    {
        public object crochet_gauge { get; set; }
        public int id { get; set; }
        public string knit_gauge { get; set; }
        public object max_gauge { get; set; }
        public object min_gauge { get; set; }
        public string name { get; set; }
        public string ply { get; set; }
        public string wpi { get; set; }
    }

    public class Craft
    {
        public int id { get; set; }
        public string name { get; set; }
        public string permalink { get; set; }
    }

    public class Pattern_Author
    {
        public int crochet_pattern_count { get; set; }
        public int favorites_count { get; set; }
        public int id { get; set; }
        public int knitting_pattern_count { get; set; }
        public string name { get; set; }
        public int patterns_count { get; set; }
        public string permalink { get; set; }
        public string notes { get; set; }
        public string notes_html { get; set; }
        public User[] users { get; set; }
    }

    public class User
    {
        public string fave_colors { get; set; }
        public string fave_curse { get; set; }
        public string first_name { get; set; }
        public int id { get; set; }
        public string location { get; set; }
        public string username { get; set; }
        public string tiny_photo_url { get; set; }
        public string small_photo_url { get; set; }
        public string photo_url { get; set; }
        public string large_photo_url { get; set; }
        public string about_me { get; set; }
        public string about_me_html { get; set; }
        public Pattern_Author1 pattern_author { get; set; }
        public User_Sites[] user_sites { get; set; }
    }

    public class Pattern_Author1
    {
        public int favorites_count { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int patterns_count { get; set; }
        public string permalink { get; set; }
    }

    public class User_Sites
    {
        public int id { get; set; }
        public string username { get; set; }
        public string url { get; set; }
        public Social_Site social_site { get; set; }
    }

    public class Social_Site
    {
        public int id { get; set; }
        public string name { get; set; }
        public string favicon_url { get; set; }
        public bool active { get; set; }
    }

    public class Pattern_Type
    {
        public bool clothing { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string permalink { get; set; }
    }

    public class Pattern_Needle_Sizes
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

    public class Pack
    {
        public int id { get; set; }
        public object primary_pack_id { get; set; }
        public object project_id { get; set; }
        public object skeins { get; set; }
        public object stash_id { get; set; }
        public object total_grams { get; set; }
        public object total_meters { get; set; }
        public object total_ounces { get; set; }
        public object total_yards { get; set; }
        public int yarn_id { get; set; }
        public string yarn_name { get; set; }
        public Yarn_Weight1 yarn_weight { get; set; }
        public object colorway { get; set; }
        public object shop_name { get; set; }
        public Yarn yarn { get; set; }
        public object quantity_description { get; set; }
        public object personal_name { get; set; }
        public object dye_lot { get; set; }
        public object color_family_id { get; set; }
        public object grams_per_skein { get; set; }
        public object yards_per_skein { get; set; }
        public object meters_per_skein { get; set; }
        public object ounces_per_skein { get; set; }
        public bool prefer_metric_weight { get; set; }
        public bool prefer_metric_length { get; set; }
        public object shop_id { get; set; }
        public object thread_size { get; set; }
    }

    public class Yarn_Weight1
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

    public class Printing
    {
        public bool primary_source { get; set; }
        public Pattern_Source pattern_source { get; set; }
    }

    public class Pattern_Source
    {
        public object amazon_rating { get; set; }
        public object amazon_url { get; set; }
        public string author { get; set; }
        public int id { get; set; }
        public object list_price { get; set; }
        public string name { get; set; }
        public bool out_of_print { get; set; }
        public int patterns_count { get; set; }
        public string permalink { get; set; }
        public object price { get; set; }
        public object shelf_image_path { get; set; }
        public string url { get; set; }
    }

    public class Pattern_Categories
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
        public Parent1 parent { get; set; }
    }

    public class Parent1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string permalink { get; set; }
        public Parent2 parent { get; set; }
    }

    public class Parent2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string permalink { get; set; }
    }

    public class Pattern_Attributes
    {
        public int id { get; set; }
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
}
