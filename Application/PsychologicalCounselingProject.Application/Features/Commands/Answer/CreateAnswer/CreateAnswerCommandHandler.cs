using MediatR;
using Microsoft.AspNetCore.Identity;
using PsychologicalCounselingProject.Application.Repositories.AnswerRepositories;
using PsychologicalCounselingProject.Application.Repositories.QuestionRepositories;
using PsychologicalCounselingProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Commands.Answer.CreateAnswer
{
    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommandRequest, CreateAnswerCommandResponse>
    {
        readonly IAnswerWriteRepository _answerWriteRepository;
        readonly IQuestionReadRepository _questionReadRepository;
        readonly UserManager<AppUser> _userManager;

        public CreateAnswerCommandHandler(IAnswerWriteRepository answerWriteRepository, IQuestionReadRepository questionReadRepository, UserManager<AppUser> userManager)
        {
            _answerWriteRepository = answerWriteRepository;
            _questionReadRepository = questionReadRepository;
            _userManager = userManager;
        }

        public async Task<CreateAnswerCommandResponse> Handle(CreateAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var creatorUser = await _userManager.FindByIdAsync(request.UserId);
            var question = await _questionReadRepository.GetByIdAsync(Guid.Parse(request.QuestionId).ToString());
            await _answerWriteRepository.AddAsync(new() {Content = request.Content, Question = question, User = creatorUser });
            await _answerWriteRepository.SaveChangesAsync();

            return new()
            {
                Content = request.Content
            };
        }
    }
}
