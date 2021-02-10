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

            //string stashId = "18830802";
            //PostStash postStash = await GetStashAPIAsync(stashId);

            //string projectNumber = "27233553";
            //PostProject PostProject = await GetProjectAPIAsync(projectNumber);

            //string patternNumber = "124400";
            //PostPattern postPattern = await GetPatternAPIAsync(patternNumber);
            //string ShopNumber = "2588";
            //PostShop postShop = await GetShopAPIAsync(ShopNumber);

            //PostViewModel postedGoodies = await GetRecentPosts();

            PostViewModel myPostsview = await GetRecentPosts(crafter);

            return View(myPostsview);
        }

        // Creates a new post based on the passed in strings
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewPost(string sharableType, string sharableId, string postBlurb)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var crafter = _context.Crafter.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            Post createpost = new Post();

            switch (sharableType)
            {
                case "Project":
                    PostProject postProject = await GetProjectAPIAsync(sharableId);
                    Post foundStash = ConvertStash(postProject);
                    createpost = foundStash;
                    createpost.TypeOfPost = sharableType;
                    break;
                case "Pattern":
                    PostPattern postPattern = await GetPatternAPIAsync(sharableId);
                    Post foundPattern = ConvertStash(postPattern);
                    createpost = foundPattern;
                    createpost.TypeOfPost = sharableType;
                    break;
                case "Shop":
                    PostShop postShop = await GetShopAPIAsync(sharableId);
                    Post foundShop = ConvertStash(postShop);
                    createpost = foundShop;
                    createpost.TypeOfPost = sharableType;

                    break;
                case "Stash":
                    PostStash postStash = await GetStashAPIAsync(sharableId);
                    Post convertedStash = ConvertStash(postStash);
                    createpost = convertedStash;
                    createpost.TypeOfPost = sharableType;
                    break;
                default:
                    createpost.TypeOfPost = "Blurb";
                    break;
            }

            createpost.PostContent = postBlurb;
            createpost.PostedByUserName = crafter.RavelryUsername;
            createpost.CrafterId = crafter.Id;
            createpost.TimePosted = DateTime.Now;
            _context.Add(createpost);
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
            List<PostPattern> postedPatterens = await GetPatternsAsync();
            List<PostProject> postedProjects = await GetProjectsAsync();
            List<PostShop> postedShops = await GetShopsAsync();
            List<PostStash> postedStashs = await GetStashAsync();
            List<Like> postedLikes = await GetLikesAsync();
            List<Comment> postedComments = await GetCommentsAsync();

            PostViewModel postedGoodies = new PostViewModel()
            {
                Crafter = crafter,
                NewPosts = newPosts,
                PostedPatterens = postedPatterens,
                PostedProjects = postedProjects,
                PostedShops = postedShops,
                PostedStashs = postedStashs,
                PostedLikes = postedLikes,
                PostedComments = postedComments
            };

            return postedGoodies;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            List<Post> posts = null;
            return posts;
        }

        public async Task<List<PostPattern>> GetPatternsAsync()
        {
            List<PostPattern> patterns = null;
            return patterns;
        }
        public async Task<List<PostProject>> GetProjectsAsync()
        {
            List<PostProject> projects = null;
            return projects;
        }
        public async Task<List<PostShop>> GetShopsAsync()
        {
            List<PostShop> shops = null;
            return shops;
        }
        public async Task<List<PostStash>> GetStashAsync()
        {
            List<PostStash> stashs = null;
            return stashs;
        }
        public async Task<List<Like>> GetLikesAsync()
        {
            List<Like> likes = null;
            return likes;
        }
        public async Task<List<Comment>> GetCommentsAsync()
        {
            List<Comment> comments = null;
            return comments;
        }

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

        public Post ConvertStash(PostProject postProject)
        {
            Post newProjectItem = new Post();

            return newProjectItem;
        }

        public Post ConvertStash(PostPattern postPattern)
        {
            Post newPatternItem = new Post();

            return newPatternItem;
        }

        public Post ConvertStash(PostShop postShop)
        {
            Post newShopItem = new Post();

            return newShopItem;
        }

        //Adds all the values from teh Stash table to Post
        public Post ConvertStash(PostStash postStash)
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

        // Method to get token NOT WORKING YET
        public static async Task<string> GetAuthorizeToken()
        {
            // Initialization.  
            string responseObj = string.Empty;

            // Posting.  
            using (var client = new HttpClient())
            {
                // Setting Base address.  
                client.BaseAddress = new Uri("http://localhost:5507/");

                // Setting content type.  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Initialization.  
                HttpResponseMessage response = new HttpResponseMessage();
                List<KeyValuePair<string, string>> allIputParams = new List<KeyValuePair<string, string>>();

                // Convert Request Params to Key Value Pair.  

                // URL Request parameters.  
                HttpContent requestParams = new FormUrlEncodedContent(allIputParams);

                // HTTP POST  
                response = await client.PostAsync("Token", requestParams).ConfigureAwait(false);

                // Verification  
                if (response.IsSuccessStatusCode)
                {
                    // Reading Response.  

                }
            }

            return responseObj;
        }
    }
}
