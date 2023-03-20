using System.ComponentModel.DataAnnotations;

namespace BuscaHotel_HotelAPI.Models.Dto
{
    public class HotelNumberDTO
    {
        [Required]
        public int HotelNo { get; set; }

        public string DetalhesEspeciais { get; set; }
    }
}
