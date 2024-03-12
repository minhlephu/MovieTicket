using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.INFARSTRUTURE.Migrations
{
    public partial class updateShow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatID",
                table: "Theaters");

            migrationBuilder.AddColumn<string>(
                name: "TheaterName",
                table: "Theaters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TheaterName",
                table: "Theaters");

            migrationBuilder.AddColumn<int>(
                name: "SeatID",
                table: "Theaters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
