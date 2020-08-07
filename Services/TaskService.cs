using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using BrandMonitor.API.Domain.Models;
using BrandMonitor.API.Domain.Repositories;
using BrandMonitor.API.Domain.Services;
using BrandMonitor.API.Domain.Services.Communication;
using System.Collections.Generic;

namespace BrandMonitor.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskResponse> PostAsync()
        {
            try
            {
                var id = await _taskRepository.AddAsync();

                return new TaskResponse(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TaskResponse> GetAsync(Guid id)
        {
            var existingTask = await _taskRepository.FindByIdAsync(id);

                return new TaskResponse(existingTask.Id);
        }
    }
}