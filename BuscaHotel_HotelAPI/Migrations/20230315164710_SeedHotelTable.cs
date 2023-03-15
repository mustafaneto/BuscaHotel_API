using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuscaHotel_HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedHotelTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "Hoteis",
                newName: "Diaria");

            migrationBuilder.InsertData(
                table: "Hoteis",
                columns: new[] { "Id", "Area", "DataAtualizacao", "DataCriacao", "Descricao", "Diaria", "ImagemUrl", "Nome", "Ocupacao", "Servicos" },
                values: new object[,]
                {
                    { 1, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "O hotel localizado em Rio Branco, Acre, próximo ao shopping e supermercados é uma excelente opção para quem busca conforto e conveniência durante a estadia na cidade. Com a sua localização privilegiada, os hóspedes têm fácil acesso a diversas opções de compras, alimentação e entretenimento.", 200.0, "https://static.showit.co/800/vtY9NPGcQUynJd1xRFSrOg/72275/gina_and_ryan_photography_-_acre_2017_-_064.jpg", "Rio Branco Hotel", 5, "" },
                    { 2, 900, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Localizado na cidade de Cruzeiro do Sul, Acre, este hotel é uma excelente opção para quem busca conforto e praticidade. Com quartos amplos e bem equipados, o hotel oferece um ambiente agradável e acolhedor para os hóspedes. Além disso, conta com uma área de lazer com piscina, sauna e academia, tornando a estadia ainda mais relaxante.", 500.0, "https://goop-img.com/wp-content/uploads/2018/01/Gina-Ryan-Photography-Acre-2017-032.jpg", "Cruzeiro do Sul Hotel", 5, "" },
                    { 3, 750, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " O Sena Madureira Hotel está situado na cidade de Sena Madureira, Acre, e é ideal para quem busca um ambiente mais tranquilo e próximo à natureza. Com uma ampla área verde ao redor do hotel, os hóspedes podem desfrutar de uma atmosfera mais calma e agradável. Além disso, o hotel oferece atividades ao ar livre como trilhas ecológicas, pesca esportiva e passeios de barco.", 100.0, "https://static.showit.co/1200/xVOR7ZFYQGqkRCPXUxMAIg/72275/acre_resort_pool.jpg", "Sena Madureira Hotel", 5, "" },
                    { 4, 800, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Localizado na cidade de Quinari, Acre, este hotel é uma excelente opção para quem procura um ambiente mais intimista e acolhedor. Com um design moderno e aconchegante, o hotel oferece quartos confortáveis e bem equipados. Além disso, conta com um restaurante que serve pratos típicos da culinária regional, proporcionando uma experiência gastronômica única aos hóspedes.", 250.0, "https://static.showit.co/1200/8n7f7DqLRpG2flPGfuDCEA/72275/gina_and_ryan_photography_-_acre_2017_-_115_web.jpg", "Quinari Hotel", 4, "" },
                    { 5, 400, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Situado na cidade de Brasileia, Acre, este hotel é ideal para quem busca um ambiente mais urbano e conectado. Com quartos modernos e bem equipados, o hotel oferece uma excelente estrutura para quem está a negócios ou lazer. Além disso, conta com uma localização privilegiada, próximo a restaurantes, bares e lojas, tornando a estadia ainda mais prática e conveniente.", 300.0, "https://www.travelandleisure.com/thmb/C9j_ENR2mCCTAKr64UGCJY-ZLsM=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/bedroom-acre-baja-CABOHOTELMEZCAL0721-e39f5592b7fd45d6923018edd02d22ef.jpg", "Brasiléia Hotel", 4, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hoteis",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "Diaria",
                table: "Hoteis",
                newName: "Rate");
        }
    }
}
