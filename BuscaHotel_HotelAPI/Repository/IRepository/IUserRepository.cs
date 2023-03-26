using BuscaHotel_HotelAPI.Models;
using BuscaHotel_HotelAPI.Models.Dto;

namespace BuscaHotel_HotelAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
