using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BrandMonitor.API.Domain.Models;
using BrandMonitor.API.Domain.Services;
using BrandMonitor.API.Resources;
using System.Collections.Generic;

namespace BrandMonitor.API.Controllers
{
    [Route("/api/tasks")]
    [Produces("application/json")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        /// <summary>
        /// Создать новое задание
        /// </summary>
        /// <returns>ID созданного задания</returns>
        [HttpPost]
        [ProducesResponseType(typeof(TaskResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync()
        {
            var task = _mapper.Map<SaveTaskResource, BrandTask>(resource);
            var result = await _taskService.PostAsync();

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var taskResource = _mapper.Map<BrandTask, TaskResource>(result.Resource);
            return Ok(taskResource);
        }

        /// <summary>
        /// Получить информацию о задании по ID
        /// </summary>
        /// <param name="id">ID задания</param>
        /// <returns>Информация о задании</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TaskResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var task = _mapper.Map<SaveTaskResource, BrandTask>(resource);
            var result = await _taskService.GetAsync(id, task);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var taskResource = _mapper.Map<BrandTask, TaskResource>(result.Resource);
            return Ok(taskResource);
        }
    }
}