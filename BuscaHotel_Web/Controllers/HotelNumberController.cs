using AutoMapper;
using BuscaHotel_Web.Models;
using BuscaHotel_Web.Models.Dto;
using BuscaHotel_Web.Models.VM;
using BuscaHotel_Web.Services;
using BuscaHotel_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BuscaHotel_Web.Controllers
{
    public class HotelNumberController : Controller
    {
        private readonly IHotelNumberService _hotelNumberService;
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HotelNumberController(IHotelNumberService hotelNumberService, IMapper mapper, IHotelService hotelService)
        {
            _hotelNumberService = hotelNumberService;
            _mapper = mapper;
            _hotelService = hotelService;
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

        public async Task<IActionResult> CreateHotelNumber()
        {
            HotelNumberCreateVM hotelNumberVM = new();
            var response = await _hotelService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                hotelNumberVM.HotelList = JsonConvert.DeserializeObject<List<HotelDTO>>
                    (Convert.ToString(response.Result)).Select(i=> new SelectListItem
                    {
                        Text = i.Nome,
                        Value = i.Id.ToString()
                    });
            }
            return View(hotelNumberVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateHotelNumber(HotelNumberCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _hotelNumberService.CreateAsync<APIResponse>(model.HotelNumber);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Número criado com sucesso";
                    return RedirectToAction(nameof(IndexHotelNumber));
                }
                else
                {
                    if(response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var resp = await _hotelService.GetAllAsync<APIResponse>();
            if (resp != null && resp.IsSuccess)
            {
                model.HotelList = JsonConvert.DeserializeObject<List<HotelDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Nome,
                        Value = i.Id.ToString()
                    });
            }

            TempData["error"] = "Erro encontrado";
            return View(model);
        }

        public async Task<IActionResult> UpdateHotelNumber(int hotelNo)
        {
            HotelNumberUpdateVM hotelNumberVM = new();
            var response = await _hotelNumberService.GetAsync<APIResponse>(hotelNo);
            if (response != null && response.IsSuccess)
            {
                HotelNumberDTO model = JsonConvert.DeserializeObject<HotelNumberDTO>(Convert.ToString(response.Result));
                hotelNumberVM.HotelNumber = _mapper.Map<HotelNumberUpdateDTO>(model);
            }

            response = await _hotelService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                hotelNumberVM.HotelList = JsonConvert.DeserializeObject<List<HotelDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Nome,
                        Value = i.Id.ToString()
                    });
                return View(hotelNumberVM);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> UpdateHotelNumber(HotelNumberUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Número atualizado com sucesso";
                var response = await _hotelNumberService.UpdateAsync<APIResponse>(model.HotelNumber);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexHotelNumber));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var resp = await _hotelService.GetAllAsync<APIResponse>();
            if (resp != null && resp.IsSuccess)
            {
                model.HotelList = JsonConvert.DeserializeObject<List<HotelDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Nome,
                        Value = i.Id.ToString()
                    });
            }

            TempData["error"] = "Erro encontrado";
            return View(model);
        }

        public async Task<IActionResult> DeleteHotelNumber(int hotelNo)
        {
            HotelNumberDeleteVM hotelNumberVM = new();
            var response = await _hotelNumberService.GetAsync<APIResponse>(hotelNo);
            if (response != null && response.IsSuccess)
            {
                HotelNumberDTO model = JsonConvert.DeserializeObject<HotelNumberDTO>(Convert.ToString(response.Result));
                hotelNumberVM.HotelNumber = model;
            }

            response = await _hotelService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                hotelNumberVM.HotelList = JsonConvert.DeserializeObject<List<HotelDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Nome,
                        Value = i.Id.ToString()
                    });
                return View(hotelNumberVM);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteHotelNumber(HotelNumberDeleteVM model)
        {

            var response = await _hotelNumberService.DeleteAsync<APIResponse>(model.HotelNumber.HotelNo);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Número deletado com sucesso";
                return RedirectToAction(nameof(IndexHotelNumber));
            }
            TempData["error"] = "Erro encontrado";

            return View(model);
        }
    }
}
