using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PsychologicalCounselingProject.Application.Repositories;
using PsychologicalCounselingProject.Application.Results;
using PsychologicalCounselingProject.Domain.Entities.Common;
using PsychologicalCounselingProject.Persistence.Context;

namespace PsychologicalCounselingProject.Persistence.Repository
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public WriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<IResult> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);

            if(entityEntry.State == EntityState.Added)
            {
                return new SuccessResult("Added successfully");
            }

            return new ErrorResult("Something went wrong");

        }

        public async Task<IResult> AddRangeAsync(IEnumerable<T> models)
        {
            await Table.AddRangeAsync(models);

            return new SuccessResult("Added successfully");
        }

        public IResult Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);

            if(entityEntry.State == EntityState.Deleted)
            {
                return new SuccessResult("Removed successfully");
            }

            return new ErrorResult("Something went wrong");
        }

        public async Task<IResult> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            return Remove(model);
        }

        public IResult RemoveRange(IEnumerable<T> models)
        {
            Table.RemoveRange(models);

            return new SuccessResult("Removed successfully");
        }

        public async Task<bool> SaveAsync()
        {
            await _context.SaveChangesAsync();

            return true;
        }

        public IResult Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);

            if(entityEntry.State == EntityState.Modified)
            {
                return new SuccessResult("Updated successfully");
            }

            return new ErrorResult("Something went wrong");

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
