using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Yarn_Feed.Models
{
    public class Following
    {
        [Key]
        public int Id { get; set; }
        public bool? IsFollowing { get; set; }

        [ForeignKey("Crafter")]
        public int? CrafterId { get; set; }
        public Crafter Crafter { get; set; }

        [ForeignKey("Crafter")]
        public int? FollowingId { get; set; }
    }
}
