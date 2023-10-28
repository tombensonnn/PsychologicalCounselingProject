using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsychologicalCounselingProject.Application.Features.Commands.Answer.CreateAnswer;
using PsychologicalCounselingProject.Application.Features.Commands.Answer.DeleteAnswer;
using PsychologicalCounselingProject.Application.Features.Commands.Answer.UpdateAnswer;
using PsychologicalCounselingProject.Application.Features.Queries.Answer.GetAllAnswers;
using PsychologicalCounselingProject.Application.Features.Queries.Answer.GetAnswerById;
using PsychologicalCounselingProject.Application.Features.Queries.Answer.GetAnswersByQuestion;

namespace PsychologicalCounselingProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        readonly IMediator _mediator;

        public AnswersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAnswersQueryRequest getAllAnswersQueryRequest)
        {
            List<GetAllAnswersQueryResponse> response = await _mediator.Send(getAllAnswersQueryRequest);
            return Ok(response);
        }

        [HttpGet("GetAnswers/{QuestionId}")]
        public async Task<IActionResult> GetAnswersByQuestion([FromRoute] GetAnswersByQuestionQueryRequest getAnswersByQuestionQueryRequest)
        {
            List<GetAnswersByQuestionQueryResponse> response = await _mediator.Send(getAnswersByQuestionQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetAnswerByIdQueryRequest getAnswerByIdQueryRequest)
        {
            GetAnswerByIdQueryResponse response = await _mediator.Send(getAnswerByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAnswerCommandRequest createAnswerCommandRequest)
        {
            CreateAnswerCommandResponse response = await _mediator.Send(createAnswerCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAnswerCommandRequest updateAnswerCommandRequest)
        {
            UpdateAnswerCommandResponse response = await _mediator.Send(updateAnswerCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteAnswerCommandRequest deleteAnswerCommandRequest)
        {
            DeleteAnswerCommandResponse response = await _mediator.Send(deleteAnswerCommandRequest);
            return Ok(response);
        }
    }
}
