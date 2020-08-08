using BrandMonitor.API.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BrandMonitor.API.Services
{
    public class TaskHostedService : IHostedService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly TaskOptions _opts;

        public TaskHostedService(IServiceProvider serviceProvider, IOptions<TaskOptions> opts)
        {
            var scope = serviceProvider.CreateScope();
            _taskRepository = scope.ServiceProvider.GetRequiredService<ITaskRepository>();
            _opts = opts.Value;
        }

        public void RunTask(Guid id)
        {
            _ = Task.Factory.StartNew( async  () =>
            {
                await _taskRepository.ChangeStatus(id, Domain.Models.TaskStatus.Running);
                await Task.Delay(_opts.Interval);
                await _taskRepository.ChangeStatus(id, Domain.Models.TaskStatus.Finished);
            }
            ,TaskCreationOptions.LongRunning
            );
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}