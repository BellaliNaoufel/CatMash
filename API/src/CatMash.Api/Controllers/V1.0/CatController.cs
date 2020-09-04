using AutoMapper;
using CatMash.Api.Models;
using CatMash.Api.Models.Requests;
using CatMash.Api.Models.Responses;
using CatMash.Api.Validation;
using CatMash.Domain.Entities.DTO;
using CatMash.Domain.Interface.Business;
using CatMash.Front.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Api.Controllers.V1._0
{
    [ApiVersion("1.0")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly ICatsBusiness _catsBusiness;
        private readonly CatsApiSettings _catsApiSettings;
        private readonly ILogger<CatController> _logger;
        private readonly IMapper _mapperService;

        public CatController(ICatsBusiness catsBusiness, 
            IOptions<CatsApiSettings> catsApiSetting, 
            ILogger<CatController> logger,
            IMapper mapperService)
        {
            _catsBusiness = catsBusiness;
            _catsApiSettings = catsApiSetting.Value;
            _logger = logger;
            _mapperService = mapperService;
        }

        /// <summary>
        /// Reset database
        /// </summary>
        /// <returns></returns>
        //[ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost(("api/v{version:apiVersion}/reset"))]
        [ProducesResponseType(typeof(Cat), StatusCodes.Status200OK)]
        public async Task ResetDataBaseFromApi()
        {
            await _catsBusiness.ResetDataBaseFromApi(_catsApiSettings.DataUrl);
        }

        /// <summary>
        /// Get cat by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(("api/v{version:apiVersion}/cats/{id}"))]
        [ProducesResponseType(typeof(Cat), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CatResponseModel>> GetCatById([FromRoute] string id)
        {
            var cat = await _catsBusiness.GetCatById(id);

            if (cat == null)
                return NotFound();

            var catModel = _mapperService.Map<Cat, CatResponseModel>(cat);

            return Ok(catModel);
        }

        /// <summary>
        /// Get all cats
        /// </summary>
        /// <returns></returns>
        [HttpGet(("api/v{version:apiVersion}/cats"))]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(typeof(CatResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CatResponseModel>>> GetAllCats()
        {
            var cats = await _catsBusiness.GetAllCats();

            if (!cats.Any())
                return NotFound();

            var catsModel = _mapperService.Map<IEnumerable<Cat>, IEnumerable<CatResponseModel>>(cats);

            return Ok(catsModel);
        }

        /// <summary>
        /// Get two cats random
        /// </summary>
        /// <returns></returns>
        [HttpGet(("api/v{version:apiVersion}/cats/random"))]
        [ProducesResponseType(typeof(CatResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CatResponseModel>>> GetRandomTwoCats()
        {
            var twoCats = await _catsBusiness.GetRandomTwoCats();

            if (twoCats.Count() < 2)
                return NotFound();
            
            var twoCatsModel = _mapperService.Map<IEnumerable<Cat>, IEnumerable<CatResponseModel>>(twoCats);

            return Ok(twoCatsModel);
        }

        /// <summary>
        /// Update cat
        /// </summary>
        /// <param name="id"></param>
        /// <param name="catModel"></param>
        /// <returns></returns>
        [HttpPut(("api/v{version:apiVersion}/cats/{id}"))]
        [ProducesResponseType(typeof(CatResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateCat([FromRoute] string id, [FromBody] CatRequestModel catModel)
        {
            var catToUpdate = await _catsBusiness.GetCatById(id);

            if (catToUpdate == null)
                return NotFound();
            
            var cat = _mapperService.Map<CatRequestModel, Cat>(catModel);

            await _catsBusiness.UpdateCat(catToUpdate, cat);

            var updatedCatModel = _mapperService.Map<CatResponseModel>(cat);

            return Ok(updatedCatModel);
        }
    }
}