using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Features.Commands.Module.DeleteModule
{
    public class DeleteModuleCommandRequest : IRequest<DeleteModuleCommandResponse>
    {
        public string Id { get; set; }
    }
}
