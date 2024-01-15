using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.INFARSTRUTURE.Migrations
{
    public partial class AddTableMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "genre_id",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genre_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre", x => x.genre_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_genre_id",
                table: "Movies",
                column: "genre_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_genre_genre_id",
                table: "Movies",
                column: "genre_id",
                principalTable: "genre",
                principalColumn: "genre_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_genre_genre_id",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropIndex(
                name: "IX_Movies_genre_id",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "genre_id",
                table: "Movies");
        }
    }
}
