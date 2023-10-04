using Microsoft.EntityFrameworkCore;
using PsychologicalCounselingProject.Domain.Entities;
using PsychologicalCounselingProject.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalCounselingProject.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Module> Modules { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedAt = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
