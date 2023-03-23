using BuscaHotel_Utility;
using BuscaHotel_Web.Models;
using BuscaHotel_Web.Models.Dto;
using BuscaHotel_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BuscaHotel_Web.Services
{
    public class HotelNumberService : BaseService, IHotelNumberService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string hotelUrl;

        public HotelNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory) 
        {
            _clientFactory = clientFactory;
            hotelUrl = configuration.GetValue<string>("ServiceUrls:HotelAPI");
        }

        public Task<T> CreateAsync<T>(HotelNumberCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = hotelUrl + "/api/hotelNumberAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = hotelUrl + "/api/hotelNumberAPI/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = hotelUrl + "/api/hotelNumberAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = hotelUrl + "/api/hotelNumberAPI/" + id
            });
        }

        public Task<T> UpdateAsync<T>(HotelNumberUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = hotelUrl + "/api/hotelNumberAPI/" + dto.HotelNo
            });
        }
    }
}
