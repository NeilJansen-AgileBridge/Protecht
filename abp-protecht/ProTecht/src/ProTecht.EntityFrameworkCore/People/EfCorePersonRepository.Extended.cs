using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using ProTecht.EntityFrameworkCore;

namespace ProTecht.People
{
    public class EfCorePersonRepository : EfCorePersonRepositoryBase, IPersonRepository
    {
        public EfCorePersonRepository(IDbContextProvider<ProTechtDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}