using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace BuscaHotel_HotelAPI.Models
{
    public class HotelNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HotelNo { get; set; }

        [ForeignKey("Hotel")]
        public int HotelID { get; set; }
        public Hotel Hotel { get; set; }

        public string DetalhesEspeciais { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
