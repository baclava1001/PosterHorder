
using PosterHorder.Model;

namespace PosterHorder.Services
{
    public interface ISearchMoviesService
    {
        Task<SearchResult> GetMoviesSearchResultsFromAPI(string movieTitle);
    }
}