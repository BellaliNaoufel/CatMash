using CatMash.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatMash.Domain.Interface.Business
{
    public interface ICatsBusiness
    {
        Task<IEnumerable<Cat>> GetAllCats(string dataUrl);
        void ResetDataBaseFromApi(string dataUrl);
        Task<Cat> GetCatById(string dataUrl, string id);
        Task<(Cat, Cat)> GetRandomTwoCats(string dataUrl);
    }
}
