using System;
using BusinessNewsApp.Models;

public class NewsService
{
    private readonly HttpClient _httpClient;

    public NewsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<NewsArticle>> GetBusinessNewsAsync()
    {
        string apiKey = "f427242c00f64e5c9020d67de6eeed46";
        string url = $"https://newsapi.org/v2/top-headlines?country=us&category=business&apiKey={apiKey}";

        var response = await _httpClient.GetFromJsonAsync<NewsApiResponse>(url);

        return response.Articles.Select(a => new NewsArticle
        {
            SourceName = a.Source.Name,
            Title = a.Title,
            Url = a.Url
        }).ToList();
    }
}

