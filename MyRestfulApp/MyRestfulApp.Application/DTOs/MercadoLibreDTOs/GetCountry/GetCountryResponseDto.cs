﻿namespace MyRestfulApp.Application.DTOs.MercadoLibreDTOs.GetCountry
{
    /// <summary>
    /// DTO del response del método GetCountry
    /// </summary>
    public class GetCountryResponseDto
    {
        /// <summary>
        /// Pais
        /// </summary>
        public CountryDto Country { get; set; }
    }
}