using System;
using System.Threading.Tasks;
using BrandMonitor.API.Domain.Models;

namespace BrandMonitor.API.Domain.Services
{
    public interface ITaskService
    {
        Task<Guid> PostAsync();
        Task<BrandTask> GetAsync(Guid id);
    }
}