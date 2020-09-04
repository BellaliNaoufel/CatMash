using CatMash.Domain.Entities.DTO;
using System.Threading.Tasks;

namespace CatMash.Domain.Interface.Repository
{
    public interface ICatRepository : IRepository<Cat>
    {
        Task<Cat> GetByIdAsync(string id);
    }
}