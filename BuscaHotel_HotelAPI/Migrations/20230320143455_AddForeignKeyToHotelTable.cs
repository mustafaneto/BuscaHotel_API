using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuscaHotel_HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToHotelTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelID",
                table: "HotelNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 11, 34, 55, 887, DateTimeKind.Local).AddTicks(347));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 11, 34, 55, 887, DateTimeKind.Local).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 11, 34, 55, 887, DateTimeKind.Local).AddTicks(359));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 11, 34, 55, 887, DateTimeKind.Local).AddTicks(361));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 20, 11, 34, 55, 887, DateTimeKind.Local).AddTicks(362));

            migrationBuilder.CreateIndex(
                name: "IX_HotelNumbers_HotelID",
                table: "HotelNumbers",
                column: "HotelID");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelNumbers_Hoteis_HotelID",
                table: "HotelNumbers",
                column: "HotelID",
                principalTable: "Hoteis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelNumbers_Hoteis_HotelID",
                table: "HotelNumbers");

            migrationBuilder.DropIndex(
                name: "IX_HotelNumbers_HotelID",
                table: "HotelNumbers");

            migrationBuilder.DropColumn(
                name: "HotelID",
                table: "HotelNumbers");

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 17, 14, 28, 24, 626, DateTimeKind.Local).AddTicks(3532));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 17, 14, 28, 24, 626, DateTimeKind.Local).AddTicks(3551));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 17, 14, 28, 24, 626, DateTimeKind.Local).AddTicks(3554));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 17, 14, 28, 24, 626, DateTimeKind.Local).AddTicks(3557));

            migrationBuilder.UpdateData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2023, 3, 17, 14, 28, 24, 626, DateTimeKind.Local).AddTicks(3559));
        }
    }
}
