using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Borganica.Models;
using Borganica.Services;
using Borganica.Dtos;
using System.Security.Claims;

namespace Borganica.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        public ProjectsController(
            IProjectsService service
        )
        {
            _service = service;
        }

        private readonly IProjectsService _service;

        // GET api/Projects
        [HttpGet]
        public async Task<IReadOnlyCollection<ProjectListItemResponseDto>> Get()
        {
            return (await _service.GetAll()).Select(p => p.ToDto()).ToList();
        }

        // GET api/Projects/State
        [HttpGet("State")]
        public async Task<IReadOnlyCollection<ModifyProjectStateResponseDto>> GetForClient()
        {
            return (await _service.GetAll()).Select(p => p.ToClientDto()).ToList();
        }

        // GET api/Projects/5
        [HttpGet("{id}")]
        public async Task<ProjectListItemResponseDto> Get(int id)
        {
            return (await _service.GetById(id)).ToDto();
        }

        // POST api/Projects
        [HttpPost]
        public async Task<int> Post([FromBody] CreateProjectRequestDto dto)
        {
            Project entity = dto.ToEntity(User.Identity.Name);

            await _service.Create(entity);

            return entity.Id;
        }

        // PUT api/Projects/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] EditProjectRequestDto dto)
        {
            Project original = await _service.GetById(id);
            original.ApplyChanges(dto);

            await _service.Update(original);
        }

        // PUT api/Projects/5/State
        [HttpPut("{id}/State")]
        public async Task Put(int id, [FromBody] ModifyProjectStateRequestDto dto)
        {
            Project original = await _service.GetById(id);

            if (original.ApplyChanges(dto))
                await _service.Update(original);
            else
                throw new InvalidOperationException($"Can't change status of project from '${original.State.ToString()}' to '{dto.State.ToString()}'!");
        }


    }
}
