﻿namespace BuscaHotel_HotelAPI.Models.Dto
{
    public class LoginResponseDTO
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
    }
}