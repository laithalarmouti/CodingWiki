using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class @finally : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthorMap_Book_Id",
                table: "BookAuthorMap");

            migrationBuilder.RenameTable(
                name: "SubCategories",
                newName: "subCategories");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Books_Fluent",
                type: "decimal(10,5)",
                precision: 10,
                scale: 5,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,5)",
                oldPrecision: 10,
                oldScale: 5);

            migrationBuilder.AddPrimaryKey(
                name: "PK_subCategories",
                table: "subCategories",
                column: "SubCategory_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap",
                columns: new[] { "Book_Id", "Author_Id" });

            migrationBuilder.CreateTable(
                name: "AuthorMaps_Fluent",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorMaps_Fluent", x => new { x.Author_Id, x.Book_Id });
                    table.ForeignKey(
                        name: "FK_AuthorMaps_Fluent_Authors_Fluent_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Authors_Fluent",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorMaps_Fluent_Books_Fluent_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Books_Fluent",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorMap_Author_Id",
                table: "BookAuthorMap",
                column: "Author_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorMaps_Fluent_Book_Id",
                table: "AuthorMaps_Fluent",
                column: "Book_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorMaps_Fluent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subCategories",
                table: "subCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthorMap_Author_Id",
                table: "BookAuthorMap");

            migrationBuilder.RenameTable(
                name: "subCategories",
                newName: "SubCategories");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Books_Fluent",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,5)",
                oldPrecision: 10,
                oldScale: 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Books",
                type: "decimal(10,5)",
                precision: 10,
                scale: 5,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories",
                column: "SubCategory_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorMap_Book_Id",
                table: "BookAuthorMap",
                column: "Book_Id");
        }
    }
}
