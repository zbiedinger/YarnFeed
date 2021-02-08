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
        public int? CrafterId { get; set; }
        public Crafter Crafter { get; set; }
    }
}
