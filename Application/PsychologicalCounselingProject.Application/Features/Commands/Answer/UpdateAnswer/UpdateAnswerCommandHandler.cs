using MediatR;
using PsychologicalCounselingProject.Application.Repositories.AnswerRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Commands.Answer.UpdateAnswer
{
    public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommandRequest, UpdateAnswerCommandResponse>
    {
        readonly IAnswerReadRepository _answerReadRepository;
        readonly IAnswerWriteRepository _answerWriteRepository;

        public UpdateAnswerCommandHandler(IAnswerWriteRepository answerWriteRepository, IAnswerReadRepository answerReadRepository)
        {
            _answerWriteRepository = answerWriteRepository;
            _answerReadRepository = answerReadRepository;
        }

        public async Task<UpdateAnswerCommandResponse> Handle(UpdateAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedAnswer = await _answerReadRepository.GetByIdAsync(request.AnswerId);
            updatedAnswer.Content = request.Content;
            await _answerWriteRepository.SaveChangesAsync();

            return new()
            {
                Message = "Answer updated successfully"
            };
        }
    }
}
