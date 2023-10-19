using MediatR;
using Microsoft.AspNetCore.Mvc;
using PsychologicalCounselingProject.Application.Features.Commands.Module.CreateModule;
using PsychologicalCounselingProject.Application.Features.Commands.Module.DeleteModule;
using PsychologicalCounselingProject.Application.Features.Commands.Module.UpdateModule;
using PsychologicalCounselingProject.Application.Features.Queries.Module.GetAllModules;
using PsychologicalCounselingProject.Application.Features.Queries.Module.GetModuleById;

namespace PsychologicalCounselingProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        readonly IMediator _mediator;

        public ModulesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllModulesQueryRequest getAllModulesCommandRequest)
        {
            GetAllModulesQueryResponse response = await _mediator.Send(getAllModulesCommandRequest);

            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetModuleByIdQueryRequest getModuleByIdQueryRequest)
        {
            GetModuleByIdQueryResponse response = await _mediator.Send(getModuleByIdQueryRequest);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateModuleCommandRequest createModuleCommandRequest)
        {
            CreateModuleCommandResponse response = await _mediator.Send(createModuleCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateModuleCommandRequest updateModuleCommandRequest)
        {
            UpdateModuleCommandResponse response = await _mediator.Send(updateModuleCommandRequest);

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Remove([FromRoute] DeleteModuleCommandRequest deleteModuleCommandRequest)
        {
            DeleteModuleCommandResponse response = await _mediator.Send(deleteModuleCommandRequest);

            return Ok(response);
        }

    }
}
