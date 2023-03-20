using System.ComponentModel.DataAnnotations;

namespace BuscaHotel_HotelAPI.Models.Dto
{
    public class HotelNumberCreateDTO
    {
        [Required]
        public int HotelNo { get; set; }

        [Required]
        public int HotelID { get; set; }

        public string DetalhesEspeciais { get; set; }
    }
}
