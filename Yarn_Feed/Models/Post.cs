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

        [ForeignKey("PostProject")]
        public int? ProjectId { get; set; }
        public PostProject PostProject { get; set; }

        [ForeignKey("PostPattern")]
        public int? PatternId { get; set; }
        public PostPattern PostPattern { get; set; }

        [ForeignKey("PostStash")]
        public int? StashId { get; set; }
        public PostStash PostStash { get; set; }

        [ForeignKey("PostShop")]
        public int? ShopId { get; set; }
        public PostShop PostShop { get; set; }

        [ForeignKey("Crafter")]
        public int CrafterId { get; set; }
        public Crafter Crafter { get; set; }
    }


    public class CurrentUser
    {
        public User1 user { get; set; }
    }

    public class User1
    {
        public int id { get; set; }
        public string username { get; set; }
        public string tiny_photo_url { get; set; }
        public string small_photo_url { get; set; }
        public string photo_url { get; set; }
        public string large_photo_url { get; set; }
    }


    public class ApiToken
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
        public string token_type { get; set; }
    }
}
