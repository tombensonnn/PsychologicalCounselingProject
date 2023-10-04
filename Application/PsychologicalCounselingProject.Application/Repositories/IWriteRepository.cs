using PsychologicalCounselingProject.Application.Results;
using PsychologicalCounselingProject.Domain.Entities.Common;

namespace PsychologicalCounselingProject.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<IResult> AddAsync(T entity);
        Task<IResult> AddRangeAsync(IEnumerable<T> entities);
        IResult Remove(T entity);
        IResult RemoveRange(IEnumerable<T> entities);
        Task<IResult> RemoveAsync(string id);
        IResult Update(T entity);
        Task SaveChangesAsync();
    }
}
