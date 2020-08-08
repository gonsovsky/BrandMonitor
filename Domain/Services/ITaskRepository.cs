using System;
using System.Threading.Tasks;
using BrandMonitor.API.Domain.Models;
using TaskStatus = BrandMonitor.API.Domain.Models.TaskStatus;

namespace BrandMonitor.API.Domain.Services
{
    public interface ITaskRepository
    {
        Task<Guid> AddAsync();
        Task<BrandTask> FindByIdAsync(Guid id);
        Task<BrandTask> ChangeStatus(Guid id, TaskStatus newStatus);
    }
}