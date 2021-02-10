using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestClient.Net;
using Yarn_Feed.Data;
using Yarn_Feed.Models;
using Yarn_Feed.ViewModels;

namespace Yarn_Feed.Controllers
{
    public class CraftersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CraftersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Crafters
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var crafter = _context.Crafter.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (crafter == null)
            {
                return RedirectToAction("Create");
            }

            if (crafter.LastLoggedIn < DateTime.Now.AddMinutes(-5))
            {
                await UpdateLoginTime(crafter);
            }

            PostViewModel myPostsview = await GetRecentPosts(crafter);

            return View(myPostsview);
        }

        // Creates a new post based on the passed in strings
        public async Task<IActionResult> NewPost(string sharableType, string sharableId, string postBlurb)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var crafter = _context.Crafter.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            Post createpost = new Post();

            switch (sharableType)
            {
                case "Project":
                    PostProject postProject = await GetProjectAPIAsync(sharableId);
                    Post foundStash = ConvertPost(postProject);
                    createpost = foundStash;
                    createpost.TypeOfPost = sharableType;
                    break;
                case "Pattern":
                    PostPattern postPattern = await GetPatternAPIAsync(sharableId);
                    Post foundPattern = ConvertPost(postPattern);
                    createpost = foundPattern;
                    createpost.TypeOfPost = sharableType;
                    break;
                case "Shop":
                    PostShop postShop = await GetShopAPIAsync(sharableId);
                    Post foundShop = ConvertPost(postShop);
                    createpost = foundShop;
                    createpost.TypeOfPost = sharableType;
                    break;
                case "Stash":
                    PostStash postStash = await GetStashAPIAsync(sharableId);
                    Post convertedStash = ConvertPost(postStash);
                    createpost = convertedStash;
                    createpost.TypeOfPost = sharableType;
                    break;
                default:
                    createpost.TypeOfPost = "Blurb";
                    break;
            }

            createpost.IsRepost = false;
            createpost.PostContent = postBlurb;
            createpost.PostedByUserName = crafter.RavelryUsername;
            createpost.CrafterId = crafter.Id;
            createpost.PostersPhoto = crafter.PhotoSmallURL;
            createpost.TimePosted = DateTime.Now;
            _context.Add(createpost);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Repost a already share post
        public async Task<IActionResult> RePost(int postId, string postBlurb)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var crafter = _context.Crafter.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            Post oldPost = _context.Posts.Where(c => c.Id == postId).SingleOrDefault();
            Post createpost = new Post();

            createpost = oldPost;
            createpost.IsRepost = true;
            createpost.OriginallyPosedBy = oldPost.PostedByUserName;
            createpost.RepostBlurb = oldPost.PostContent;
            createpost.PostContent = postBlurb;
            createpost.PostedByUserName = crafter.RavelryUsername;
            createpost.CrafterId = crafter.Id;
            createpost.PostersPhoto = crafter.PhotoSmallURL;
            createpost.TimePosted = DateTime.Now;

            _context.Add(createpost);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Creates a new entry in the likes table for a post
        public async Task<IActionResult> LikePost(int postId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var crafter = _context.Crafter.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            Post likedPost = _context.Posts.Where(c => c.Id == postId).SingleOrDefault();
            Like newLike = new Like();

            newLike.PostId = likedPost.Id;
            newLike.CrafterId = crafter.Id;
            newLike.IsLiked = true;
            newLike.LikedAt = DateTime.Now;

            _context.Update(newLike);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Creates a new entry in the likes table for a comment
        public async Task<IActionResult> LikeComment(int commentId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var crafter = _context.Crafter.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            Comment likedComment = _context.Comments.Where(c => c.Id == commentId).SingleOrDefault();
            Like newLike = new Like();

            newLike.CommentId = likedComment.Id;
            newLike.CrafterId = crafter.Id;
            newLike.IsLiked = true;
            newLike.LikedAt = DateTime.Now;

            _context.Update(newLike);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Creates a new entry in the comments table for a post
        public async Task<IActionResult> AddComment(int postId, string postBlurb)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var crafter = _context.Crafter.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            Post commentedPost = _context.Posts.Where(c => c.Id == postId).SingleOrDefault();
            Comment newComment = new Comment();

            newComment.PostId = commentedPost.Id;
            newComment.CrafterId = crafter.Id;
            newComment.IsRead = false;
            newComment.IsFirstComment = true;
            newComment.CommentContent = postBlurb;
            newComment.CommentedAt = DateTime.Now;


            _context.Update(newComment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Creates a new Crafter from the account found with API call
        public async Task<IActionResult> Create()
        {
            CurrentUser currentUser = await GetCurrentUserAPIAsync();

            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Crafter crafterCreate = new Crafter();
                crafterCreate.IdentityUserId = userId;
                crafterCreate.RavelryId = currentUser.user.id;
                crafterCreate.RavelryUsername = currentUser.user.username;
                crafterCreate.PhotoTinyURL = currentUser.user.tiny_photo_url;
                crafterCreate.PhotoSmallURL = currentUser.user.small_photo_url;
                crafterCreate.CurrentToken = ApiKeys.GetCurrentToken();
                crafterCreate.TokenUpdated = 3599;
                crafterCreate.ShowLastLoggin = true;
                crafterCreate.LastLoggedIn = DateTime.Now;

                _context.Add(crafterCreate);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //if here, then something went wrong
            return View();
        }

        private bool CrafterExists(int id)
        {
            return _context.Crafter.Any(e => e.Id == id);
        }

        // Updates the lastloggin time
        public async Task<IActionResult> UpdateLoginTime(Crafter crafter)
        {
            try
            {
                crafter.LastLoggedIn = DateTime.Now;
                _context.Update(crafter);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrafterExists(crafter.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<PostViewModel> GetRecentPosts(Crafter crafter)
        {
            List<Post> newPosts = await GetPostsAsync();
            List<Like> postedLikes = await GetLikesAsync();
            List<Comment> postedComments = await GetCommentsAsync();

            PostViewModel postedGoodies = new PostViewModel()
            {
                Crafter = crafter,
                NewPosts = newPosts,
                PostedLikes = postedLikes,
                PostedComments = postedComments
            };

            return postedGoodies;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            List<Post> posts = _context.Posts.Where(c => c.Id > 0 ).ToList();

            return posts.OrderByDescending(c => c.TimePosted).ToList();
        }

        public async Task<List<Like>> GetLikesAsync()
        {
            List<Like> likes = _context.Likes.Where(c => c.Id > 0).ToList();
            return likes;
        }

        public async Task<List<Comment>> GetCommentsAsync()
        {
            List<Comment> comments = _context.Comments.Where(c => c.Id > 0).ToList();
            return comments;
        }


        // These methods are the API calls
        // Gets a current signedin user from Ravelry API using Oauth 2.0
        public async Task<CurrentUser> GetCurrentUserAPIAsync()
        {
            CurrentUser currentUser = null;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.ravelry.com/current_user.json"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + ApiKeys.GetCurrentToken());

                        var response = await httpClient.SendAsync(request);
                        string result = await response.Content.ReadAsStringAsync();
                        currentUser = JsonConvert.DeserializeObject<CurrentUser>(result);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorString = $"There was a error getting our Shop: {ex.Message}";
            }
            return currentUser;
        }

        // Gets a stash item from Ravelry API from passed in ID and username using Oauth 2.0
        public async Task<PostStash> GetStashAPIAsync(string stashId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var crafter = _context.Crafter.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            PostStash postStash = null;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.ravelry.com/people/" + crafter.RavelryUsername + "/stash/" + stashId + ".json?include=comments"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + ApiKeys.GetCurrentToken());

                        var response = await httpClient.SendAsync(request);
                        string result = await response.Content.ReadAsStringAsync();
                        postStash = JsonConvert.DeserializeObject<PostStash>(result);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorString = $"There was a error getting our Shop: {ex.Message}";
            }
            return postStash;
        }

        // Gets a project from Ravelry API from passed in ID and username using Oauth 2.0
        public async Task<PostProject> GetProjectAPIAsync(string projectId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var crafter = _context.Crafter.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            PostProject postProject = null;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.ravelry.com/projects/" + crafter.RavelryUsername + "/" + projectId + ".json?include=comments"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + ApiKeys.GetCurrentToken());

                        var response = await httpClient.SendAsync(request);
                        string result = await response.Content.ReadAsStringAsync();
                        postProject = JsonConvert.DeserializeObject<PostProject>(result);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorString = $"There was a error getting our Shop: {ex.Message}";
            }
            return postProject;
        }

        // Gets a shop from Ravelry API from passed in ID using Basic Oauth
        public async Task<PostShop> GetShopAPIAsync(string shopId)
        {
            PostShop shopFound = null;
            try
            {
                using (var httpclient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("get"), "https://api.ravelry.com/shops/" + shopId + ".json?include=brands+ad"))
                    {
                        var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(ApiKeys.GetUsername() + ":" + ApiKeys.GetPassword()));
                        request.Headers.TryAddWithoutValidation("authorization", $"basic {base64authorization}");

                        var response = await httpclient.SendAsync(request);
                        string result = await response.Content.ReadAsStringAsync();
                        shopFound = JsonConvert.DeserializeObject<PostShop>(result);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorString = $"There was a error getting our Shop: {ex.Message}";
            }

            return shopFound;
        }

        // Gets a pattern from Ravelry API from passed in ID using Basic Oauth
        public async Task<PostPattern> GetPatternAPIAsync(string PatternId)
        {
            PostPattern patternFound = null;
            try
            {
                using (var httpclient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("get"), "https://api.ravelry.com/patterns/" + PatternId + ".json"))
                    {
                        var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(ApiKeys.GetUsername() + ":" + ApiKeys.GetPassword()));
                        request.Headers.TryAddWithoutValidation("authorization", $"basic {base64authorization}");

                        var response = await httpclient.SendAsync(request);
                        string result = await response.Content.ReadAsStringAsync();
                        patternFound = JsonConvert.DeserializeObject<PostPattern>(result);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorString = $"There was a error getting our Shop: {ex.Message}";
            }

            return patternFound;
        }


        // These methods transfers data from PostType to Post
        //Adds all the values from the project table to Post
        public Post ConvertPost(PostProject postProject)
        {
            Post newProjectItem = new Post();

            newProjectItem.completed = postProject.project.completed;
            newProjectItem.created_at = postProject.project.created_at;
            newProjectItem.project_id = postProject.project.id;
            newProjectItem.made_for = postProject.project.made_for;
            newProjectItem.project_name = postProject.project.name;
            newProjectItem.pattern_id = postProject.project.pattern_id;
            newProjectItem.progress = postProject.project.progress;
            newProjectItem.project_status_changed = postProject.project.project_status_changed;
            newProjectItem.rating = postProject.project.rating;
            newProjectItem.size = postProject.project.size;
            newProjectItem.started = postProject.project.started;
            newProjectItem.updated_at = postProject.project.updated_at;
            newProjectItem.pattern_name = postProject.project.pattern_name;
            newProjectItem.craft_name = postProject.project.craft_name;
            newProjectItem.status_name = postProject.project.status_name;
            newProjectItem.photos_count = postProject.project.photos_count;

            if (postProject.project.photos_count > 0)
            {
                newProjectItem.shelved_url = postProject.project.photos[0].shelved_url;
                newProjectItem.medium_url = postProject.project.photos[0].medium_url;
            }
            if (postProject.project.needle_sizes.Length >= 1)
            {
                newProjectItem.needle_sizes = postProject.project.needle_sizes[0].name;
            }
            if (postProject.project.needle_sizes.Length >= 2)
            {
                newProjectItem.needle_sizes2 = postProject.project.needle_sizes[1].name;
            }
            if (postProject.project.needle_sizes.Length >= 3)
            {
                newProjectItem.needle_sizes3 = postProject.project.needle_sizes[2].name;
            }

            return newProjectItem;
        }

        //Adds all the values from the pattern table to Post
        public Post ConvertPost(PostPattern postPattern)
        {
            Post newPatternItem = new Post();

            newPatternItem.currency = postPattern.pattern.currency;
            newPatternItem.difficulty_average = postPattern.pattern.difficulty_average;
            newPatternItem.difficulty_count = postPattern.pattern.difficulty_count;
            newPatternItem.downloadable = postPattern.pattern.downloadable;
            newPatternItem.favorites_count = postPattern.pattern.favorites_count;
            newPatternItem.free = postPattern.pattern.free;
            newPatternItem.pattern_id = postPattern.pattern.id;
            newPatternItem.pattern_name = postPattern.pattern.name;
            newPatternItem.price = postPattern.pattern.price;
            newPatternItem.projects_count = postPattern.pattern.projects_count;
            newPatternItem.queued_projects_count = postPattern.pattern.queued_projects_count;
            newPatternItem.rating_average = postPattern.pattern.rating_average;
            newPatternItem.rating_count = postPattern.pattern.rating_count;
            newPatternItem.yardage = postPattern.pattern.yardage;
            newPatternItem.yardage_max = postPattern.pattern.yardage_max;
            newPatternItem.sizes_available = postPattern.pattern.sizes_available;
            newPatternItem.product_id = postPattern.pattern.product_id;
            newPatternItem.currency_symbol = postPattern.pattern.currency_symbol;
            newPatternItem.gauge_description = postPattern.pattern.gauge_description;
            newPatternItem.yarn_weight_description = postPattern.pattern.yarn_weight_description;
            newPatternItem.yardage_description = postPattern.pattern.yardage_description;
            newPatternItem.pattern_author = postPattern.pattern.pattern_author.name;

            if (postPattern.pattern.photos.Length > 0)
            {
                newPatternItem.shelved_url = postPattern.pattern.photos[0].shelved_url;
                newPatternItem.medium_url = postPattern.pattern.photos[0].medium_url;
            }
            if (postPattern.pattern.pattern_needle_sizes.Length >= 1)
            {
                newPatternItem.needle_sizes = postPattern.pattern.pattern_needle_sizes[0].name;
            }
            if (postPattern.pattern.pattern_needle_sizes.Length >= 2)
            {
                newPatternItem.needle_sizes2 = postPattern.pattern.pattern_needle_sizes[1].name;
            }
            if (postPattern.pattern.pattern_needle_sizes.Length >= 3)
            {
                newPatternItem.needle_sizes3 = postPattern.pattern.pattern_needle_sizes[2].name;
            }

            return newPatternItem;
        }

        //Adds all the values from the Shop table to Post
        public Post ConvertPost(PostShop postShop)
        {
            Post newShopItem = new Post();

            newShopItem.Address = postShop.Shop.Address;
            newShopItem.City = postShop.Shop.City;
            newShopItem.facebook_page = postShop.Shop.facebook_page;
            newShopItem.shop_id = postShop.Shop.id;
            newShopItem.latitude = postShop.Shop.latitude;
            newShopItem.location = postShop.Shop.location;
            newShopItem.longitude = postShop.Shop.longitude;
            newShopItem.shop_name = postShop.Shop.name;
            newShopItem.shop_permalink = postShop.Shop.permalink;
            newShopItem.phone = postShop.Shop.phone;
            newShopItem.pos_online = postShop.Shop.pos_online;
            newShopItem.ravelry_retailer = postShop.Shop.ravelry_retailer;
            newShopItem.shop_email = postShop.Shop.shop_email;
            newShopItem.twitter_id = postShop.Shop.twitter_id;
            newShopItem.url = postShop.Shop.url;
            newShopItem.zip = postShop.Shop.zip;
            newShopItem.notes_html = postShop.Shop.notes_html;
            newShopItem.country = postShop.Shop.country.name;
            newShopItem.state = postShop.Shop.state.name;

            return newShopItem;
        }

        //Adds all the values from the Stash table to Post
        public Post ConvertPost(PostStash postStash)
        {
            Post newStashItem = new Post();

            newStashItem.stash_has_photo = postStash.stash.has_photo;
            newStashItem.user_id = postStash.stash.user_id;
            newStashItem.stash_name = postStash.stash.name;
            newStashItem.colorway_name = postStash.stash.colorway_name;
            newStashItem.color_family_name = postStash.stash.color_family_name;
            newStashItem.yarn_weight_name = postStash.stash.long_yarn_weight_name;
            newStashItem.company_name = postStash.stash.yarn.yarn_company.name;
            if (postStash.stash.has_photo)
            {
                newStashItem.shelved_url = postStash.stash.photos[0].shelved_url;
                newStashItem.medium_url = postStash.stash.photos[0].medium_url;
            }
            if (postStash.stash.yarn.yarn_fibers.Length >= 1)
            {
                newStashItem.fiber1Percent = postStash.stash.yarn.yarn_fibers[0].percentage;
                newStashItem.fiber1 = postStash.stash.yarn.yarn_fibers[0].fiber_type.name;
            }
            if (postStash.stash.yarn.yarn_fibers.Length >= 2)
            {
                newStashItem.fiber2Percent = postStash.stash.yarn.yarn_fibers[1].percentage;
                newStashItem.fiber2 = postStash.stash.yarn.yarn_fibers[1].fiber_type.name;
            }
            if (postStash.stash.yarn.yarn_fibers.Length >= 3)
            {
                newStashItem.fiber3Percent = postStash.stash.yarn.yarn_fibers[2].percentage;
                newStashItem.fiber3 = postStash.stash.yarn.yarn_fibers[2].fiber_type.name;
            }

            return newStashItem;
        }

    //// Method to get token NOT WORKING YET
    //public static async Task<string> GetAuthorizeToken()
    //{
    //    // Initialization.  
    //    string responseObj = string.Empty;

    //    // Posting.  
    //    using (var client = new HttpClient())
    //    {
    //        // Setting Base address.  
    //        client.BaseAddress = new Uri("http://localhost:5507/");

    //        // Setting content type.  
    //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    //        // Initialization.  
    //        HttpResponseMessage response = new HttpResponseMessage();
    //        List<KeyValuePair<string, string>> allIputParams = new List<KeyValuePair<string, string>>();

    //        // Convert Request Params to Key Value Pair.  

    //        // URL Request parameters.  
    //        HttpContent requestParams = new FormUrlEncodedContent(allIputParams);

    //        // HTTP POST  
    //        response = await client.PostAsync("Token", requestParams).ConfigureAwait(false);

    //        // Verification  
    //        if (response.IsSuccessStatusCode)
    //        {
    //            // Reading Response.  

    //        }
    //    }

    //    return responseObj;
    //}
    }
}
