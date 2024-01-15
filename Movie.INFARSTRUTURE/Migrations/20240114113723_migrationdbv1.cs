using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.INFARSTRUTURE.Migrations
{
    public partial class migrationdbv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "mv_name",
                table: "Movies",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "genre_name",
                table: "genre",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.city_id);
                });

            migrationBuilder.CreateTable(
                name: "Fare",
                columns: table => new
                {
                    fare_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fare_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    unit_price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fare", x => x.fare_id);
                });

            migrationBuilder.CreateTable(
                name: "Movie_type",
                columns: table => new
                {
                    mv_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mv_type_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surcharge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_type", x => x.mv_type_id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Seat_type",
                columns: table => new
                {
                    seat_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    seat_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    surcharge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat_type", x => x.seat_type_id);
                });

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    cinema_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cinema_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cinema_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cinema_tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cinema_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.cinema_id);
                    table.ForeignKey(
                        name: "FK_Cinemas_Cities_city_id",
                        column: x => x.city_id,
                        principalTable: "Cities",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    regis_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Theaters",
                columns: table => new
                {
                    theater_id = table.Column<int>(type: "int", nullable: false),
                    row_qty = table.Column<int>(type: "int", nullable: false),
                    col_qty = table.Column<int>(type: "int", nullable: false),
                    cinema_id = table.Column<int>(type: "int", nullable: false),
                    seat_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theaters", x => x.theater_id);
                    table.ForeignKey(
                        name: "FK_Theaters_Cinemas_theater_id",
                        column: x => x.theater_id,
                        principalTable: "Cinemas",
                        principalColumn: "cinema_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    seat_id = table.Column<int>(type: "int", nullable: false),
                    row_loc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    col_loc = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    theater_id = table.Column<int>(type: "int", nullable: false),
                    seat_type_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.seat_id);
                    table.ForeignKey(
                        name: "FK_Seats_Seat_type_seat_type_id",
                        column: x => x.seat_type_id,
                        principalTable: "Seat_type",
                        principalColumn: "seat_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seats_Theaters_seat_id",
                        column: x => x.seat_id,
                        principalTable: "Theaters",
                        principalColumn: "theater_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    show_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    start_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    show_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mv_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mv_type_id = table.Column<int>(type: "int", nullable: false),
                    theater_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.show_id);
                    table.ForeignKey(
                        name: "FK_Shows_Movie_type_mv_type_id",
                        column: x => x.mv_type_id,
                        principalTable: "Movie_type",
                        principalColumn: "mv_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shows_Movies_mv_id",
                        column: x => x.mv_id,
                        principalTable: "Movies",
                        principalColumn: "mv_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shows_Theaters_theater_id",
                        column: x => x.theater_id,
                        principalTable: "Theaters",
                        principalColumn: "theater_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    bk_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sale_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    show_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    seat_id = table.Column<int>(type: "int", nullable: false),
                    fare_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.bk_id);
                    table.ForeignKey(
                        name: "FK_Booking_Fare_fare_id",
                        column: x => x.fare_id,
                        principalTable: "Fare",
                        principalColumn: "fare_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Seats_seat_id",
                        column: x => x.seat_id,
                        principalTable: "Seats",
                        principalColumn: "seat_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_fare_id",
                table: "Booking",
                column: "fare_id");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_seat_id",
                table: "Booking",
                column: "seat_id");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_user_id",
                table: "Booking",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_city_id",
                table: "Cinemas",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_seat_type_id",
                table: "Seats",
                column: "seat_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_mv_id",
                table: "Shows",
                column: "mv_id");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_mv_type_id",
                table: "Shows",
                column: "mv_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_theater_id",
                table: "Shows",
                column: "theater_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_role_id",
                table: "Users",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Fare");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Movie_type");

            migrationBuilder.DropTable(
                name: "Seat_type");

            migrationBuilder.DropTable(
                name: "Theaters");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "mv_name",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "genre_name",
                table: "genre",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);
        }
    }
}
