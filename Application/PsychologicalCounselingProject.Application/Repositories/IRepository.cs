using Microsoft.EntityFrameworkCore;
using PsychologicalCounselingProject.Domain.Entities.Common;

namespace PsychologicalCounselingProject.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
