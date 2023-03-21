using System.ComponentModel.DataAnnotations;

namespace BuscaHotel_Web.Models.Dto
{
    public class HotelNumberUpdateDTO
    {
        [Required]
        public int HotelNo { get; set; }

        [Required]
        public int HotelID { get; set; }
        public string DetalhesEspeciais { get; set; }
    }
}
