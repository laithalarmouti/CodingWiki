using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace codingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class sedBoTae : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "ISBN", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "53SD4", 10.99m, "Spider without Duty" },
                    { 2, "66FD3", 11.99m, "Fly without Duty" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 2);
        }
    }
}
