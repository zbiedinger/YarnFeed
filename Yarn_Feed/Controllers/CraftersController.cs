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
            var crafter =  _context.Crafter.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (crafter == null)
            {
                return RedirectToAction("Create");
            }

            if(crafter.LastLoggedIn < DateTime.Now.AddMinutes(-5))
            {
                await UpdateLoginTime(crafter);
            }

            //string stashId = "18830802";
            //PostStash postStash = await GetStashAPIAsync(crafter.RavelryUsername, stashId);

            //string projectNumber = "27233553";
            //PostProject PostProject = await GetProjectAPIAsync(crafter.RavelryUsername, projectNumber);

            //string patternNumber = "124400";
            //PostPattern postPattern = await GetPatternAPIAsync(patternNumber);
            //string ShopNumber = "2588";
            //PostShop postShop = await GetShopAPIAsync(ShopNumber);

            //PostViewModel postedGoodies = await GetRecentPosts();

            PostViewModel myPostsview = await GetRecentPosts(crafter);

            return View(myPostsview);
        }

        // GET: Crafters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crafter = await _context.Crafter
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crafter == null)
            {
                return NotFound();
            }

            return View(crafter);
        }

        // GET: Crafters/Create
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

        //// POST: Crafters/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Crafter crafter)
        //{
        //    if (crafter == null) 
        //    {
        //        return RedirectToAction("Index"); 
        //    }

        //    return View(crafter);
        //}

        // GET: Crafters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crafter = await _context.Crafter.FindAsync(id);
            if (crafter == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", crafter.IdentityUserId);
            return View(crafter);
        }

        // POST: Crafters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdentityUserId,RavelryUsername,RavelryPassword,RavelryId,CurrentToken,TokenUpdated,PhotoTinyURL,PhotoSmallURL,LastLoggedIn,ShowLastLoggin")] Crafter crafter)
        {
            if (id != crafter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", crafter.IdentityUserId);
            return View(crafter);
        }

        // GET: Crafters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crafter = await _context.Crafter
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crafter == null)
            {
                return NotFound();
            }

            return View(crafter);
        }

        // POST: Crafters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crafter = await _context.Crafter.FindAsync(id);
            _context.Crafter.Remove(crafter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
        public async Task<PostStash> GetStashAPIAsync(string userName, string stashId)
        {
            PostStash postStash = null;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.ravelry.com/people/" + userName + "/stash/" + stashId + ".json?include=comments"))
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
        public async Task<PostProject> GetProjectAPIAsync(string userName, string projectId)
        {
            PostProject postProject = null;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.ravelry.com/projects/" + userName + "/" + projectId + ".json?include=comments"))
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

        public static async Task<string> GetAuthorizeToken()
        {
            // Initialization.  
            string responseObj = string.Empty;

            // Posting.  
            using (var client = new HttpClient())
            {
                // Setting Base address.  
                client.BaseAddress = new Uri("http://localhost:3097/");

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

        public static async Task<string> GetInfo(string authorizeToken)
        {
            // Initialization.  
            string responseObj = string.Empty;

            // HTTP GET.  
            using (var client = new HttpClient())
            {
                // Initialization  
                string authorization = authorizeToken;

                // Setting Authorization.  
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);

                // Setting Base address.  
                client.BaseAddress = new Uri("https://localhost:44334/");

                // Setting content type.  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Initialization.  
                HttpResponseMessage response = new HttpResponseMessage();

                // HTTP GET  
                response = await client.GetAsync("api/WebApi").ConfigureAwait(false);

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
