using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace BuscaHotel_HotelAPI.Models
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Diaria { get; set; }
        public int Area { get; set; }
        public int Ocupacao { get; set; }
        public string ImagemUrl { get; set; }
        public string Servicos { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
