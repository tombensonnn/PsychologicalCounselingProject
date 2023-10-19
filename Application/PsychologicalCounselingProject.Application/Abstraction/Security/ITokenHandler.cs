using PsychologicalCounselingProject.Application.DTOs.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Abstraction.Security
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(int hours);
    }
}
