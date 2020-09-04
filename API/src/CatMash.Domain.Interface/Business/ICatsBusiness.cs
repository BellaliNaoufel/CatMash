using CatMash.Domain.Entities.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatMash.Domain.Interface.Business
{
    public interface ICatsBusiness
    {
        Task<IEnumerable<Cat>> GetAllCats();

        Task ResetDataBaseFromApi(string dataUrl);

        Task<Cat> GetCatById(string id);

        Task<IEnumerable<Cat>> GetRandomTwoCats();

        Task UpdateCat(Cat catToUpdate, Cat cat);
    }
}