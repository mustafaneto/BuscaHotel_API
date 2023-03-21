using System.ComponentModel.DataAnnotations;

namespace BuscaHotel_Web.Models.Dto
{
    public class HotelUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [Required]
        public double Diaria { get; set; }
        [Required]
        public int Ocupacao { get; set; }
        [Required]
        public int Area { get; set; }
        [Required]
        public string ImagemUrl { get; set; }
        public string Servicos { get; set; }
    }
}
