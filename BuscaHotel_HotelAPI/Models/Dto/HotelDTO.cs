using System.ComponentModel.DataAnnotations;

namespace BuscaHotel_HotelAPI.Models.Dto
{
    public class HotelDTO
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [Required]
        public double Diaria { get; set; }
        public int Ocupacao { get; set; }
        public int Area { get; set; }
        public string ImagemUrl { get; set; }
        public string Servicos { get; set; }
    }
}
