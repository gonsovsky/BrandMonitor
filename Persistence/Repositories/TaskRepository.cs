using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BrandMonitor.API.Domain.Models;
using BrandMonitor.API.Domain.Repositories;
using BrandMonitor.API.Persistence.Contexts;
using System;

namespace BrandMonitor.API.Persistence.Repositories
{
    public class TaskRepository : BaseRepository, ITaskRepository
	{
		public TaskRepository(AppDbContext context) : base(context) { }

		public async Task<Guid> AddAsync()
		{
			var newTask = new BrandTask() {Id= new Guid()};
			var result= await _context.Tasks.AddAsync(newTask);
			return result.Entity.Id;
		}

		public async Task<BrandTask> FindByIdAsync(Guid id)
		{
			return await _context.Tasks
								 .FirstOrDefaultAsync(p => p.Id == id);
		}

	}
}