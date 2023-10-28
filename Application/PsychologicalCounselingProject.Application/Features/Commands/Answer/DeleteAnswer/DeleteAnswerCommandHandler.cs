using MediatR;
using PsychologicalCounselingProject.Application.Repositories.AnswerRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Commands.Answer.DeleteAnswer
{
    public class DeleteAnswerCommandHandler : IRequestHandler<DeleteAnswerCommandRequest, DeleteAnswerCommandResponse>
    {
        readonly IAnswerWriteRepository _answerWriteRepository;

        public DeleteAnswerCommandHandler(IAnswerWriteRepository answerWriteRepository)
        {
            _answerWriteRepository = answerWriteRepository;
        }

        public async Task<DeleteAnswerCommandResponse> Handle(DeleteAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            await _answerWriteRepository.RemoveAsync(request.AnswerId);
            await _answerWriteRepository.SaveChangesAsync();

            return new()
            {
                Message = "Answer deleted successfully"
            };
        }
    }
}
