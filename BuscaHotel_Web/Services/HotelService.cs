using BuscaHotel_Utility;
using BuscaHotel_Web.Models;
using BuscaHotel_Web.Models.Dto;
using BuscaHotel_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BuscaHotel_Web.Services
{
    public class HotelService : BaseService, IHotelService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string hotelUrl;

        public HotelService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory) 
        {
            _clientFactory = clientFactory;
            hotelUrl = configuration.GetValue<string>("ServiceUrls:HotelAPI");
        }

        public Task<T> CreateAsync<T>(HotelCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = hotelUrl + "/api/hotelAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = hotelUrl + "/api/hotelAPI/"+id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = hotelUrl + "/api/hotelAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = hotelUrl + "/api/hotelAPI/" + id
            });
        }

        public Task<T> UpdateAsync<T>(HotelUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = hotelUrl + "/api/hotelAPI" + dto.Id
            });
        }
    }
}
