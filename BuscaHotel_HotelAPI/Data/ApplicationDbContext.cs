using BuscaHotel_HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BuscaHotel_HotelAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Hotel> Hoteis { get; set; }
        public DbSet<HotelNumber> HotelNumbers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Nome = "Rio Branco Hotel",
                    Descricao = "O hotel localizado em Rio Branco, Acre, próximo ao shopping e supermercados é uma excelente opção para quem busca conforto e conveniência durante a estadia na cidade. Com a sua localização privilegiada, os hóspedes têm fácil acesso a diversas opções de compras, alimentação e entretenimento.",
                    Diaria = 200,
                    Ocupacao = 5,
                    Area = 500,
                    ImagemUrl = "https://static.showit.co/800/vtY9NPGcQUynJd1xRFSrOg/72275/gina_and_ryan_photography_-_acre_2017_-_064.jpg",
                    Servicos = "",
                    DataCriacao = DateTime.Now
                },
                new Hotel
                {
                    Id = 2,
                    Nome = "Cruzeiro do Sul Hotel",
                    Descricao = "Localizado na cidade de Cruzeiro do Sul, Acre, este hotel é uma excelente opção para quem busca conforto e praticidade. Com quartos amplos e bem equipados, o hotel oferece um ambiente agradável e acolhedor para os hóspedes. Além disso, conta com uma área de lazer com piscina, sauna e academia, tornando a estadia ainda mais relaxante.",
                    Diaria = 500,
                    Ocupacao = 5,
                    Area = 900,
                    ImagemUrl = "https://goop-img.com/wp-content/uploads/2018/01/Gina-Ryan-Photography-Acre-2017-032.jpg",
                    Servicos = "",
                    DataCriacao = DateTime.Now
                },
                new Hotel
                {
                    Id = 3,
                    Nome = "Sena Madureira Hotel",
                    Descricao = " O Sena Madureira Hotel está situado na cidade de Sena Madureira, Acre, e é ideal para quem busca um ambiente mais tranquilo e próximo à natureza. Com uma ampla área verde ao redor do hotel, os hóspedes podem desfrutar de uma atmosfera mais calma e agradável. Além disso, o hotel oferece atividades ao ar livre como trilhas ecológicas, pesca esportiva e passeios de barco.",
                    Diaria = 100,
                    Ocupacao = 5,
                    Area = 750,
                    ImagemUrl = "https://static.showit.co/1200/xVOR7ZFYQGqkRCPXUxMAIg/72275/acre_resort_pool.jpg",
                    Servicos = "",
                    DataCriacao = DateTime.Now
                },
                new Hotel

                {
                    Id = 4,
                    Nome = "Quinari Hotel",
                    Descricao = "Localizado na cidade de Quinari, Acre, este hotel é uma excelente opção para quem procura um ambiente mais intimista e acolhedor. Com um design moderno e aconchegante, o hotel oferece quartos confortáveis e bem equipados. Além disso, conta com um restaurante que serve pratos típicos da culinária regional, proporcionando uma experiência gastronômica única aos hóspedes.",
                    Diaria = 250,
                    Ocupacao = 4,
                    Area = 800,
                    ImagemUrl = "https://static.showit.co/1200/8n7f7DqLRpG2flPGfuDCEA/72275/gina_and_ryan_photography_-_acre_2017_-_115_web.jpg",
                    Servicos = "",
                    DataCriacao = DateTime.Now
                },
                new Hotel

                {
                    Id = 5,
                    Nome = "Brasiléia Hotel",
                    Descricao = "Situado na cidade de Brasileia, Acre, este hotel é ideal para quem busca um ambiente mais urbano e conectado. Com quartos modernos e bem equipados, o hotel oferece uma excelente estrutura para quem está a negócios ou lazer. Além disso, conta com uma localização privilegiada, próximo a restaurantes, bares e lojas, tornando a estadia ainda mais prática e conveniente.",
                    Diaria = 300,
                    Ocupacao = 4,
                    Area = 400,
                    ImagemUrl = "https://www.travelandleisure.com/thmb/C9j_ENR2mCCTAKr64UGCJY-ZLsM=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/bedroom-acre-baja-CABOHOTELMEZCAL0721-e39f5592b7fd45d6923018edd02d22ef.jpg",
                    Servicos = "",
                    DataCriacao = DateTime.Now
                });
        }
    }
}
