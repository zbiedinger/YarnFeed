using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Yarn_Feed.Models
{
    public class Crafter
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public string RavelryUsername { get; set; }
        public string RavelryPassword { get; set; }
        public int RavelryId { get; set; }
        public string CurrentToken { get; set; } // Only lasts 24hr. "Offline" is used to renew the key
        public DateTime TokenUpdated { get; set; }
        public string PhotoTinyURL { get; set; }
        public string PhotoSmallURL { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public bool ShowLastLoggin { get; set; }
    }
}
