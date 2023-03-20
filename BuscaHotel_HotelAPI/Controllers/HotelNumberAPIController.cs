﻿using AutoMapper;
using BuscaHotel_HotelAPI.Data;
using BuscaHotel_HotelAPI.Logging;
using BuscaHotel_HotelAPI.Models;
using BuscaHotel_HotelAPI.Models.Dto;
using BuscaHotel_HotelAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace BuscaHotel_HotelAPI.Controllers
{
    [Route("api/HotelNumberAPI")]
    [ApiController]
    public class HotelNumberAPIController : ControllerBase
    {
        private readonly ILogging _logger;

        protected APIResponse _response;
        private readonly IHotelNumberRepository _dbHotelNumber;
        private readonly IMapper _mapper;

        public HotelNumberAPIController(IHotelNumberRepository dbHotelNumber, ILogging logger, IMapper mapper)
        {
            _dbHotelNumber = dbHotelNumber;
            _logger = logger;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<APIResponse>> GetHotelNumbers()
        {
            try
            {
                _logger.Log("Exibindo todos os hoteis", "");
                IEnumerable<HotelNumber> hotelNumberList = await _dbHotelNumber.GetAllAsync();
                _response.Result = _mapper.Map<List<HotelNumberDTO>>(hotelNumberList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpGet("{id:int}", Name = "GetHotelNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> GetHotelNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Tente um Id diferente de " + id, "error");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var hotelNumber = await _dbHotelNumber.GetAsync(u => u.HotelNo == id);
                if (hotelNumber == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<HotelNumberDTO>(hotelNumber);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> CreateHotelNumber([FromBody] HotelNumberCreateDTO createDTO)
        {
            try
            {
                if (await _dbHotelNumber.GetAsync(u => u.HotelNo == createDTO.HotelNo) != null)
                {
                    ModelState.AddModelError("CustomError", "Numero de Hotel já existe!");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                HotelNumber hotelNumber = _mapper.Map<HotelNumber>(createDTO);

                await _dbHotelNumber.CreateAsync(hotelNumber);

                _response.Result = _mapper.Map<HotelNumberDTO>(hotelNumber);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetHotel", new { id = hotelNumber.HotelNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteHotelNumber")]

        public async Task<ActionResult<APIResponse>> DeleteHotelNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var hotelNumber = await _dbHotelNumber.GetAsync(u => u.HotelNo == id);
                if (hotelNumber == null)
                {
                    return NotFound();
                }
                await _dbHotelNumber.RemoveAsync(hotelNumber);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPut("{id:int}", Name = "UpdateHotelNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> UpdateHotelNumber(int id, [FromBody] HotelNumberUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.HotelNo)
                {
                    return BadRequest();
                }

                HotelNumber model = _mapper.Map<HotelNumber>(updateDTO);

                await _dbHotelNumber.UpdateAsync(model);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

    }
}
