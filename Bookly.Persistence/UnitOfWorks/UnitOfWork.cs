using Bookly.Domain.UnitOfWorks;
using Bookly.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookly.Persistence.UnitOfWorks
{
    public sealed class UnitOfWork:IUnitOfWork
    {
            private readonly ApplicationDbContext _context;

            public UnitOfWork(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            {
                int count = await _context.SaveChangesAsync(cancellationToken);
                return count;
            }
        }
}
