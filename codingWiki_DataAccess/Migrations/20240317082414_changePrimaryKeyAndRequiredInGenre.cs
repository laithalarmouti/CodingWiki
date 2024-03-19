using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changePrimaryKeyAndRequiredInGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenreID",
                table: "tb_genres",
                newName: "Genre_ID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tb_genres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genre_ID",
                table: "tb_genres",
                newName: "GenreID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tb_genres",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
