using AutoMapper;
using CatMash.Api.Controllers.V1._0;
using CatMash.Api.Mapping;
using CatMash.Api.Models.Responses;
using CatMash.Domain.Entities.DTO;
using CatMash.Domain.Interface.Business;
using CatMash.Front.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NFluent;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CatMash.Api.Tests
{
    public class CatControllerTests
    {
        private readonly CatController _subject;
        private readonly ICatsBusiness _catBusiness;
        private readonly ILogger _log;
        private readonly IMapper _mapper;
        private readonly Cat[] catList;

        public CatControllerTests()
        {
            var settings = new CatsApiSettings
            {
                BaseUrl = "https://latelier.co/",
                DataUrl = "data/cats.json"
            };
            var options = Options.Create(settings);

            catList = new Cat[]
    {
                new Cat { Id="chat1", Url="url1", Score=0},
                new Cat { Id="chat2", Url="url2", Score=10},
                new Cat { Id="chat3", Url="url3", Score=2},
                new Cat { Id="chat4", Url="url4", Score=0},
    };

            _catBusiness = Substitute.For<ICatsBusiness>();
            _log = Substitute.For<ILogger>();
            _mapper = Substitute.For<IMapper>();
            _subject = new CatController(_catBusiness, options, null, _mapper);
        }


        [Fact]
        public void Get_All_Cats()
        {
            var expectedCatList = _catBusiness.GetAllCats().ReturnsForAnyArgs(catList);

            var actual = _subject.GetAllCats();

            Check.That(actual).IsNotNull();

            // TODO: resolve automapper problem
        }
    }
}
