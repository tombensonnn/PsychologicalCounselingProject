using PsychologicalCounselingProject.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Results
{
    public interface IDataResult<T> : IResult where T : BaseEntity
    {
        T Data { get; }
    }
}
