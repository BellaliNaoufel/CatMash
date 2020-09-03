using CatMash.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatMash.Domain.Interface.Repository
{
    public interface ICatRepository: IRepository<Cat>
    {
        Task<Cat> GetByIdAsync(string id);
    }
}
