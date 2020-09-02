using CatMash.Domain.Entities.DTO;
using CatMash.Domain.Interface.Repository;
using CatMash.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CatMash.Infrastructure.Data.Repository
{
    public class CatRepository : Repository<Cat>, ICatRepository
    {
        private CatMashDbContext DbContext
        {
            get { return Context as CatMashDbContext; }
        }
        public CatRepository(CatMashDbContext context)
       : base(context) { }

        public async Task<Cat> GetCatByIdAsync(string id)
        {
            return await DbContext.Cats.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
