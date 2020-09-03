using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatMash.Domain.Entities.DTO;
using CatMash.Domain.Interface.Business;
using CatMash.Front.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CatMash.Api.Controllers.V1._0
{
    [ApiVersion("1.0")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly ICatsBusiness _catsBusiness;
        private readonly CatsApiSettings _catsApiSettings;
        private readonly ILogger<CatController> _logger;

        public CatController(ICatsBusiness catsBusiness, IOptions<CatsApiSettings> catsApiSetting, ILogger<CatController> logger)
        {
            _catsBusiness = catsBusiness;
            _catsApiSettings = catsApiSetting.Value;
            _logger = logger;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost(("api/v{version:apiVersion}/reset"))]
        [ProducesResponseType(200)]
        public async Task ResetDataBaseFromApi()
        {
            await _catsBusiness.ResetDataBaseFromApi(_catsApiSettings.DataUrl);
        }

        [HttpGet(("api/v{version:apiVersion}/cats/{id}"))]
        [ProducesResponseType(typeof(Cat), 200)]
        public async Task<Cat> GetCatById([FromRoute] string id)
        {
            return await _catsBusiness.GetCatById(id);
        }

        [HttpGet(("api/v{version:apiVersion}/cats"))]
        [ProducesResponseType(typeof(Cat), 200)]
        public async Task<IEnumerable<Cat>> GetAllCats()
        {
            return await _catsBusiness.GetAllCats();
        }

        [HttpGet(("api/v{version:apiVersion}/cats/random"))]
        [ProducesResponseType(typeof(Cat), 200)]
        public async Task<IEnumerable<Cat>> GetRandomTwoCats()
        {
            return await _catsBusiness.GetRandomTwoCats();
        }

        [HttpPut(("api/v{version:apiVersion}/cats/{id}/{score}"))]
        [ProducesResponseType(typeof(Cat), 201)]
        public async Task UpdateCat([FromRoute] string id, [FromBody]Cat cat)
        {
           
        }
    }
}
