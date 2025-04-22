using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using BusinessNewsApp.Models;
using System.Collections.Generic;

namespace BusinessNewsApp.Helpers
{
    public class NewsApiHelper
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public NewsApiHelper(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["NewsAPI:Key"] ?? throw new ArgumentNullException("NewsAPI:Key not found");
        }

        public async Task<List<NewsArticle>> GetTopBusinessNewsAsync()
        {
            string url = $"https://newsapi.org/v2/top-headlines?country=us&category=business&apiKey={_apiKey}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<NewsArticle>();

            var json = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<NewsApiResponse>(json);

            return apiResponse.Articles.Select(a => new NewsArticle
            {
                SourceName = a.Source?.Name,
                Title = a.Title,
                Url = a.Url
            }).ToList();
        }
    }
}
