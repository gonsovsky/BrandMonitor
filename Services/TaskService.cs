using System;
using System.Threading.Tasks;
using BrandMonitor.API.Domain.Models;
using BrandMonitor.API.Domain.Services;

namespace BrandMonitor.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly TaskHostedService _taskHostedService;

        public TaskService(ITaskRepository taskRepository, TaskHostedService taskHostedService)
        {
            _taskRepository = taskRepository;
            _taskHostedService = taskHostedService;
        }

        public async Task<Guid> PostAsync()
        {
            var id = await _taskRepository.AddAsync();
            _taskHostedService.RunTask(id);
            return id;
        }

        public async Task<BrandTask> GetAsync(Guid id)
        {
            return await _taskRepository.FindByIdAsync(id);
        }
    }
}