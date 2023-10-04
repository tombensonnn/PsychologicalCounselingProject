﻿using PsychologicalCounselingProject.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Application.Results
{
    public class DataResult<T> : Result, IDataResult<T> where T : BaseEntity
    {
        public T Data { get; }

        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
    }
}
