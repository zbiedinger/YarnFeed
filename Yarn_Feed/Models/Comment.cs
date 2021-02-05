using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Yarn_Feed.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CommentedAt { get; set; }
        public bool? IsRead { get; set; }
        public string CommentContent { get; set; }
        public bool? IsFirstComment { get; set; }
        public int? ReplyToId { get; set; } //should this be a foreighKey to the same table???

        [ForeignKey("Post")]
        public int? PostId { get; set; }
        public Post Post { get; set; }

        [ForeignKey("Crafter")]
        public int? CrafterId { get; set; }
        public Crafter Crafter { get; set; }
    }
}
