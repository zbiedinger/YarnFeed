using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yarn_Feed.Models;

namespace Yarn_Feed.ViewModels
{
    public class PostViewModel
    { 
        public Crafter Crafter { get; set; }

        public List<Post> NewPosts { get; set; }
        public List<PostPattern> PostedPatterens { get; set; }
        public List<PostProject> PostedProjects { get; set; }
        public List<PostShop> PostedShops { get; set; }
        public List<PostStash> PostedStashs { get; set; }
    }
}

