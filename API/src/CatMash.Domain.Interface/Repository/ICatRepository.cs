using CatMash.Domain.Entities.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatMash.Domain.Interface.Repository
{
    public interface ICatRepository : IRepository<Cat>
    {
        Task<Cat> GetByIdAsync(string id);
        Task<IEnumerable<Cat>> GetOrdredAndPagedCatsAsync(int pageNumber, int pageSize);
    }
}