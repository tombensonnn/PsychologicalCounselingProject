using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Commands.Module.UpdateModule
{
    public class UpdateModuleCommandRequest : IRequest<UpdateModuleCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int QuestionSize { get; set; }
    }
}
