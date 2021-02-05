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
        public int? RavelryId { get; set; }
        public string CurrentToken { get; set; } // Only lasts 24hr. "Offline" is used to renew the key
        public int? TokenUpdated { get; set; }
        public string PhotoTinyURL { get; set; }
        public string PhotoSmallURL { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public bool? ShowLastLoggin { get; set; }
    }

    public class ApiToken
    {
        public string access_token { get; set; }
        public int? expires_in { get; set; }
        public string scope { get; set; }
        public string token_type { get; set; }
    }

    public class CurrentUser
    {
        public User1 user { get; set; }
    }

    public class User1
    {
        public int? id { get; set; }
        public string username { get; set; }
        public string tiny_photo_url { get; set; }
        public string small_photo_url { get; set; }
        public string photo_url { get; set; }
        public string large_photo_url { get; set; }
    }
}
