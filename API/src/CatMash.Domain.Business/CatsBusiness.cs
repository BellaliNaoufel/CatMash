using CatMash.Domain.Entities.DTO;
using CatMash.Domain.Interface;
using CatMash.Domain.Interface.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatMash.Domain.Business
{
    public class CatsBusiness : ICatsBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpClient _httpclient;
        private const string HttpClientName = "CatsApiClient";

        public CatsBusiness(IHttpClientFactory httpClientFactory, IUnitOfWork unitOfWork)
        {
            _httpclient = httpClientFactory.CreateClient(HttpClientName);
            _unitOfWork = unitOfWork;
        }

        public async Task<Cat> GetCatById(string id)
        {
            return await _unitOfWork.catRepository.GetByIdAsync(id);
        }

        public async Task ResetDataBaseFromApi(string dataUrl)
        {

            var catListFromDb = await _unitOfWork.catRepository.GetAllAsync();

            _unitOfWork.catRepository.RemoveRange(catListFromDb);

            await _unitOfWork.CommitAsync();

            var catListFromApi = await GetAllCatsFromApi(dataUrl);

            foreach (Cat cat in catListFromApi)
            {
                await _unitOfWork.catRepository.AddAsync(cat);
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Cat>> GetAllCatsFromApi(string dataUrl)
        {
            using (var response = await _httpclient.GetAsync(dataUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResult = await response.Content.ReadAsStringAsync();

                    var images = JsonConvert.DeserializeObject<ApiResponse>(apiResult).Images;

                    return images.Select(x => new Cat { Id = x.Id, Url = x.Url, Score = 0 });

                }
                return null;
            }
        }

        public async Task<IEnumerable<Cat>> GetAllCats()
        {
            return await _unitOfWork.catRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Cat>> GetRandomTwoCats()
        {
            var catsList = await GetAllCats();

            Random random = new Random();

            var firstItemIndex = random.Next(0, catsList.Count() - 1);

            int secondItemIndex;

            do
            {
                secondItemIndex = random.Next(0, catsList.Count() - 1);
            } while (firstItemIndex == secondItemIndex);

            return new[] { catsList.ElementAt(firstItemIndex), catsList.ElementAt(secondItemIndex) };
        }

        public Task<Cat> UpdateCat(Cat cat)
        {
            throw new NotImplementedException();
        }
    }
}
