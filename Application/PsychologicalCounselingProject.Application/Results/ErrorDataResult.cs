﻿using PsychologicalCounselingProject.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Results
{
    public class ErrorDataResult<T> : DataResult<T> where T : BaseEntity
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        { 
        }

        public ErrorDataResult(T data) : base(data, false)
        {
        }

        public ErrorDataResult(string message) : base(default, false, message)
        {
        }

        public ErrorDataResult() : base(default, false)
        {
        }
    }
}
