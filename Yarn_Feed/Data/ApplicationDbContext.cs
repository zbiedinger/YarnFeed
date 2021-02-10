using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Yarn_Feed.Models;

namespace Yarn_Feed.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Name = "Crafter",
                        NormalizedName = "CRAFTER"
                    }
                );
        }
        public DbSet<Yarn_Feed.Models.Admin> Admin { get; set; }
        public DbSet<Yarn_Feed.Models.Crafter> Crafter { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostPattern> PostPatterns { get; set; }
        public DbSet<PostProject> PostProjectss { get; set; }
        public DbSet<PostShop> PostShops { get; set; }
        public DbSet<PostStash> PostStashs { get; set; }

    }
}
