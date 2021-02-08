using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        //string currentToken = "mPigXpN5CR3zjHsfeKR3i4-LaBG4u1kgO10vW62kZdU.zz-iaS3Q5lH9FIghl4VGNN6LV3dqfyfUES8DzaHJA18";
        //string authURL = "https://www.ravelry.com/oauth2/auth";
        //string accessTokenURL = "https://www.ravelry.com/oauth2/token";
        //string scope = "offline";
        //string clientId = "4fd8d5f73981b822d5c51a634e441d28";
        //string clientSecret = "QPNGys9Ld1Y4T/gtW5c/pHQXnzNiK0iifW39IyDD";

        //CurrentUser currentUser = null;
        string errorString;


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
                UpdateLoginTime();
            }
            

            string ShopNumber = "2588";

            PostShop postShop = await GetShopAPIAsync(ShopNumber);

            PostViewModel postedGoodies = await GetRecentPosts();

            return View(crafter);
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

        //SHould updatet hte lastloggin time every time they are braught to the index page.
        //looping issue
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

        public async Task<PostViewModel> GetRecentPosts()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var crafter = _context.Crafter.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            List<Post> newPosts = GetPostsAsync();
            List<PostPattern> postedPatterens = GetPatternsAsync();
            List<PostProject> postedProjects = GetProjectsAsync();
            List<PostShop> postedShops = GetShopsAsync();
            List<PostStash> postedStashs = GetStashAsync();
            List<Like> postedLikes = GetLikesAsync();
            List<Comment> postedComments = GetCommentsAsync();

            PostViewModel postedGoodies = new PostViewModel()
            {
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

        public List<Post> GetPostsAsync()
        {
            List<Post> posts = null;
            return posts;
        }

        public List<PostPattern> GetPatternsAsync()
        {
            List<PostPattern> patterns = null;
            return patterns;
        }
        public List<PostProject> GetProjectsAsync()
        {
            List<PostProject> projects = null;
            return projects;
        }
        public List<PostShop> GetShopsAsync()
        {
            List<PostShop> shops = null;
            return shops;
        }
        public List<PostStash> GetStashAsync()
        {
            List<PostStash> stashs = null;
            return stashs;
        }
        public List<Like> GetLikesAsync()
        {
            List<Like> likes = null;
            return likes;
        }
        public List<Comment> GetCommentsAsync()
        {
            List<Comment> comments = null;
            return comments;
        }

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
                errorString = $"There was a error getting our Shop: {ex.Message}";
            }
            return currentUser;
        }

        public async Task<PostShop> GetShopAPIAsync(string shopId)
        {
            PostShop shopFound = null;
            try
            {
                using (var httpclient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("get"), "https://api.ravelry.com/shops/" + "2588" + ".json?include=brands+ad"))
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
                errorString = $"There was a error getting our Shop: {ex.Message}";
            }

            return shopFound;
        }
    }
}
