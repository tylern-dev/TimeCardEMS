using AutoMapper;
using TimeCard.Api.Core.Models;

namespace TimeCard.Api.External.Controllers.Auth.DTOs {

    public class AuthMappingProfile : Profile {
        public AuthMappingProfile() {
            // CreateMap<User, UserAndTokenResponse.UserAndTokenUserResponse>();
            CreateMap<RegisterRequest, User>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(i => i.Username));
        }
    }
}