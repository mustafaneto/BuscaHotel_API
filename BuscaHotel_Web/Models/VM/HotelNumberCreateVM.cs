using BuscaHotel_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BuscaHotel_Web.Models.VM
{
    public class HotelNumberCreateVM
    {
        public HotelNumberCreateVM() 
        {
            HotelNumber = new HotelNumberCreateDTO();
        }
        public HotelNumberCreateDTO HotelNumber { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> HotelList { get; set; }
    }
}
