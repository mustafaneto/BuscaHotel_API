using Microsoft.AspNetCore.Identity;

namespace BuscaHotel_HotelAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
