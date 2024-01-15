using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.INFARSTRUTURE.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    mv_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mv_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    release_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.mv_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
