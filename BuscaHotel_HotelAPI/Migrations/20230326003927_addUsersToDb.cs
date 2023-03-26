using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuscaHotel_HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class addUsersToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 25, 21, 39, 27, 34, DateTimeKind.Local).AddTicks(2734));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 25, 21, 39, 27, 34, DateTimeKind.Local).AddTicks(2907));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 25, 21, 39, 27, 34, DateTimeKind.Local).AddTicks(2918));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 25, 21, 39, 27, 34, DateTimeKind.Local).AddTicks(2920));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 25, 21, 39, 27, 34, DateTimeKind.Local).AddTicks(2921));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 21, 22, 20, 24, 704, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 21, 22, 20, 24, 704, DateTimeKind.Local).AddTicks(5777));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 21, 22, 20, 24, 704, DateTimeKind.Local).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 21, 22, 20, 24, 704, DateTimeKind.Local).AddTicks(5780));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 21, 22, 20, 24, 704, DateTimeKind.Local).AddTicks(5782));
        }
    }
}
