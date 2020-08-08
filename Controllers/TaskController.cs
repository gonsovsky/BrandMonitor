using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BrandMonitor.API.Domain.Models;
using BrandMonitor.API.Domain.Services;
using System;
using System.Net;
using BrandMonitor.API.Domain.Responses;

namespace BrandMonitor.API.Controllers
{
    [Route("/task")]
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
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> PostAsync()
        {
            var result = await _taskService.PostAsync();
            return Accepted(result);
        }

        /// <summary>
        /// Получить информацию о задании по ID
        /// </summary>
        /// <param name="id">ID задания</param>
        /// <returns>Информация о задании</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TaskResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _taskService.GetAsync(id);
            if (result == null)
                return NotFound(new ErrorResponse(null));
            var taskResponse = _mapper.Map<BrandTask, TaskResponse>(result);
            return Ok(taskResponse);

        }
    }
}