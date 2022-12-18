using BuscaHotel_HotelAPI.Data;
using BuscaHotel_HotelAPI.Models;
using BuscaHotel_HotelAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BuscaHotel_HotelAPI.Controllers
{
    [Route("api/HotelAPI")]
    [ApiController]
    public class HotelAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult <IEnumerable<HotelDTO>> GetHoteis()
        {
                return Ok (HotelStore.hotelList);
        }

        [HttpGet("{id:int}", Name = "CreateHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult <HotelDTO> GetHotel(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var hotel = HotelStore.hotelList.FirstOrDefault(u => u.Id == id);
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

            if(HotelStore.hotelList.FirstOrDefault(u=>u.Nome.ToLower()==hotelDTO.Nome.ToLower())!=null)
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
            hotelDTO.Id = HotelStore.hotelList.OrderByDescending(u => u.Id).FirstOrDefault().Id+1;
            HotelStore.hotelList.Add(hotelDTO);

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
            var hotel = HotelStore.hotelList.FirstOrDefault(u => u.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }
            HotelStore.hotelList.Remove(hotel);
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
            var hotel = HotelStore.hotelList.FirstOrDefault(u => u.Id == id);
            hotel.Nome = hotelDTO.Nome;
            hotel.Diaria = hotelDTO.Diaria;
            hotel.Endereco = hotelDTO.Endereco;

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
            var hotel = HotelStore.hotelList.FirstOrDefault(u => u.Id == id);
            if (hotel == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(hotel, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }

    }
}
