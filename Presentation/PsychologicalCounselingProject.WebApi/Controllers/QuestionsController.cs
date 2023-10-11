using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsychologicalCounselingProject.Application.Features.Commands.Question.CreateQuestion;
using PsychologicalCounselingProject.Application.Features.Commands.Question.DeleteQuestion;
using PsychologicalCounselingProject.Application.Features.Commands.Question.UpdateQuestion;
using PsychologicalCounselingProject.Application.Features.Queries.Question.GetAllQuestions;
using PsychologicalCounselingProject.Application.Features.Queries.Question.GetQuestionById;

namespace PsychologicalCounselingProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        public IMediator _mediator { get; set; }

        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllQuestionsQueryRequest getAllQuestionsQueryRequest)
        {
            GetAllQuestionsQueryResponse response = await _mediator.Send(getAllQuestionsQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetQuestionByIdQueryRequest getQuestionByIdQueryRequest)
        {
            GetQuestionByIdQueryResponse response = await _mediator.Send(getQuestionByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateQuestionCommandRequest createQuestionCommandRequest)
        {
            CreateQuestionCommandResponse response = await _mediator.Send(createQuestionCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateQuestionCommandRequest updateQuestionCommandRequest)
        {
            UpdateQuestionCommandResponse response = await _mediator.Send(updateQuestionCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Remove([FromRoute] DeleteQuestionCommandRequest deleteQuestionCommandRequest)
        {
            DeleteQuestionCommandResponse response = await _mediator.Send(deleteQuestionCommandRequest);
            return Ok(response);
        }
    }
}
