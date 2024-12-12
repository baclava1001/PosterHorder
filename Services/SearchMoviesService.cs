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


        public SearchMoviesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SearchResult> GetMoviesSearchResultsFromAPI(string movieTitle)
        {
            if(searchResult.Results.Count > 0)
            {
                return searchResult;
            }

            try
            {
                searchResult = await _httpClient.GetFromJsonAsync<SearchResult>($"{ApiAddress.baseAddress}/{SearchString}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return searchResult;
            
        }
    }
}
