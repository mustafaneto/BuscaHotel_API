using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuscaHotel_HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedHotelTableWithCreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 15, 13, 49, 4, 5, DateTimeKind.Local).AddTicks(9157));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 15, 13, 49, 4, 5, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 15, 13, 49, 4, 5, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 15, 13, 49, 4, 5, DateTimeKind.Local).AddTicks(9172));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 15, 13, 49, 4, 5, DateTimeKind.Local).AddTicks(9173));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
