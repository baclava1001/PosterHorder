using PosterHorder.Constants;
using PosterHorder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PosterHorder.Services
{
    public class SearchMoviesService : ISearchMoviesService
    {
        private readonly HttpClient _httpClient = new();

        private SearchResult searchResult;

        public string SearchString { get; set; }


        public SearchMoviesService(HttpClient httpClient, string? searchString)
        {
            _httpClient = httpClient;
            if (searchString != null)
            {
                SearchString = searchString;
            }
        }

        public async Task<SearchResult> GetMoviesSearchResultsFromAPIAsync(string movieTitle)
        {
            if(searchResult.Results.Count > 0)
            {
                return searchResult;
            }

            if (movieTitle != null)
            {

                try
                {
                    searchResult = await _httpClient.GetFromJsonAsync<SearchResult>($"{ApiAddress.baseAddress}/{SearchString}&{ApiAddress.apiKey}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return searchResult;            
        }
    }
}
