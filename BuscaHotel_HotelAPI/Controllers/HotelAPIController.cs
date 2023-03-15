using BuscaHotel_HotelAPI.Data;
using BuscaHotel_HotelAPI.Logging;
using BuscaHotel_HotelAPI.Models;
using BuscaHotel_HotelAPI.Models.Dto;
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
        private readonly ApplicationDbContext _db;

        public HotelAPIController(ApplicationDbContext db, ILogging logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult <IEnumerable<HotelDTO>> GetHoteis()
        {
                _logger.Log("Exibindo todos os hoteis", "");
                return Ok (_db.Hoteis.ToList());
        }

        [HttpGet("{id:int}", Name = "CreateHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult <HotelDTO> GetHotel(int id)
        {
            if (id == 0)
            {
                _logger.Log("Tente um Id diferente de " + id, "error" );
                return BadRequest();
            }

            var hotel = _db.Hoteis.FirstOrDefault(u => u.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<HotelDTO> CreateHotel([FromBody]HotelDTO hotelDTO) 
        {

            if(_db.Hoteis.FirstOrDefault(u=>u.Nome.ToLower()==hotelDTO.Nome.ToLower())!=null)
            {
                ModelState.AddModelError("CustomError", "Hotel já existe!");
                return BadRequest(ModelState);
            }
            if (hotelDTO == null)
            {
                return BadRequest(hotelDTO);
            }
            if (hotelDTO.Id > 0) 
            { 
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Hotel model = new()
            {
                Servicos = hotelDTO.Servicos,
                Descricao = hotelDTO.Descricao,
                Id = hotelDTO.Id,
                ImagemUrl = hotelDTO.ImagemUrl,
                Nome = hotelDTO.Nome,
                Ocupacao = hotelDTO.Ocupacao,
                Diaria = hotelDTO.Diaria,
                Area = hotelDTO.Area
            };
            _db.Hoteis.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("CreateHotel", new { id = hotelDTO.Id } , hotelDTO);

        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteHotel")]

        public IActionResult DeleteHotel(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var hotel = _db.Hoteis.FirstOrDefault(u => u.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }
            _db.Hoteis.Remove(hotel);
            _db.SaveChanges();
            return NoContent();
        }


        [HttpPut("{id:int}", Name = "UpdateHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateHotel(int id, [FromBody]HotelDTO hotelDTO)
        {
            if (hotelDTO == null || id != hotelDTO.Id)
            {
                return BadRequest();
            }

            Hotel model = new()
            {
                Servicos = hotelDTO.Servicos,
                Descricao = hotelDTO.Descricao,
                Id = hotelDTO.Id,
                ImagemUrl = hotelDTO.ImagemUrl,
                Nome = hotelDTO.Nome,
                Ocupacao = hotelDTO.Ocupacao,
                Diaria = hotelDTO.Diaria,
                Area = hotelDTO.Area
            };

            _db.Hoteis.Update(model);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdatePartialHotel(int id, JsonPatchDocument<HotelDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var hotel = _db.Hoteis.AsNoTracking().FirstOrDefault(u => u.Id == id);

            HotelDTO hotelDTO = new()
            {
                Servicos = hotel.Servicos,
                Descricao = hotel.Descricao,
                Id = hotel.Id,
                ImagemUrl = hotel.ImagemUrl,
                Nome = hotel.Nome,
                Ocupacao = hotel.Ocupacao,
                Diaria = hotel.Diaria,
                Area = hotel.Area
            };

            if (hotel == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(hotelDTO, ModelState);

            Hotel model = new Hotel()
            {
                Servicos = hotelDTO.Servicos,
                Descricao = hotelDTO.Descricao,
                Id = hotelDTO.Id,
                ImagemUrl = hotelDTO.ImagemUrl,
                Nome = hotelDTO.Nome,
                Ocupacao = hotelDTO.Ocupacao,
                Diaria = hotelDTO.Diaria,
                Area = hotelDTO.Area
            };

            _db.Hoteis.Update(model);
            _db.SaveChanges();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }

    }
}
