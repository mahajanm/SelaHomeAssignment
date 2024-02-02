using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sela.Task.API.CustomFilters;
using Sela.Task.API.Exceptions;
using Sela.Task.API.Models.Domain;
using Sela.Task.API.Models.DTO;
using Sela.Task.API.Repositories.Interface;

namespace Sela.Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskDetailsController : ControllerBase
    {
        private readonly ITaskDetailRepository taskDetailRepository;
        private readonly IMapper mapper;

        public TaskDetailsController(ITaskDetailRepository taskDetailRepository, IMapper mapper)
        {
            this.taskDetailRepository = taskDetailRepository;
            this.mapper = mapper;
        }


        // GET: https://localhost:portnumber/api/TaskDetails
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var taskDetailDomain = await taskDetailRepository.GetAllAsync();

            return Ok(mapper.Map<List<TaskDetailDto>>(taskDetailDomain));
        }

        // GET: https://localhost:portnumber/api/TaskDetails/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get TaskDetail Domain Model From Database
            var TaskDetailDomain = await taskDetailRepository.GetByIdAsync(id);

            if (TaskDetailDomain == null)
            {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(mapper.Map<TaskDetailDto>(TaskDetailDomain));
        }

        // POST: https://localhost:portnumber/api/taskDetails
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddTaskDetailRequestDto addTaskDetailRequestDto)
        {
            try
            {
                // Map or Convert DTO to Domain Model
                var taskDetailDomainModel = mapper.Map<TaskDetail>(addTaskDetailRequestDto);

                // Use Domain Model to create taskDetail
                taskDetailDomainModel = await taskDetailRepository.CreateAsync(taskDetailDomainModel);

                // Map Domain model back to DTO
                var taskDetailDto = mapper.Map<TaskDetailDto>(taskDetailDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = taskDetailDto.Id }, taskDetailDto);
            }
            catch (DuplicateTaskDetailException ex)
            {
                return BadRequest("A task with the specified details already exists.");
            }
            catch (Exception ex)
            {
                //log exception in logger

                return StatusCode(500, "An error occurred while processing your request. Please try again later.");
            }

        }

        // PUT: https://localhost:portnumber/api/TaskDetails/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTaskDetailRequestDto updateTaskDetailRequestDto)
        {
            //Check Id passed in route is matching with Id passed in Body
            if (id != updateTaskDetailRequestDto.Id)
            {
                return BadRequest("Invalid details provided");
            }
            // Map DTO to Domain Model
            var TaskDetailDomainModel = mapper.Map<TaskDetail>(updateTaskDetailRequestDto);

            // Check if TaskDetail exists
            TaskDetailDomainModel = await taskDetailRepository.UpdateAsync(id, TaskDetailDomainModel);

            if (TaskDetailDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TaskDetailDto>(TaskDetailDomainModel));
        }


        // DELETE: https://localhost:portnumber/api/TaskDetails/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var TaskDetailDomainModel = await taskDetailRepository.DeleteAsync(id);

            if (TaskDetailDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TaskDetailDto>(TaskDetailDomainModel));
        }
    }


}
