using AutoMapper;
using VC.Domain.Models;
using VC.Services.Models;

namespace VC.Services.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<VideoViewModel, Video>();
        }
    }
}