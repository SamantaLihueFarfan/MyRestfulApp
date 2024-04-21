namespace MyRestfulApp.Application.Mapper
{
    using DTOs.MyRestfulAppDTOs.GetUser;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.GetUser;
    using DTOs.MyRestfulAppDTOs.DeleteUser;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.DeleteUser;
    using AutoMapper;
    using DTOs.MercadoLibreDTOs;
    using Domain.Models.Entities.MercadoLibre;
    using DTOs.MyRestfulAppDTOs.SaveUser;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.SaveUser;
    using DTOs.MyRestfulAppDTOs.UpdateUser;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.UpdateUser;
    using DTOs.MyRestfulAppDTOs;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region MercadoLibre

            CreateMap<CountryDto, Country>().ReverseMap();
            CreateMap<GeoInformationDto, Geo_information>().ReverseMap();
            CreateMap<LocationDto, Location>().ReverseMap();
            CreateMap<StatesDto, States>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<PagingDto, Paging>().ReverseMap();
            CreateMap<ResultsDto, Results>().ReverseMap();
            CreateMap<SellerDto, Seller>().ReverseMap();
            CreateMap<CurrencyConversionDto, CurrencyConversion>().ReverseMap();
            CreateMap<CurrencyDto, Currency>().ReverseMap();
            
            #endregion

            #region MyRestfulApp

            CreateMap<SaveUserRequestDto, SaveUserRequest>().ReverseMap();
            CreateMap<DeleteUserRequestDto, DeleteUserRequest>().ReverseMap();
            CreateMap<UpdateUserRequestDto, UpdateUserRequest>().ReverseMap();
            CreateMap<GetUserRequestDto, GetUserRequest>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();

            #endregion
        }
    }
}