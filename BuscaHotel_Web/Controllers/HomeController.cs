using AutoMapper;
using BuscaHotel_Utility;
using BuscaHotel_Web.Models;
using BuscaHotel_Web.Models.Dto;
using BuscaHotel_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BuscaHotel_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HomeController(IHotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<HotelDTO> list = new();

            var response = await _hotelService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<HotelDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

    }
}