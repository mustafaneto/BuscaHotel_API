using AutoMapper;
using BuscaHotel_Utility;
using BuscaHotel_Web.Models;
using BuscaHotel_Web.Models.Dto;
using BuscaHotel_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
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

            var response = await _hotelService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<HotelDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateHotel()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateHotel(HotelCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _hotelService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Hotel criado com sucesso";
                    return RedirectToAction(nameof(IndexHotel));
                }
            }
            TempData["error"] = "Erro encontrado";
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateHotel(int hotelId)
        {
            var response = await _hotelService.GetAsync<APIResponse>(hotelId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                HotelDTO model = JsonConvert.DeserializeObject<HotelDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<HotelUpdateDTO>(model));
            }

            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> UpdateHotel(HotelUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Hotel atualizado com sucesso";
                var response = await _hotelService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexHotel));
                }
            }

            TempData["error"] = "Erro encontrado";
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteHotel(int hotelId)
        {
            var response = await _hotelService.GetAsync<APIResponse>(hotelId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                HotelDTO model = JsonConvert.DeserializeObject<HotelDTO>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteHotel(HotelDTO model)
        {
            
                var response = await _hotelService.DeleteAsync<APIResponse>(model.Id, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Hotel deletado com sucesso";
                    return RedirectToAction(nameof(IndexHotel));
                }
            TempData["error"] = "Erro encontrado";

            return View(model);
        }

    }
}
