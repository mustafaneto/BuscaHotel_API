using AutoMapper;
using BuscaHotel_Web.Models;
using BuscaHotel_Web.Models.Dto;
using BuscaHotel_Web.Services;
using BuscaHotel_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BuscaHotel_Web.Controllers
{
    public class HotelNumberController : Controller
    {
        private readonly IHotelNumberService _hotelNumberService;
        private readonly IMapper _mapper;

        public HotelNumberController(IHotelNumberService hotelNumberService, IMapper mapper)
        {
            _hotelNumberService = hotelNumberService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexHotelNumber()
        {
            List<HotelNumberDTO> list = new();

            var response = await _hotelNumberService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<HotelNumberDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
    }
}
