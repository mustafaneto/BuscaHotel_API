using BuscaHotel_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BuscaHotel_Web.Models.VM
{
    public class HotelNumberDeleteVM
    {
        public HotelNumberDeleteVM() 
        {
            HotelNumber = new HotelNumberDTO();
        }
        public HotelNumberDTO HotelNumber { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> HotelList { get; set; }
    }
}
