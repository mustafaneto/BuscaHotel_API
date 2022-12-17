using System.ComponentModel.DataAnnotations;

namespace BuscaHotel_HotelAPI.Models.Dto
{
    public class HotelDTO
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }
    }
}
