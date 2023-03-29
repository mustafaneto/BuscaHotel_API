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
using System.Data;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace BuscaHotel_HotelAPI.Controllers.v2
{
    [Route("api/v{version:apiVersion}/HotelNumberAPI")]
    [ApiController]
    [ApiVersion("2.0")]

    public class HotelNumberAPIController : ControllerBase
    {
        private readonly ILogging _logger;

        protected APIResponse _response;
        private readonly IHotelNumberRepository _dbHotelNumber;
        private readonly IHotelRepository _dbHotel;
        private readonly IMapper _mapper;

        public HotelNumberAPIController(IHotelNumberRepository dbHotelNumber, ILogging logger, IMapper mapper, IHotelRepository dbHotel)
        {
            _dbHotelNumber = dbHotelNumber;
            _logger = logger;
            _mapper = mapper;
            _response = new();
            _dbHotel = dbHotel;
        }

        //[MapToApiVersion("2.0")]
        [HttpGet("GetString")]

        public IEnumerable<string> Get()
        {
            return new string[] { "Mustafa", "Ribeiro" };
        }

    }
}
