using AutoMapper;
using BuscaHotel_HotelAPI.Data;
using BuscaHotel_HotelAPI.Logging;
using BuscaHotel_HotelAPI.Models;
using BuscaHotel_HotelAPI.Models.Dto;
using BuscaHotel_HotelAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace BuscaHotel_HotelAPI.Controllers.v1
{
    [Route("api/v{version:apiVersion}/HotelAPI")]
    [ApiController]
    [ApiVersion("1.0")]
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
            _response = new();
        }

        [HttpGet]
        //[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [ResponseCache(CacheProfileName = "Default30")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<APIResponse>> GetHoteis([FromQuery(Name = "filtroOcupacao")]int? ocupacao, [FromQuery] string? search)
        {
            try
            {
                _logger.Log("Exibindo todos os hoteis", "");
                IEnumerable<Hotel> hotelList;
                
                if(ocupacao > 0)
                {
                    hotelList = await _dbHotel.GetAllAsync(u => u.Ocupacao == ocupacao);
                }
                else
                {
                    hotelList = await _dbHotel.GetAllAsync();
                }

                if (!string.IsNullOrEmpty(search))
                {
                    hotelList = hotelList.Where(u => u.Descricao.ToLower().Contains(search) || u.Nome.ToLower().Contains(search));
                }
              
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
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(Duration = 30)]

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
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> CreateHotel([FromBody] HotelCreateDTO createDTO)
        {
            try
            {
                if (await _dbHotel.GetAsync(u => u.Nome.ToLower() == createDTO.Nome.ToLower()) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Hotel já existe!");
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
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteHotel")]
        [Authorize(Roles = "admin")]

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


        [Authorize(Roles = "admin")]
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
