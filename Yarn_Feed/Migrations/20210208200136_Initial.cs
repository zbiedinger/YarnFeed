using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yarn_Feed.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Fiber_Type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    animal_fiber = table.Column<bool>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    synthetic = table.Column<bool>(nullable: true),
                    vegetable_fiber = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fiber_Type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pattern_Author",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    crochet_pattern_count = table.Column<int>(nullable: true),
                    favorites_count = table.Column<int>(nullable: true),
                    knitting_pattern_count = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    patterns_count = table.Column<int>(nullable: true),
                    permalink = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    notes_html = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pattern_Author", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pattern_Type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clothing = table.Column<bool>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    permalink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pattern_Type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    completed = table.Column<string>(nullable: true),
                    craft_id = table.Column<int>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    favorites_count = table.Column<int>(nullable: true),
                    made_for = table.Column<string>(nullable: true),
                    made_for_user_id = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    pattern_id = table.Column<int>(nullable: true),
                    permalink = table.Column<string>(nullable: true),
                    progress = table.Column<int>(nullable: true),
                    project_status_changed = table.Column<string>(nullable: true),
                    project_status_id = table.Column<int>(nullable: true),
                    rating = table.Column<int>(nullable: true),
                    size = table.Column<string>(nullable: true),
                    started = table.Column<string>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    user_id = table.Column<int>(nullable: true),
                    pattern_name = table.Column<string>(nullable: true),
                    craft_name = table.Column<string>(nullable: true),
                    status_name = table.Column<string>(nullable: true),
                    notes_html = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    photos_count = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fave_colors = table.Column<string>(nullable: true),
                    fave_curse = table.Column<string>(nullable: true),
                    first_name = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    tiny_photo_url = table.Column<string>(nullable: true),
                    small_photo_url = table.Column<string>(nullable: true),
                    photo_url = table.Column<string>(nullable: true),
                    large_photo_url = table.Column<string>(nullable: true),
                    about_me = table.Column<string>(nullable: true),
                    about_me_html = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Yarn_Company",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    permalink = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    yarns_count = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yarn_Company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    RavelryId = table.Column<int>(nullable: true),
                    CurrentToken = table.Column<string>(nullable: true),
                    TokenUpdated = table.Column<int>(nullable: true),
                    LastLoggedIn = table.Column<DateTime>(nullable: true),
                    ShowLastLoggin = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crafter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(nullable: true),
                    RavelryUsername = table.Column<string>(nullable: true),
                    RavelryPassword = table.Column<string>(nullable: true),
                    RavelryId = table.Column<int>(nullable: true),
                    CurrentToken = table.Column<string>(nullable: true),
                    TokenUpdated = table.Column<int>(nullable: true),
                    PhotoTinyURL = table.Column<string>(nullable: true),
                    PhotoSmallURL = table.Column<string>(nullable: true),
                    LastLoggedIn = table.Column<DateTime>(nullable: true),
                    ShowLastLoggin = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crafter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crafter_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pattern",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<string>(nullable: true),
                    currency = table.Column<string>(nullable: true),
                    difficulty_average = table.Column<float>(nullable: true),
                    difficulty_count = table.Column<int>(nullable: true),
                    downloadable = table.Column<bool>(nullable: true),
                    favorites_count = table.Column<int>(nullable: true),
                    free = table.Column<bool>(nullable: true),
                    gauge = table.Column<float>(nullable: true),
                    gauge_divisor = table.Column<int>(nullable: true),
                    gauge_pattern = table.Column<string>(nullable: true),
                    generally_available = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    pdf_url = table.Column<string>(nullable: true),
                    permalink = table.Column<string>(nullable: true),
                    price = table.Column<float>(nullable: true),
                    projects_count = table.Column<int>(nullable: true),
                    published = table.Column<string>(nullable: true),
                    queued_projects_count = table.Column<int>(nullable: true),
                    rating_average = table.Column<float>(nullable: true),
                    rating_count = table.Column<int>(nullable: true),
                    row_gauge = table.Column<float>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    yardage = table.Column<int>(nullable: true),
                    yardage_max = table.Column<int>(nullable: true),
                    sizes_available = table.Column<string>(nullable: true),
                    product_id = table.Column<int>(nullable: true),
                    currency_symbol = table.Column<string>(nullable: true),
                    ravelry_download = table.Column<bool>(nullable: true),
                    pdf_in_library = table.Column<bool>(nullable: true),
                    gauge_description = table.Column<string>(nullable: true),
                    yarn_weight_description = table.Column<string>(nullable: true),
                    yardage_description = table.Column<string>(nullable: true),
                    notes_html = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    pattern_authorid = table.Column<int>(nullable: true),
                    pattern_typeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pattern", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pattern_Pattern_Author_pattern_authorid",
                        column: x => x.pattern_authorid,
                        principalTable: "Pattern_Author",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pattern_Pattern_Type_pattern_typeid",
                        column: x => x.pattern_typeid,
                        principalTable: "Pattern_Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Needle_Sizes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    us = table.Column<string>(nullable: true),
                    metric = table.Column<float>(nullable: true),
                    crochet = table.Column<bool>(nullable: true),
                    knitting = table.Column<bool>(nullable: true),
                    hook = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    pretty_metric = table.Column<string>(nullable: true),
                    Projectid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Needle_Sizes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Needle_Sizes_Project_Projectid",
                        column: x => x.Projectid,
                        principalTable: "Project",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostProjectss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostProjectss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostProjectss_Project_projectid",
                        column: x => x.projectid,
                        principalTable: "Project",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    closed = table.Column<bool>(nullable: true),
                    facebook_page = table.Column<string>(nullable: true),
                    free_wifi = table.Column<bool>(nullable: true),
                    latitude = table.Column<float>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    longitude = table.Column<float>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    permalink = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    pos_online = table.Column<bool>(nullable: true),
                    ravelry_retailer = table.Column<bool>(nullable: true),
                    seating = table.Column<bool>(nullable: true),
                    shop_email = table.Column<string>(nullable: true),
                    twitter_id = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    zip = table.Column<string>(nullable: true),
                    notes_html = table.Column<string>(nullable: true),
                    countryid = table.Column<int>(nullable: true),
                    stateid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.id);
                    table.ForeignKey(
                        name: "FK_Shop_Country_countryid",
                        column: x => x.countryid,
                        principalTable: "Country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shop_State_stateid",
                        column: x => x.stateid,
                        principalTable: "State",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Yarn",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discontinued = table.Column<bool>(nullable: false),
                    gauge_divisor = table.Column<int>(nullable: true),
                    grams = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    permalink = table.Column<string>(nullable: true),
                    rating_average = table.Column<float>(nullable: true),
                    rating_count = table.Column<int>(nullable: true),
                    rating_total = table.Column<int>(nullable: true),
                    texture = table.Column<string>(nullable: true),
                    yardage = table.Column<int>(nullable: true),
                    notes_html = table.Column<string>(nullable: true),
                    yarn_companyid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yarn", x => x.id);
                    table.ForeignKey(
                        name: "FK_Yarn_Yarn_Company_yarn_companyid",
                        column: x => x.yarn_companyid,
                        principalTable: "Yarn_Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pattern_Needle_Sizes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    us = table.Column<string>(nullable: true),
                    metric = table.Column<float>(nullable: true),
                    crochet = table.Column<bool>(nullable: true),
                    knitting = table.Column<bool>(nullable: true),
                    hook = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    pretty_metric = table.Column<string>(nullable: true),
                    Patternid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pattern_Needle_Sizes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pattern_Needle_Sizes_Pattern_Patternid",
                        column: x => x.Patternid,
                        principalTable: "Pattern",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostPatterns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patternid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostPatterns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostPatterns_Pattern_patternid",
                        column: x => x.patternid,
                        principalTable: "Pattern",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostShops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shopid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostShops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostShops_Shop_Shopid",
                        column: x => x.Shopid,
                        principalTable: "Shop",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stash",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<string>(nullable: true),
                    dye_lot = table.Column<string>(nullable: true),
                    favorites_count = table.Column<int>(nullable: true),
                    handspun = table.Column<bool>(nullable: true),
                    has_photo = table.Column<bool>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    user_id = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    colorway_name = table.Column<string>(nullable: true),
                    color_family_name = table.Column<string>(nullable: true),
                    yarn_weight_name = table.Column<string>(nullable: true),
                    long_yarn_weight_name = table.Column<string>(nullable: true),
                    personal_yarn_weight = table.Column<string>(nullable: true),
                    yarnid = table.Column<int>(nullable: true),
                    userid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stash", x => x.id);
                    table.ForeignKey(
                        name: "FK_Stash_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stash_Yarn_yarnid",
                        column: x => x.yarnid,
                        principalTable: "Yarn",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Yarn_Fibers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    percentage = table.Column<int>(nullable: true),
                    fiber_typeid = table.Column<int>(nullable: true),
                    Yarnid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yarn_Fibers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Yarn_Fibers_Yarn_Yarnid",
                        column: x => x.Yarnid,
                        principalTable: "Yarn",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Yarn_Fibers_Fiber_Type_fiber_typeid",
                        column: x => x.fiber_typeid,
                        principalTable: "Fiber_Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pack",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    primary_pack_id = table.Column<int>(nullable: true),
                    project_id = table.Column<int>(nullable: true),
                    skeins = table.Column<float>(nullable: true),
                    stash_id = table.Column<int>(nullable: true),
                    total_grams = table.Column<int>(nullable: true),
                    total_meters = table.Column<float>(nullable: true),
                    total_ounces = table.Column<float>(nullable: true),
                    total_yards = table.Column<float>(nullable: true),
                    yarn_id = table.Column<int>(nullable: true),
                    yarn_name = table.Column<string>(nullable: true),
                    colorway = table.Column<string>(nullable: true),
                    shop_name = table.Column<string>(nullable: true),
                    yarnid = table.Column<int>(nullable: true),
                    quantity_description = table.Column<string>(nullable: true),
                    personal_name = table.Column<string>(nullable: true),
                    dye_lot = table.Column<string>(nullable: true),
                    color_family_id = table.Column<int>(nullable: true),
                    grams_per_skein = table.Column<int>(nullable: true),
                    yards_per_skein = table.Column<float>(nullable: true),
                    meters_per_skein = table.Column<float>(nullable: true),
                    ounces_per_skein = table.Column<float>(nullable: true),
                    prefer_metric_weight = table.Column<bool>(nullable: true),
                    prefer_metric_length = table.Column<bool>(nullable: true),
                    shop_id = table.Column<int>(nullable: true),
                    thread_size = table.Column<float>(nullable: true),
                    Patternid = table.Column<int>(nullable: true),
                    Projectid = table.Column<int>(nullable: true),
                    Stashid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pack", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pack_Pattern_Patternid",
                        column: x => x.Patternid,
                        principalTable: "Pattern",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pack_Project_Projectid",
                        column: x => x.Projectid,
                        principalTable: "Project",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pack_Stash_Stashid",
                        column: x => x.Stashid,
                        principalTable: "Stash",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pack_Yarn_yarnid",
                        column: x => x.yarnid,
                        principalTable: "Yarn",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sort_order = table.Column<int>(nullable: true),
                    x_offset = table.Column<int>(nullable: true),
                    y_offset = table.Column<int>(nullable: true),
                    square_url = table.Column<string>(nullable: true),
                    medium_url = table.Column<string>(nullable: true),
                    thumbnail_url = table.Column<string>(nullable: true),
                    small_url = table.Column<string>(nullable: true),
                    shelved_url = table.Column<string>(nullable: true),
                    medium2_url = table.Column<string>(nullable: true),
                    small2_url = table.Column<string>(nullable: true),
                    Patternid = table.Column<int>(nullable: true),
                    Projectid = table.Column<int>(nullable: true),
                    Stashid = table.Column<int>(nullable: true),
                    Yarnid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Photo_Pattern_Patternid",
                        column: x => x.Patternid,
                        principalTable: "Pattern",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_Project_Projectid",
                        column: x => x.Projectid,
                        principalTable: "Project",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_Stash_Stashid",
                        column: x => x.Stashid,
                        principalTable: "Stash",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_Yarn_Yarnid",
                        column: x => x.Yarnid,
                        principalTable: "Yarn",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostStashs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stashid = table.Column<int>(nullable: true),
                    userid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostStashs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostStashs_Stash_stashid",
                        column: x => x.stashid,
                        principalTable: "Stash",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostStashs_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostContent = table.Column<string>(nullable: true),
                    TypeOfPost = table.Column<string>(nullable: true),
                    PostedByUserName = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true),
                    PatternId = table.Column<int>(nullable: true),
                    StashId = table.Column<int>(nullable: true),
                    ShopId = table.Column<int>(nullable: true),
                    CrafterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Crafter_CrafterId",
                        column: x => x.CrafterId,
                        principalTable: "Crafter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_PostPatterns_PatternId",
                        column: x => x.PatternId,
                        principalTable: "PostPatterns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_PostProjectss_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "PostProjectss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_PostShops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "PostShops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_PostStashs_StashId",
                        column: x => x.StashId,
                        principalTable: "PostStashs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentedAt = table.Column<DateTime>(nullable: true),
                    IsRead = table.Column<bool>(nullable: true),
                    CommentContent = table.Column<string>(nullable: true),
                    IsFirstComment = table.Column<bool>(nullable: true),
                    ReplyToId = table.Column<int>(nullable: true),
                    PostId = table.Column<int>(nullable: true),
                    CrafterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Crafter_CrafterId",
                        column: x => x.CrafterId,
                        principalTable: "Crafter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsLiked = table.Column<bool>(nullable: true),
                    LikedAt = table.Column<DateTime>(nullable: true),
                    PostId = table.Column<int>(nullable: true),
                    CommentId = table.Column<int>(nullable: true),
                    CrafterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Crafter_CrafterId",
                        column: x => x.CrafterId,
                        principalTable: "Crafter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bed35b6e-b493-4ec1-a23f-778bc7197b9e", "aaf268f0-fd4f-44d6-90c8-b2ba6710725d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c4878b2-b62a-4d93-aac6-ffae59b76e27", "35a5df17-4321-4d7c-a2db-768ae5f67e9b", "Crafter", "CRAFTER" });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_IdentityUserId",
                table: "Admin",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CrafterId",
                table: "Comments",
                column: "CrafterId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Crafter_IdentityUserId",
                table: "Crafter",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_CommentId",
                table: "Likes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_CrafterId",
                table: "Likes",
                column: "CrafterId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Needle_Sizes_Projectid",
                table: "Needle_Sizes",
                column: "Projectid");

            migrationBuilder.CreateIndex(
                name: "IX_Pack_Patternid",
                table: "Pack",
                column: "Patternid");

            migrationBuilder.CreateIndex(
                name: "IX_Pack_Projectid",
                table: "Pack",
                column: "Projectid");

            migrationBuilder.CreateIndex(
                name: "IX_Pack_Stashid",
                table: "Pack",
                column: "Stashid");

            migrationBuilder.CreateIndex(
                name: "IX_Pack_yarnid",
                table: "Pack",
                column: "yarnid");

            migrationBuilder.CreateIndex(
                name: "IX_Pattern_pattern_authorid",
                table: "Pattern",
                column: "pattern_authorid");

            migrationBuilder.CreateIndex(
                name: "IX_Pattern_pattern_typeid",
                table: "Pattern",
                column: "pattern_typeid");

            migrationBuilder.CreateIndex(
                name: "IX_Pattern_Needle_Sizes_Patternid",
                table: "Pattern_Needle_Sizes",
                column: "Patternid");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_Patternid",
                table: "Photo",
                column: "Patternid");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_Projectid",
                table: "Photo",
                column: "Projectid");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_Stashid",
                table: "Photo",
                column: "Stashid");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_Yarnid",
                table: "Photo",
                column: "Yarnid");

            migrationBuilder.CreateIndex(
                name: "IX_PostPatterns_patternid",
                table: "PostPatterns",
                column: "patternid");

            migrationBuilder.CreateIndex(
                name: "IX_PostProjectss_projectid",
                table: "PostProjectss",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CrafterId",
                table: "Posts",
                column: "CrafterId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PatternId",
                table: "Posts",
                column: "PatternId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ProjectId",
                table: "Posts",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ShopId",
                table: "Posts",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_StashId",
                table: "Posts",
                column: "StashId");

            migrationBuilder.CreateIndex(
                name: "IX_PostShops_Shopid",
                table: "PostShops",
                column: "Shopid");

            migrationBuilder.CreateIndex(
                name: "IX_PostStashs_stashid",
                table: "PostStashs",
                column: "stashid");

            migrationBuilder.CreateIndex(
                name: "IX_PostStashs_userid",
                table: "PostStashs",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_countryid",
                table: "Shop",
                column: "countryid");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_stateid",
                table: "Shop",
                column: "stateid");

            migrationBuilder.CreateIndex(
                name: "IX_Stash_userid",
                table: "Stash",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Stash_yarnid",
                table: "Stash",
                column: "yarnid");

            migrationBuilder.CreateIndex(
                name: "IX_Yarn_yarn_companyid",
                table: "Yarn",
                column: "yarn_companyid");

            migrationBuilder.CreateIndex(
                name: "IX_Yarn_Fibers_Yarnid",
                table: "Yarn_Fibers",
                column: "Yarnid");

            migrationBuilder.CreateIndex(
                name: "IX_Yarn_Fibers_fiber_typeid",
                table: "Yarn_Fibers",
                column: "fiber_typeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Needle_Sizes");

            migrationBuilder.DropTable(
                name: "Pack");

            migrationBuilder.DropTable(
                name: "Pattern_Needle_Sizes");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Yarn_Fibers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Fiber_Type");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Crafter");

            migrationBuilder.DropTable(
                name: "PostPatterns");

            migrationBuilder.DropTable(
                name: "PostProjectss");

            migrationBuilder.DropTable(
                name: "PostShops");

            migrationBuilder.DropTable(
                name: "PostStashs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Pattern");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "Stash");

            migrationBuilder.DropTable(
                name: "Pattern_Author");

            migrationBuilder.DropTable(
                name: "Pattern_Type");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Yarn");

            migrationBuilder.DropTable(
                name: "Yarn_Company");
        }
    }
}
