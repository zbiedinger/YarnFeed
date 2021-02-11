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
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostContent = table.Column<string>(nullable: true),
                    TypeOfPost = table.Column<string>(nullable: true),
                    PostedByUserName = table.Column<string>(nullable: true),
                    PostersPhoto = table.Column<string>(nullable: true),
                    TimePosted = table.Column<DateTime>(nullable: false),
                    IsRepost = table.Column<bool>(nullable: false),
                    OriginallyPosedBy = table.Column<string>(nullable: true),
                    RepostBlurb = table.Column<string>(nullable: true),
                    CrafterId = table.Column<int>(nullable: true),
                    stash_has_photo = table.Column<bool>(nullable: false),
                    stash_API_id = table.Column<int>(nullable: true),
                    user_id = table.Column<int>(nullable: true),
                    stash_name = table.Column<string>(nullable: true),
                    colorway_name = table.Column<string>(nullable: true),
                    color_family_name = table.Column<string>(nullable: true),
                    yarn_weight_name = table.Column<string>(nullable: true),
                    shelved_url = table.Column<string>(nullable: true),
                    medium_url = table.Column<string>(nullable: true),
                    company_name = table.Column<string>(nullable: true),
                    fiber1Percent = table.Column<int>(nullable: true),
                    fiber1 = table.Column<string>(nullable: true),
                    fiber2Percent = table.Column<int>(nullable: true),
                    fiber2 = table.Column<string>(nullable: true),
                    fiber3Percent = table.Column<int>(nullable: true),
                    fiber3 = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    facebook_page = table.Column<string>(nullable: true),
                    shop_id = table.Column<int>(nullable: true),
                    latitude = table.Column<float>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    longitude = table.Column<float>(nullable: true),
                    shop_name = table.Column<string>(nullable: true),
                    shop_permalink = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    pos_online = table.Column<bool>(nullable: true),
                    ravelry_retailer = table.Column<bool>(nullable: true),
                    shop_email = table.Column<string>(nullable: true),
                    twitter_id = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    zip = table.Column<string>(nullable: true),
                    notes_html = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    completed = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    project_id = table.Column<int>(nullable: true),
                    made_for = table.Column<string>(nullable: true),
                    project_name = table.Column<string>(nullable: true),
                    progress = table.Column<int>(nullable: true),
                    project_status_changed = table.Column<string>(nullable: true),
                    rating = table.Column<int>(nullable: true),
                    size = table.Column<string>(nullable: true),
                    started = table.Column<string>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    craft_name = table.Column<string>(nullable: true),
                    status_name = table.Column<string>(nullable: true),
                    needle_sizes = table.Column<string>(nullable: true),
                    needle_sizes2 = table.Column<string>(nullable: true),
                    needle_sizes3 = table.Column<string>(nullable: true),
                    photos_count = table.Column<int>(nullable: true),
                    currency = table.Column<string>(nullable: true),
                    difficulty_average = table.Column<float>(nullable: true),
                    difficulty_count = table.Column<int>(nullable: true),
                    downloadable = table.Column<bool>(nullable: true),
                    favorites_count = table.Column<int>(nullable: true),
                    free = table.Column<bool>(nullable: true),
                    pattern_id = table.Column<int>(nullable: true),
                    pattern_name = table.Column<string>(nullable: true),
                    price = table.Column<float>(nullable: true),
                    projects_count = table.Column<int>(nullable: true),
                    queued_projects_count = table.Column<int>(nullable: true),
                    rating_average = table.Column<float>(nullable: true),
                    rating_count = table.Column<int>(nullable: true),
                    yardage = table.Column<int>(nullable: true),
                    yardage_max = table.Column<int>(nullable: true),
                    sizes_available = table.Column<string>(nullable: true),
                    product_id = table.Column<int>(nullable: true),
                    currency_symbol = table.Column<string>(nullable: true),
                    gauge_description = table.Column<string>(nullable: true),
                    yarn_weight_description = table.Column<string>(nullable: true),
                    yardage_description = table.Column<string>(nullable: true),
                    pattern_author = table.Column<string>(nullable: true)
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
                    CrafterPhoto = table.Column<string>(nullable: true),
                    CrafterName = table.Column<string>(nullable: true),
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
                values: new object[] { "362b6526-7ff8-4197-831f-f2a54821ed86", "ca44671d-7783-4912-87a6-28ec992270d3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ff424ea-0dfe-4110-9791-bfafa6500e79", "aa2f588f-ab99-4985-84a5-3615ad2b94b0", "Crafter", "CRAFTER" });

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
                name: "IX_Posts_CrafterId",
                table: "Posts",
                column: "CrafterId");
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Crafter");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
