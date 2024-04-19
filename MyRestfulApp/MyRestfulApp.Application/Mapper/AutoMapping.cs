﻿namespace MyRestfulApp.Application.Mapper
{
    using AutoMapper;
    using DTOs.MercadoLibreDTOs;
    using Domain.Models.Entities.MercadoLibre;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region MercadoLibre

            CreateMap<CountryDto, Country>().ReverseMap();
            CreateMap<GeoInformationDto, Geo_information>().ReverseMap();
            CreateMap<LocationDto, Location>().ReverseMap();
            CreateMap<StatesDto, States>().ReverseMap();

            #endregion
        }
    }
}