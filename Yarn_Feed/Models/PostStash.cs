using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yarn_Feed.Models
{
    public class PostStash
    {
        [Key]
        public int Id { get; set; }
        public Stash stash { get; set; }
        public User user { get; set; }
    }

    public class Stash
    {
        public string created_at { get; set; }
        public string dye_lot { get; set; }
        public int? favorites_count { get; set; }
        public bool? handspun { get; set; }
        public bool? has_photo { get; set; }
        public int? id { get; set; }
        public string updated_at { get; set; }
        public int? user_id { get; set; }
        public string name { get; set; }
        public string colorway_name { get; set; }
        public string color_family_name { get; set; }
        public string yarn_weight_name { get; set; }
        public string long_yarn_weight_name { get; set; }
        public string personal_yarn_weight { get; set; }
        public Photo[] photos { get; set; }
        public Yarn yarn { get; set; }
        public Pack[] packs { get; set; }
        public User user { get; set; }
    }

    public class Yarn
    {
        public bool discontinued { get; set; }
        public int? gauge_divisor { get; set; }
        public int? grams { get; set; }
        public int? id { get; set; }
        public string name { get; set; }
        public string permalink { get; set; }
        public float? rating_average { get; set; }
        public int? rating_count { get; set; }
        public int? rating_total { get; set; }
        public string texture { get; set; }
        public int? yardage { get; set; }
        public string notes_html { get; set; }
        public Yarn_Company yarn_company { get; set; }
        public Yarn_Fibers[] yarn_fibers { get; set; }
        public Photo[] photos { get; set; }
    }

    public class Yarn_Company
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string permalink { get; set; }
        public string url { get; set; }
        public int? yarns_count { get; set; }
    }

    public class Yarn_Fibers
    {
        public int? id { get; set; }
        public int? percentage { get; set; }
        public Fiber_Type fiber_type { get; set; }
    }

    public class Fiber_Type
    {
        public bool? animal_fiber { get; set; }
        public int? id { get; set; }
        public string name { get; set; }
        public bool? synthetic { get; set; }
        public bool? vegetable_fiber { get; set; }
    }
}
