using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wandermate_backend.Migrations
{
    /// <inheritdoc />
    public partial class identitycontrolpassreqtokensjsonset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64703306-71b2-4cb5-9055-6370131c69cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c826c4e-1e07-47a2-8362-116bfb3b41b8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b8bcac54-c85e-434f-a322-320420bb2b23", null, "User", "USER" },
                    { "d3fdbc14-a349-4c9e-91f6-e544b05cbbc7", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8bcac54-c85e-434f-a322-320420bb2b23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3fdbc14-a349-4c9e-91f6-e544b05cbbc7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64703306-71b2-4cb5-9055-6370131c69cb", null, "User", "USER" },
                    { "8c826c4e-1e07-47a2-8362-116bfb3b41b8", null, "Admin", "ADMIN" }
                });
        }
    }
}
