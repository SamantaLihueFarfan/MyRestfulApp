namespace MyRestfulApp.Application.Mapper
{
    using AutoMapper;
    using DTOs.MercadoLibreDTOs;
    using Domain.Models.Entities.MercadoLibre;
    using MyRestfulApp.Application.DTOs.MyRestfulAppDTOs.SaveUser;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.SaveUser;
    using MyRestfulApp.Application.DTOs.MyRestfulAppDTOs.UpdateUser;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.UpdateUser;
    using MyRestfulApp.Application.DTOs.MyRestfulAppDTOs;
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
            CreateMap<SaveUserRequestDto, SaveUserRequest>().ReverseMap();
            CreateMap<UpdateUserRequestDto, UpdateUserRequest>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();

            #endregion
        }
    }
}