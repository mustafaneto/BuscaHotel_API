using AutoMapper;
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
    [Route("api/HotelAPI")]
    [ApiController]
    public class HotelAPIController : ControllerBase
    {
        private readonly ILogging _logger;

        protected APIResponse _response;
        private readonly IHotelRepository _dbHotel;
        private readonly IMapper _mapper;

        public HotelAPIController(IHotelRepository dbHotel, ILogging logger, IMapper mapper)
        {
            _dbHotel = dbHotel;
            _logger = logger;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<APIResponse>> GetHoteis()
        {
            try
            {
                _logger.Log("Exibindo todos os hoteis", "");
                IEnumerable<Hotel> hotelList = await _dbHotel.GetAllAsync();
                _response.Result = _mapper.Map<List<HotelDTO>>(hotelList);
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

        [HttpGet("{id:int}", Name = "GetHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> GetHotel(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Tente um Id diferente de " + id, "error");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var hotel = await _dbHotel.GetAsync(u => u.Id == id);
                if (hotel == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<HotelDTO>(hotel);
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

        public async Task<ActionResult<APIResponse>> CreateHotel([FromBody] HotelCreateDTO createDTO)
        {
            try
            {
                if (await _dbHotel.GetAsync(u => u.Nome.ToLower() == createDTO.Nome.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomError", "Hotel já existe!");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Hotel hotel = _mapper.Map<Hotel>(createDTO);

                await _dbHotel.CreateAsync(hotel);

                _response.Result = _mapper.Map<HotelDTO>(hotel);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetHotel", new { id = hotel.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteHotel")]

        public async Task<ActionResult<APIResponse>> DeleteHotel(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var hotel = await _dbHotel.GetAsync(u => u.Id == id);
                if (hotel == null)
                {
                    return NotFound();
                }
                await _dbHotel.RemoveAsync(hotel);
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


        [HttpPut("{id:int}", Name = "UpdateHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> UpdateHotel(int id, [FromBody] HotelUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }

                Hotel model = _mapper.Map<Hotel>(updateDTO);

                await _dbHotel.UpdateAsync(model);

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

        [HttpPatch("{id:int}", Name = "UpdatePartialHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdatePartialHotel(int id, JsonPatchDocument<HotelUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var hotel = await _dbHotel.GetAsync(u => u.Id == id, tracked: false);

            HotelUpdateDTO hotelDTO = _mapper.Map<HotelUpdateDTO>(hotel);

            if (hotel == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(hotelDTO, ModelState);

            Hotel model = _mapper.Map<Hotel>(hotelDTO);

            await _dbHotel.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }

    }
}
