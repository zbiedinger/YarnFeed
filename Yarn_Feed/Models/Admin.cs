using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Yarn_Feed.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? RavelryId { get; set; }
        public string CurrentToken { get; set; } // Only lasts 24hr. "Offline" is used to renew the key
        public int? TokenUpdated { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public bool? ShowLastLoggin { get; set; }
    }
}
