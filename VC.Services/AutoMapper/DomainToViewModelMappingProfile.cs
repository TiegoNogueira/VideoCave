using AutoMapper;
using VC.Domain.Models;
using VC.Services.Models;

namespace VC.Services.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Video, VideoViewModel>();
        }
    }
}