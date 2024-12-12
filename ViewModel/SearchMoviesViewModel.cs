using PosterHorder.Model;
using PosterHorder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterHorder.ViewModel
{
    public partial class SearchMoviesViewModel : BaseViewModel
    {
        private readonly ISearchMoviesService _searchMoviesService;
        
        [ObservableProperty]
        string _searchString;

        [ObservableProperty]
        SearchResult _searchResult;

        ObservableCollection<Movie> _movies;

        public SearchMoviesViewModel(ISearchMoviesService searchMoviesService)
        {
            Title = "Poster Horder";
            _searchMoviesService = searchMoviesService;
        }

        private async Task GetSearchResultAsync()
        {
            if (IsBusy)
                return;

            try
            {
                // Local list to add all movies
                List<Movie> moviesFromApi = new();
                IsBusy = true;
                var result = await _searchMoviesService.GetMoviesSearchResultsFromAPIAsync(_searchString);

                if (result.Results.Count > 0)
                {
                    foreach (var movie in result.Results)
                    {
                        moviesFromApi.Add(movie);
                    }
                }
                // Point the _movies ObservableCollection to the locally saved list
                _movies = new ObservableCollection<Movie>(moviesFromApi);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
