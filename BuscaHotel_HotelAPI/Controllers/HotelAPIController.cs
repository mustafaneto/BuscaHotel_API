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
using System.Reflection.Metadata.Ecma335;

namespace BuscaHotel_HotelAPI.Controllers
{
    [Route("api/HotelAPI")]
    [ApiController]
    public class HotelAPIController : ControllerBase
    {
        private readonly ILogging _logger;

        private readonly IHotelRepository _dbHotel;
        private readonly IMapper _mapper;

        public HotelAPIController(IHotelRepository dbHotel, ILogging logger, IMapper mapper)
        {
            _dbHotel = dbHotel;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult <IEnumerable<HotelDTO>>> GetHoteis()
        {
                _logger.Log("Exibindo todos os hoteis", "");
                IEnumerable<Hotel> hotelList = await _dbHotel.GetAllAsync();
                return Ok (_mapper.Map<List<HotelDTO>>(hotelList));
        }

        [HttpGet("{id:int}", Name = "CreateHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult <HotelDTO>> GetHotel(int id)
        {
            if (id == 0)
            {
                _logger.Log("Tente um Id diferente de " + id, "error" );
                return BadRequest();
            }

            var hotel = await _dbHotel.GetAsync(u => u.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<HotelDTO>(hotel));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<HotelDTO>> CreateHotel([FromBody]HotelCreateDTO createDTO) 
        {

            if(await _dbHotel.GetAsync(u=>u.Nome.ToLower()== createDTO.Nome.ToLower())!=null)
            {
                ModelState.AddModelError("CustomError", "Hotel já existe!");
                return BadRequest(ModelState);
            }
            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }

            Hotel model = _mapper.Map<Hotel>(createDTO);

            await _dbHotel.CreateAsync(model);

            return CreatedAtRoute("CreateHotel", new { id = model.Id } , model);

        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteHotel")]

        public async Task<IActionResult> DeleteHotel(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var hotel = await _dbHotel.GetAsync(u => u.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }
            await _dbHotel.RemoveAsync(hotel);
            return NoContent();
        }


        [HttpPut("{id:int}", Name = "UpdateHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateHotel(int id, [FromBody] HotelUpdateDTO updateDTO)
        {
            if (updateDTO == null || id != updateDTO.Id)
            {
                return BadRequest();
            }

            Hotel model = _mapper.Map<Hotel>(updateDTO);

            await _dbHotel.UpdateAsync(model);

            return NoContent();
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
            var hotel = await _dbHotel.GetAsync(u => u.Id == id, tracked:false);

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
