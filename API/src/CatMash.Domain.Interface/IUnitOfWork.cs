using CatMash.Domain.Interface.Repository;
using System;
using System.Threading.Tasks;

namespace CatMash.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICatRepository catRepository { get; }

        Task<int> CommitAsync();
    }
}