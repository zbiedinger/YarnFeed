using Microsoft.EntityFrameworkCore.Migrations;

namespace Yarn_Feed.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8e8b9b3-13e4-461f-ba69-93db755bf0b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9499a76-fbab-4d61-b749-4efb80513a9e");

            migrationBuilder.AddColumn<bool>(
                name: "IsRepost",
                table: "Posts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OriginallyPosedBy",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostersPhoto",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepostBlurb",
                table: "Posts",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a14bb680-ac7f-499e-acb7-d521bbcdbd50", "71ca759b-500a-4c1b-97f1-51f6593c5965", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c05ce85d-0e95-450c-b424-6207d4315962", "92a6321f-ff11-4a00-aba1-a1ce3a661f8c", "Crafter", "CRAFTER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a14bb680-ac7f-499e-acb7-d521bbcdbd50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c05ce85d-0e95-450c-b424-6207d4315962");

            migrationBuilder.DropColumn(
                name: "IsRepost",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "OriginallyPosedBy",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostersPhoto",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "RepostBlurb",
                table: "Posts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b8e8b9b3-13e4-461f-ba69-93db755bf0b5", "05787bf0-13ad-444a-adfc-e08e4dd4d5e4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9499a76-fbab-4d61-b749-4efb80513a9e", "54d08194-1370-4da6-bf19-991f13efd93b", "Crafter", "CRAFTER" });
        }
    }
}
