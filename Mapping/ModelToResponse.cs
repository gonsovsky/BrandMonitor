using AutoMapper;
using BrandMonitor.API.Domain.Models;
using BrandMonitor.API.Domain.Responses;
using BrandMonitor.API.Helpers;

namespace BrandMonitor.API.Mapping
{
    public class ModelToResponse : Profile
    {
        public ModelToResponse()
        {
            CreateMap<BrandTask, TaskResponse>()
                .ForMember(src => src.Status,
                           opt => opt.MapFrom(src => src.Status.ToDescriptionString()))
                .ForMember(src => src.TimeStamp,
                            opt => opt.MapFrom(src => src.TimeStamp.ToISO8601())
                            );
        }
    }
}