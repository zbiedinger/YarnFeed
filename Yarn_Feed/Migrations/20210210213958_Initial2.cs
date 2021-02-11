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
                keyValue: "28b1a8d2-3616-4ee8-9048-dcd988965ca4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc6cb2ef-bf43-4761-9cca-aab4bac71c7f");

            migrationBuilder.AddColumn<string>(
                name: "CrafterName",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CrafterPhoto",
                table: "Comments",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97eb059a-ade1-4980-8d19-130712e9c95f", "b9f2aa4d-35b1-46d2-b698-c8fc8bb922e2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d490a7cc-1ee6-4abe-95bf-c22b02fdbb09", "b8911bc3-b2d9-43b7-acd3-99f022ee1e01", "Crafter", "CRAFTER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97eb059a-ade1-4980-8d19-130712e9c95f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d490a7cc-1ee6-4abe-95bf-c22b02fdbb09");

            migrationBuilder.DropColumn(
                name: "CrafterName",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CrafterPhoto",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc6cb2ef-bf43-4761-9cca-aab4bac71c7f", "85da4ee1-80d5-4c16-98b9-8c47e17b37ce", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28b1a8d2-3616-4ee8-9048-dcd988965ca4", "59523933-1ac4-4319-8470-5c78377cb7f6", "Crafter", "CRAFTER" });
        }
    }
}
