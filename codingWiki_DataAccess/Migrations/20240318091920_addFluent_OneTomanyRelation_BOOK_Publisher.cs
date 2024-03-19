using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFluent_OneTomanyRelation_BOOK_Publisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_id",
                table: "Books_Fluent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Fluent_Publisher_id",
                table: "Books_Fluent",
                column: "Publisher_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Fluent_Publisher_Fluent_Publisher_id",
                table: "Books_Fluent",
                column: "Publisher_id",
                principalTable: "Publisher_Fluent",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Fluent_Publisher_Fluent_Publisher_id",
                table: "Books_Fluent");

            migrationBuilder.DropIndex(
                name: "IX_Books_Fluent_Publisher_id",
                table: "Books_Fluent");

            migrationBuilder.DropColumn(
                name: "Publisher_id",
                table: "Books_Fluent");
        }
    }
}
