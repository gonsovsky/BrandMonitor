using AutoMapper;
using BrandMonitor.API.Domain.Models;
using BrandMonitor.API.Resources;

namespace BrandMonitor.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveTaskResource, BrandTask>()
                .ForMember(src => src.UnitOfMeasurement, opt => opt.MapFrom(src => (EUnitOfMeasurement)src.UnitOfMeasurement));

            CreateMap<TasksQueryResource, TasksQuery>();
        }
    }
}