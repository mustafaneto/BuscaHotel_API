using BuscaHotel_Utility;
using BuscaHotel_Web.Models;
using BuscaHotel_Web.Models.Dto;
using BuscaHotel_Web.Services.IServices;

namespace BuscaHotel_Web.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string hotelUrl;

        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            hotelUrl = configuration.GetValue<string>("ServiceUrls:HotelAPI");
        }

        public Task<T> LoginAsync<T>(LoginRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = hotelUrl + "/api/UserAuth/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegistrationRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = hotelUrl + "/api/UserAuth/register"
            });
        }
    }
}
