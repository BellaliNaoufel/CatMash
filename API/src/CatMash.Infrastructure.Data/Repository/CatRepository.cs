using CatMash.Domain.Entities.DTO;
using CatMash.Domain.Interface.Repository;
using CatMash.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

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

        public async Task<Cat> GetByIdAsync(string id)
        {
            return await DbContext.Cats.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Cat>> GetOrdredAndPagedCatsAsync(int pageNumber, int pageSize)
        {
            return await DbContext.Cats.OrderBy(x => x.Score).ToPagedListAsync(pageNumber, pageSize);
        }
    }
}