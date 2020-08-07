using AutoMapper;
using BrandMonitor.API.Domain.Models;
using BrandMonitor.API.Extensions;
using BrandMonitor.API.Resources;

namespace BrandMonitor.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<BrandTask, TaskResource>()
                .ForMember(src => src.UnitOfMeasurement,
                           opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));

            CreateMap<QueryResult<BrandTask>, QueryResultResource<TaskResource>>();
        }
    }
}