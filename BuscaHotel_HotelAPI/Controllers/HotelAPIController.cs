using BuscaHotel_HotelAPI.Data;
using BuscaHotel_HotelAPI.Models;
using BuscaHotel_HotelAPI.Models.Dto;
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

    }
}
