using Microsoft.EntityFrameworkCore;
using Practice.Api.Database;
using Practice.Api.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Api.Services.Implementation
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly PracticeApiContext _context;

        public UnitOfWorkService(PracticeApiContext context)
        {
            _context = context;
        }

        public void SaveChanges() => _context.SaveChanges();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void DetachAllEntityEntries(params string[] excludedEntityTypes)
        {
            var list = _context.ChangeTracker
                .Entries()
                .ToList();

            if (excludedEntityTypes != null && excludedEntityTypes.Length != 0)
            {
                list = list
                    .Where(x => !excludedEntityTypes.Contains(x.CurrentValues.EntityType.Name))
                    .ToList();
            }

            list.ForEach(x => x.State = EntityState.Detached);
        }
    }
}
