using AutoMapper;
using BuscaHotel_Web.Models;
using BuscaHotel_Web.Models.Dto;
using BuscaHotel_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BuscaHotel_Web.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HotelController(IHotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }   

        public async Task<IActionResult> IndexHotel()
        {
            List<HotelDTO> list = new();

            var response = await _hotelService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<HotelDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> CreateHotel()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateHotel(HotelCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _hotelService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexHotel));
                }
            }

            return View(model);
        }
    }
}
