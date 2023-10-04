﻿using Microsoft.EntityFrameworkCore;
using PsychologicalCounselingProject.Application.Repositories;
using PsychologicalCounselingProject.Domain.Entities.Common;
using PsychologicalCounselingProject.Persistence.Context;
using System.Linq.Expressions;

namespace PsychologicalCounselingProject.Persistence.Repository
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public ReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();

            if(!tracking)
            {
                query = query.AsNoTracking();
            }

            return query;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if(!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(expression);
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if(!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }
        
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.Where(expression);

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return query;
        }
    }
}
