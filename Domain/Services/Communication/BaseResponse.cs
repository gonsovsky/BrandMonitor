using System;

namespace BrandMonitor.API.Domain.Services.Communication
{
    public abstract class BaseResponse<T>
    {
        public Guid ObjectId { get; private set; }
        public T Resource { get; private set; }

        protected BaseResponse(T resource)
        {
            Resource = resource;
        }

        protected BaseResponse(Guid objectId)
        {
            ObjectId = objectId;
        }
    }
}