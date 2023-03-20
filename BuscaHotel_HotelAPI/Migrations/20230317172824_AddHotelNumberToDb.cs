using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuscaHotel_HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddHotelNumberToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelNumbers",
                columns: table => new
                {
                    HotelNo = table.Column<int>(type: "int", nullable: false),
                    DetalhesEspeciais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelNumbers", x => x.HotelNo);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelNumbers");

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
    }
}
