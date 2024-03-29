﻿// <auto-generated />
using System;
using BuscaHotel_HotelAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuscaHotel_HotelAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230315164904_SeedHotelTableWithCreatedDate")]
    partial class SeedHotelTableWithCreatedDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BuscaHotel_HotelAPI.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Diaria")
                        .HasColumnType("float");

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocupacao")
                        .HasColumnType("int");

                    b.Property<string>("Servicos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hoteis");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Area = 500,
                            DataAtualizacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(2023, 3, 15, 13, 49, 4, 5, DateTimeKind.Local).AddTicks(9157),
                            Descricao = "O hotel localizado em Rio Branco, Acre, próximo ao shopping e supermercados é uma excelente opção para quem busca conforto e conveniência durante a estadia na cidade. Com a sua localização privilegiada, os hóspedes têm fácil acesso a diversas opções de compras, alimentação e entretenimento.",
                            Diaria = 200.0,
                            ImagemUrl = "https://static.showit.co/800/vtY9NPGcQUynJd1xRFSrOg/72275/gina_and_ryan_photography_-_acre_2017_-_064.jpg",
                            Nome = "Rio Branco Hotel",
                            Ocupacao = 5,
                            Servicos = ""
                        },
                        new
                        {
                            Id = 2,
                            Area = 900,
                            DataAtualizacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(2023, 3, 15, 13, 49, 4, 5, DateTimeKind.Local).AddTicks(9168),
                            Descricao = "Localizado na cidade de Cruzeiro do Sul, Acre, este hotel é uma excelente opção para quem busca conforto e praticidade. Com quartos amplos e bem equipados, o hotel oferece um ambiente agradável e acolhedor para os hóspedes. Além disso, conta com uma área de lazer com piscina, sauna e academia, tornando a estadia ainda mais relaxante.",
                            Diaria = 500.0,
                            ImagemUrl = "https://goop-img.com/wp-content/uploads/2018/01/Gina-Ryan-Photography-Acre-2017-032.jpg",
                            Nome = "Cruzeiro do Sul Hotel",
                            Ocupacao = 5,
                            Servicos = ""
                        },
                        new
                        {
                            Id = 3,
                            Area = 750,
                            DataAtualizacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(2023, 3, 15, 13, 49, 4, 5, DateTimeKind.Local).AddTicks(9170),
                            Descricao = " O Sena Madureira Hotel está situado na cidade de Sena Madureira, Acre, e é ideal para quem busca um ambiente mais tranquilo e próximo à natureza. Com uma ampla área verde ao redor do hotel, os hóspedes podem desfrutar de uma atmosfera mais calma e agradável. Além disso, o hotel oferece atividades ao ar livre como trilhas ecológicas, pesca esportiva e passeios de barco.",
                            Diaria = 100.0,
                            ImagemUrl = "https://static.showit.co/1200/xVOR7ZFYQGqkRCPXUxMAIg/72275/acre_resort_pool.jpg",
                            Nome = "Sena Madureira Hotel",
                            Ocupacao = 5,
                            Servicos = ""
                        },
                        new
                        {
                            Id = 4,
                            Area = 800,
                            DataAtualizacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(2023, 3, 15, 13, 49, 4, 5, DateTimeKind.Local).AddTicks(9172),
                            Descricao = "Localizado na cidade de Quinari, Acre, este hotel é uma excelente opção para quem procura um ambiente mais intimista e acolhedor. Com um design moderno e aconchegante, o hotel oferece quartos confortáveis e bem equipados. Além disso, conta com um restaurante que serve pratos típicos da culinária regional, proporcionando uma experiência gastronômica única aos hóspedes.",
                            Diaria = 250.0,
                            ImagemUrl = "https://static.showit.co/1200/8n7f7DqLRpG2flPGfuDCEA/72275/gina_and_ryan_photography_-_acre_2017_-_115_web.jpg",
                            Nome = "Quinari Hotel",
                            Ocupacao = 4,
                            Servicos = ""
                        },
                        new
                        {
                            Id = 5,
                            Area = 400,
                            DataAtualizacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(2023, 3, 15, 13, 49, 4, 5, DateTimeKind.Local).AddTicks(9173),
                            Descricao = "Situado na cidade de Brasileia, Acre, este hotel é ideal para quem busca um ambiente mais urbano e conectado. Com quartos modernos e bem equipados, o hotel oferece uma excelente estrutura para quem está a negócios ou lazer. Além disso, conta com uma localização privilegiada, próximo a restaurantes, bares e lojas, tornando a estadia ainda mais prática e conveniente.",
                            Diaria = 300.0,
                            ImagemUrl = "https://www.travelandleisure.com/thmb/C9j_ENR2mCCTAKr64UGCJY-ZLsM=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/bedroom-acre-baja-CABOHOTELMEZCAL0721-e39f5592b7fd45d6923018edd02d22ef.jpg",
                            Nome = "Brasiléia Hotel",
                            Ocupacao = 4,
                            Servicos = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
