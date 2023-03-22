using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuscaHotel_HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNullableToFalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DetalhesEspeciais",
                table: "HotelNumbers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Servicos",
                table: "Hoteis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImagemUrl",
                table: "Hoteis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Hoteis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DetalhesEspeciais",
                table: "HotelNumbers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Servicos",
                table: "Hoteis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagemUrl",
                table: "Hoteis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Hoteis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
