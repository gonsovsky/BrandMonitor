using BrandMonitor.API.Domain.Models;
using System;

namespace BrandMonitor.API.Domain.Services.Communication
{
    public class TaskResponse : BaseResponse<BrandTask>
    {
        public TaskResponse(Guid taskGuid) : base(taskGuid) { }
    }
}