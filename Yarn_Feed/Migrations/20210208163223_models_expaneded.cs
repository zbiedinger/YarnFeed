using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yarn_Feed.Migrations
{
    public partial class models_expaneded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1211c9e-b025-4e4a-a1e7-07a0d9d01ee1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9882d2a-1cce-4bc4-94fd-0a090a71ef98");

            migrationBuilder.AddColumn<string>(
                name: "PostedByUserName",
                table: "Posts",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4cf99c16-97df-45f2-9d3c-a0fdab9fedbf", "25905c73-b67a-4703-bb7e-83badef0f25c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a0fe706d-6553-4f67-9b1d-03251f1a0c9e", "0fa77407-4606-48e6-96e7-578e2c725e9d", "Crafter", "CRAFTER" });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_IdentityUserId",
                table: "Admin",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cf99c16-97df-45f2-9d3c-a0fdab9fedbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0fe706d-6553-4f67-9b1d-03251f1a0c9e");

            migrationBuilder.DropColumn(
                name: "PostedByUserName",
                table: "Posts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9882d2a-1cce-4bc4-94fd-0a090a71ef98", "9ad25386-27eb-488e-884e-a92e2c4b3df1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1211c9e-b025-4e4a-a1e7-07a0d9d01ee1", "26d3c870-7750-44ba-ae60-ea29a4fb8ccf", "Crafter", "CRAFTER" });
        }
    }
}
