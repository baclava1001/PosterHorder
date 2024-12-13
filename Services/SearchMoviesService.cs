using PosterHorder.Constants;
using PosterHorder.Helpers;
using PosterHorder.Models;
using System.Net.Http.Json;

namespace PosterHorder.Services
{
    public class SearchMoviesService : ISearchMoviesService
    {
        private readonly HttpClient _httpClient;

        private SearchResult _searchResult;

        public SearchMoviesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<SearchResult> GetMoviesSearchResultsFromAPIAsync(string searchStringFromviewModel)
        {
            //if(_searchResult.Results != null && _searchResult.Results.Count > 0)
            //{
            //    return _searchResult;
            //}

            _searchResult = new SearchResult();

            if (!string.IsNullOrEmpty(searchStringFromviewModel))
            {

                try
                {
                    var response = await _httpClient.GetAsync(ApiRequestStringBuilder.BuildApiSearchRequest(searchStringFromviewModel));

                    _searchResult = await response.Content.ReadFromJsonAsync<SearchResult>();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }

            return _searchResult;            
        }
    }
}
