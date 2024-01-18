using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.INFARSTRUTURE.Migrations
{
    public partial class updateEntityMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "comming_soon",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hot",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "photo",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "show_now",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "summary",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "trailer",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "comming_soon",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "hot",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "photo",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "show_now",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "summary",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "trailer",
                table: "Movies");
        }
    }
}
