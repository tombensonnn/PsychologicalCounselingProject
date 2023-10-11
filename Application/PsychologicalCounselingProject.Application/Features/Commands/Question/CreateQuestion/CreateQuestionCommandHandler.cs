using MediatR;
using PsychologicalCounselingProject.Application.Repositories.ModuleRepositories;
using PsychologicalCounselingProject.Application.Repositories.QuestionRepositories;
using PsychologicalCounselingProject.Application.Repositories.UserRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Commands.Question.CreateQuestion
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommandRequest, CreateQuestionCommandResponse>
    {
        private readonly IQuestionWriteRepository _questionWriteRepository;
        private readonly IModuleReadRepository _moduleReadRepository;

        public CreateQuestionCommandHandler(IQuestionWriteRepository questionWriteRepository, IModuleReadRepository moduleReadRepository)
        {
            _questionWriteRepository = questionWriteRepository;
            _moduleReadRepository = moduleReadRepository;
        }

        public async Task<CreateQuestionCommandResponse> Handle(CreateQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var module = await _moduleReadRepository.GetByIdAsync(request.ModuleId);
            var createdQuestion = await _questionWriteRepository.AddAsync(new() { Title = request.Title, Answer = request.Answer, Module = module });
            await _questionWriteRepository.SaveChangesAsync();

            return new() { Result = createdQuestion };
        }
    }
}
