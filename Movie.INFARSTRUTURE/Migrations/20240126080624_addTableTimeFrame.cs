using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.INFARSTRUTURE.Migrations
{
    public partial class addTableTimeFrame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Shows");

            migrationBuilder.CreateTable(
                name: "TimeFrames",
                columns: table => new
                {
                    TimeFrameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeFrames", x => x.TimeFrameID);
                });

            migrationBuilder.CreateTable(
                name: "ShowTimeFrame",
                columns: table => new
                {
                    ShowID = table.Column<int>(type: "int", nullable: false),
                    TimeFrameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowTimeFrame", x => new { x.ShowID, x.TimeFrameID });
                    table.ForeignKey(
                        name: "FK_ShowTimeFrame_Shows_ShowID",
                        column: x => x.ShowID,
                        principalTable: "Shows",
                        principalColumn: "ShowID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowTimeFrame_TimeFrames_TimeFrameID",
                        column: x => x.TimeFrameID,
                        principalTable: "TimeFrames",
                        principalColumn: "TimeFrameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimeFrame_TimeFrameID",
                table: "ShowTimeFrame",
                column: "TimeFrameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShowTimeFrame");

            migrationBuilder.DropTable(
                name: "TimeFrames");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Shows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Shows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
