
using PosterHorder.Models;

namespace PosterHorder.Services
{
    public interface ISearchMoviesService
    {
        Task<SearchResult> GetMoviesSearchResultsFromAPIAsync(string movieTitle);
    }
}