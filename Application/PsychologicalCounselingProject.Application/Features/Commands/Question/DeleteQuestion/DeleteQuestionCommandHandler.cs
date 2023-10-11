using MediatR;
using PsychologicalCounselingProject.Application.Repositories.QuestionRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Commands.Question.DeleteQuestion
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommandRequest, DeleteQuestionCommandResponse>
    {
        private readonly IQuestionWriteRepository _questionWriteRepository;

        public DeleteQuestionCommandHandler(IQuestionWriteRepository questionWriteRepository)
        {
            _questionWriteRepository = questionWriteRepository;
        }

        public async Task<DeleteQuestionCommandResponse> Handle(DeleteQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedQuestion = await _questionWriteRepository.RemoveAsync(request.Id);
            await _questionWriteRepository.SaveChangesAsync();

            return new() { Result = deletedQuestion };
        }
    }
}
