using CatMash.Domain.Interface;
using CatMash.Domain.Interface.Repository;
using CatMash.Infrastructure.Data.Context;
using CatMash.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatMash.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatMashDbContext _context;
        private ICatRepository _catRepository;

        public UnitOfWork(CatMashDbContext context)
        {
           _context = context;
        }
        public ICatRepository catRepository => _catRepository = _catRepository ?? new CatRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
