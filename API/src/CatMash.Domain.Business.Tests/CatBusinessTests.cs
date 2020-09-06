using CatMash.Domain.Entities.DTO;
using CatMash.Domain.Interface.Business;
using NFluent;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CatMash.Domain.Business.Tests
{
    public class CatBusinessTests
    {
        private readonly ICatsBusiness _catBusiness;
        private readonly Cat[] catList;

        public CatBusinessTests()
        {
            _catBusiness = Substitute.For<ICatsBusiness>();

            catList = new Cat[]
           {
                new Cat { Id="chat1", Url="url1", Score=0},
                new Cat { Id="chat2", Url="url2", Score=10},
                new Cat { Id="chat3", Url="url3", Score=2},
                new Cat { Id="chat4", Url="url4", Score=0},
           };
        }


        [Fact]
        public async Task Get_All_Cats()
        {
            _catBusiness.GetAllCats().ReturnsForAnyArgs(catList);

            var actual = await _catBusiness.GetAllCats();

            Check.That(actual.Count()).Equals(4);
            Check.That(actual).Equals(catList);
        }

        [Fact]
        public async Task Get_Cat_ById()
        {
            _catBusiness.GetCatById("chat2").Returns(catList[1]);

            var actual = await _catBusiness.GetCatById("chat2");

            Check.That(actual).Equals(catList[1]);
        }
    }
}

