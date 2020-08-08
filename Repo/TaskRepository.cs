using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BrandMonitor.API.Domain.Models;
using System;
using BrandMonitor.API.Domain.Services;
using TaskStatus = BrandMonitor.API.Domain.Models.TaskStatus;

namespace BrandMonitor.API.Persistence
{
    public class TaskRepository : ITaskRepository
	{
		protected readonly AppDbContext _context;

		public TaskRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Guid> AddAsync()
		{
			var newTask = new BrandTask() {Status= TaskStatus.Created, TimeStamp = DateTime.Now};
			var result= await _context.Tasks.AddAsync(newTask);
			await _context.SaveChangesAsync();
			return result.Entity.Id;
		}

        public async Task<BrandTask> ChangeStatus(Guid id, TaskStatus newStatus)
        {
			var found = await FindByIdAsync(id);
			found.Status = newStatus;
			found.TimeStamp = DateTime.Now;
			await _context.SaveChangesAsync();
			return found;
        }

        public async Task<BrandTask> FindByIdAsync(Guid id)
		{
			var q = await _context.Tasks.ToListAsync();
			var result = await _context.Tasks
								 .FirstOrDefaultAsync(p => p.Id.Equals(id));
			return result;
		}
	}
}