using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Api.Declarations
{
    public interface IUnitOfWorkService
    {
        void SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        void DetachAllEntityEntries(params string[] excludedEntityTypes);
    }
}