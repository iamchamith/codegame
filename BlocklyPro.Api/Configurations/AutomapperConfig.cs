using AutoMapper;
using BlocklyPro.Api.Model.Game;
using BlocklyPro.Api.Model.Identity;
using BlocklyPro.Api.Model.Play;
using BlocklyPro.Core.AppService.Dto.GameDto;
using BlocklyPro.Core.AppService.Dto.Play;
using BlocklyPro.Core.AppService.Dto.UserDto;
using BlocklyPro.Core.Domain;
using BlocklyPro.Core.Domain.Play;

namespace BlocklyPro.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<RegisterModel, RegisterDto>().ReverseMap();
            CreateMap<LoginModel, LoginDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserDto, UserModel>().ReverseMap();
            CreateMap<GameModel, GameDto>().ReverseMap();
            CreateMap<Game, GameDto>().ReverseMap();
            CreateMap<GameMapModel, GameMapDto>().ReverseMap();
            CreateMap<GameMapDto, GameMap>().ReverseMap();

            CreateMap<GameCodeDto, GameCodeModel>().ReverseMap();
            CreateMap<PlayGameDto, PlayGameModel>().ReverseMap();
            CreateMap<GameCodeDto, GameCode>().ReverseMap();
            CreateMap<PlayGameDto, PlayGame>().ReverseMap();
        }
    }
}
