using CatMash.Domain.Entities.DTO;
using CatMash.Domain.Interface;
using CatMash.Domain.Interface.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public async Task<Cat> GetCatById(string dataUrl, string id)
        {
            using (var response = await _httpclient.GetAsync(dataUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResult = await response.Content.ReadAsStringAsync();

                    var images = JsonConvert.DeserializeObject<ApiResponse>(apiResult).Images;

                    return images.Where(x => x.Id.Equals(id))
                                 .Select(x => new Cat() { Id = x.Id, Url = x.Url, Score = 0 })
                                 .FirstOrDefault();
                }
                return null;
            }
        }

        public async Task<(Cat, Cat)> GetRandomTwoCats(string apiUrl)
        {
            var catsList = await GetAllCats(apiUrl);

            Random random = new Random();

            var firstItemIndex = random.Next(0, catsList.Count() - 1);

            var secondItemIndex = 0;
            do
            {
                secondItemIndex = random.Next(0, catsList.Count() - 1);
            } while (firstItemIndex == secondItemIndex);

            return (catsList.ElementAt(firstItemIndex), catsList.ElementAt(secondItemIndex));
        }

        public async void ResetDataBaseFromApi(string dataUrl)
        {
            var aaa = await _unitOfWork.catRepository.GetAllAsync();

            var catList = await GetAllCatsFromApi(dataUrl);

            foreach (Cat cat in catList.ToArray())
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

                    return images.Select(x => new Cat() { Id = x.Id, Url = x.Url, Score = 0 });

                }
                return null;
            }
        }

        public async Task<IEnumerable<Cat>> GetAllCats(string dataUrl)
        {
            return await _unitOfWork.catRepository.GetAllAsync();
        }
    }
}
