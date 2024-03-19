using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFluent_OneToOneRelation_Book_BookDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Book_Id",
                table: "BookDetails_Fluent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookDetails_Fluent_Book_Id",
                table: "BookDetails_Fluent",
                column: "Book_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetails_Fluent_Books_Fluent_Book_Id",
                table: "BookDetails_Fluent",
                column: "Book_Id",
                principalTable: "Books_Fluent",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDetails_Fluent_Books_Fluent_Book_Id",
                table: "BookDetails_Fluent");

            migrationBuilder.DropIndex(
                name: "IX_BookDetails_Fluent_Book_Id",
                table: "BookDetails_Fluent");

            migrationBuilder.DropColumn(
                name: "Book_Id",
                table: "BookDetails_Fluent");
        }
    }
}
