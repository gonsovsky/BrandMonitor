using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrandMonitor.API.Domain.Models;
using BrandMonitor.API.Domain.Services.Communication;

namespace BrandMonitor.API.Domain.Services
{
    public interface ITaskService
    {
        Task<TaskResponse> PostAsync();
        Task<TaskResponse> GetAsync(Guid id);
    }
}