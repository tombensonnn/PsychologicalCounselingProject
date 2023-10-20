using MediatR;
using PsychologicalCounselingProject.Application.Repositories.QuestionRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Commands.Question.UpdateQuestion
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommandRequest,
         UpdateQuestionCommandResponse>
    {
        private readonly IQuestionReadRepository _questionReadRepository;
        private readonly IQuestionWriteRepository _questionWriteRepository;

        public UpdateQuestionCommandHandler(IQuestionWriteRepository questionWriteRepository, IQuestionReadRepository questionReadRepository)
        {
            _questionWriteRepository = questionWriteRepository;
            _questionReadRepository = questionReadRepository;
        }

        public async Task<UpdateQuestionCommandResponse> Handle(UpdateQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedQuestion = await _questionReadRepository.GetByIdAsync(request.QuestionId);
            updatedQuestion.Title = request.Title;
            await _questionWriteRepository.SaveChangesAsync();

            return new() { Question = updatedQuestion};
        }
    }
}
