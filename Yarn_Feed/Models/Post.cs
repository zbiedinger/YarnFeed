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
        public int ProjectId { get; set; }

        public int PatternId { get; set; }

        public int ShopId { get; set; }

        public int StashId { get; set; }


        [ForeignKey("Crafter")]
        public int CrafterId { get; set; }
        public Crafter Crafter { get; set; }
    }
}
