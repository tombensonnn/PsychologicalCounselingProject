using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
