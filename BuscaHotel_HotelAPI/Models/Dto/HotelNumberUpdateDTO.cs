using System.ComponentModel.DataAnnotations;

namespace BuscaHotel_HotelAPI.Models.Dto
{
    public class HotelNumberUpdateDTO
    {
        [Required]
        public int HotelNo { get; set; }

        public string DetalhesEspeciais { get; set; }
    }
}
