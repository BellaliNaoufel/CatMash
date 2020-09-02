using CatMash.Domain.Entities.DTO;
using CatMash.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatMash.Infrastructure.Data.Datas
{
    public static class DbInitializer
    {
        public static async void Initialize(CatMashDbContext context)
        {
           // if (context.Cats.Any())
           // {
           //     return;
           // }

           // var catsFromApi = new Cat[]
           //{
           //    new Cat{ Id="test", Url="naoufel.com"},
           //    new Cat{ Id="tito", Url="sana.com"}
           //};

           // context.Cats.AddRange(catsFromApi);
            await context.SaveChangesAsync();
        }
    }
}
