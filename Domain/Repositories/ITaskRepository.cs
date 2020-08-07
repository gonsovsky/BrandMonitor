using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrandMonitor.API.Domain.Models;

namespace BrandMonitor.API.Domain.Repositories
{
    public interface ITaskRepository
    {
        Task<Guid> AddAsync();
        Task<BrandTask> FindByIdAsync(Guid id);
    }
}