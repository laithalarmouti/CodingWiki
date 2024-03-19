using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class nameFixing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_BookDetails",
                table: "Fluent_BookDetails");

            migrationBuilder.RenameTable(
                name: "Fluent_BookDetails",
                newName: "BookDetails_Fluent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookDetails_Fluent",
                table: "BookDetails_Fluent",
                column: "BookDetail_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookDetails_Fluent",
                table: "BookDetails_Fluent");

            migrationBuilder.RenameTable(
                name: "BookDetails_Fluent",
                newName: "Fluent_BookDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_BookDetails",
                table: "Fluent_BookDetails",
                column: "BookDetail_Id");
        }
    }
}
