﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yarn_Feed.Data;

namespace Yarn_Feed.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210210064935_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "b8e8b9b3-13e4-461f-ba69-93db755bf0b5",
                            ConcurrencyStamp = "05787bf0-13ad-444a-adfc-e08e4dd4d5e4",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "d9499a76-fbab-4d61-b749-4efb80513a9e",
                            ConcurrencyStamp = "54d08194-1370-4da6-bf19-991f13efd93b",
                            Name = "Crafter",
                            NormalizedName = "CRAFTER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Yarn_Feed.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("LastLoggedIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RavelryId")
                        .HasColumnType("int");

                    b.Property<bool?>("ShowLastLoggin")
                        .HasColumnType("bit");

                    b.Property<int?>("TokenUpdated")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Yarn_Feed.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CommentedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CrafterId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsFirstComment")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsRead")
                        .HasColumnType("bit");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("ReplyToId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CrafterId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Yarn_Feed.Models.Crafter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("LastLoggedIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhotoSmallURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoTinyURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RavelryId")
                        .HasColumnType("int");

                    b.Property<string>("RavelryPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RavelryUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ShowLastLoggin")
                        .HasColumnType("bit");

                    b.Property<int?>("TokenUpdated")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Crafter");
                });

            modelBuilder.Entity("Yarn_Feed.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<int?>("CrafterId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsLiked")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LikedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("CrafterId");

                    b.HasIndex("PostId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Yarn_Feed.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CrafterId")
                        .HasColumnType("int");

                    b.Property<string>("PostContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostedByUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimePosted")
                        .HasColumnType("datetime2");

                    b.Property<string>("TypeOfPost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("color_family_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("colorway_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("company_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("completed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("craft_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("created_at")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("currency_symbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("difficulty_average")
                        .HasColumnType("real");

                    b.Property<int?>("difficulty_count")
                        .HasColumnType("int");

                    b.Property<bool?>("downloadable")
                        .HasColumnType("bit");

                    b.Property<string>("facebook_page")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("favorites_count")
                        .HasColumnType("int");

                    b.Property<string>("fiber1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("fiber1Percent")
                        .HasColumnType("int");

                    b.Property<string>("fiber2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("fiber2Percent")
                        .HasColumnType("int");

                    b.Property<string>("fiber3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("fiber3Percent")
                        .HasColumnType("int");

                    b.Property<bool?>("free")
                        .HasColumnType("bit");

                    b.Property<string>("gauge_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("latitude")
                        .HasColumnType("real");

                    b.Property<string>("location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("longitude")
                        .HasColumnType("real");

                    b.Property<string>("made_for")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("medium_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("needle_sizes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("needle_sizes2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("needle_sizes3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("notes_html")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pattern_author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("pattern_id")
                        .HasColumnType("int");

                    b.Property<string>("pattern_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("photos_count")
                        .HasColumnType("int");

                    b.Property<bool?>("pos_online")
                        .HasColumnType("bit");

                    b.Property<float?>("price")
                        .HasColumnType("real");

                    b.Property<int?>("product_id")
                        .HasColumnType("int");

                    b.Property<int?>("progress")
                        .HasColumnType("int");

                    b.Property<int?>("project_id")
                        .HasColumnType("int");

                    b.Property<string>("project_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("project_status_changed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("projects_count")
                        .HasColumnType("int");

                    b.Property<int?>("queued_projects_count")
                        .HasColumnType("int");

                    b.Property<int?>("rating")
                        .HasColumnType("int");

                    b.Property<float?>("rating_average")
                        .HasColumnType("real");

                    b.Property<int?>("rating_count")
                        .HasColumnType("int");

                    b.Property<bool?>("ravelry_retailer")
                        .HasColumnType("bit");

                    b.Property<string>("shelved_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shop_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("shop_id")
                        .HasColumnType("int");

                    b.Property<string>("shop_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shop_permalink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sizes_available")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("started")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("stash_API_id")
                        .HasColumnType("int");

                    b.Property<bool>("stash_has_photo")
                        .HasColumnType("bit");

                    b.Property<string>("stash_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("twitter_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("updated_at")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("user_id")
                        .HasColumnType("int");

                    b.Property<int?>("yardage")
                        .HasColumnType("int");

                    b.Property<string>("yardage_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("yardage_max")
                        .HasColumnType("int");

                    b.Property<string>("yarn_weight_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("yarn_weight_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CrafterId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Yarn_Feed.Models.Admin", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("Yarn_Feed.Models.Comment", b =>
                {
                    b.HasOne("Yarn_Feed.Models.Crafter", "Crafter")
                        .WithMany()
                        .HasForeignKey("CrafterId");

                    b.HasOne("Yarn_Feed.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("Yarn_Feed.Models.Crafter", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("Yarn_Feed.Models.Like", b =>
                {
                    b.HasOne("Yarn_Feed.Models.Comment", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId");

                    b.HasOne("Yarn_Feed.Models.Crafter", "Crafter")
                        .WithMany()
                        .HasForeignKey("CrafterId");

                    b.HasOne("Yarn_Feed.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("Yarn_Feed.Models.Post", b =>
                {
                    b.HasOne("Yarn_Feed.Models.Crafter", "Crafter")
                        .WithMany()
                        .HasForeignKey("CrafterId");
                });
#pragma warning restore 612, 618
        }
    }
}
