
using AutoMapper;
using FloritasStore.Models.Users;
using FloritasStore.ViewModels.Users;
using Microsoft.CodeAnalysis.Differencing;

namespace FloritasStore.Controllers.Mappings
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<ApplicationUser, RegisterViewModel>().ReverseMap();
            CreateMap<ApplicationUser, EditUserViewModel>().ReverseMap();
            CreateMap<ApplicationUser, UserDetailsViewModel>().ReverseMap();
        }
    }
}
