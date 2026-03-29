using Bookly.Domain.Abstractions;
using Bookly.Domain.Repositories;
using Bookly.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Bookly.Persistence.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public Repository(Context.ApplicationDbContext context)
        {
            _context = context;
            Entity = _context.Set<T>();
        }

        //private static readonly Func<Context.ApplicationDbContext, Guid, Task<T?>> GetByIdCompiled =
        //    EF.CompileAsyncQuery((Context.ApplicationDbContext context, Guid id) =>
        //        context.Set<T>().FirstOrDefault(p => p.ID == id));

        private static readonly Func<Context.ApplicationDbContext, Guid, Task<T?>> GetByIdCompiled =
        EF.CompileAsyncQuery((Context.ApplicationDbContext context, Guid id) =>
            context.Set<T>().FirstOrDefault(p => p.ID == id));

        private static readonly Func<Context.ApplicationDbContext, Task<T?>> GetFirstCompiled =
   EF.CompileAsyncQuery((Context.ApplicationDbContext context) =>
        context.Set<T>().FirstOrDefault());

        public DbSet<T> Entity { get; set; }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await Entity.AddAsync(entity, cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            await Entity.AddRangeAsync(entities, cancellationToken);
        }

        public void Remove(T entity)
        {
            Entity.Remove(entity);
        }

        public async Task RemoveById(string id)
        {
            T ?entity = await GetByIdCompiled(_context, Guid.Parse(id));
            Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Entity.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Entity.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            Entity.UpdateRange(entities);
        }


        public IQueryable<T> GetAll(bool isTracking = true)
        {
            var result = Entity.AsQueryable();
            if (!isTracking)
                result = result.AsNoTracking();
            return result;
        }

        public async Task<T?> GetById(string id, bool isTracking = true)
        {
            return await GetByIdCompiled(_context, Guid.Parse(id));
        }

        public async Task<T?> GetFirst()
        {
            return await GetFirstCompiled(_context);
        }

        public async Task<T?> GetFirstByExpiression(Expression<Func<T, bool>> expression, CancellationToken cancellationToken, bool isTracking = true)
        {
            T? entity = null;
            if (!isTracking)
                entity = await Entity.AsNoTracking().Where(expression).FirstOrDefaultAsync(cancellationToken);
            else
                entity = await Entity.Where(expression).FirstOrDefaultAsync(cancellationToken);

            return entity;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true)
        {
            var result = Entity.Where(expression);
            if (!isTracking)
                result = result.AsNoTracking();
            return result;
        }
    }

}
