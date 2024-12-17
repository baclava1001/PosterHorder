using PosterHorder.Helpers;
using PosterHorder.Models;
using PosterHorder.Services;
using PosterHorder.Views;

namespace PosterHorder.ViewModels
{
    public partial class SearchMoviesViewModel : BaseViewModel
    {
        private readonly ISearchMoviesService _searchMoviesService;
        
        [ObservableProperty]
        public string _searchString;

        [ObservableProperty]
        public ObservableCollection<Movie> _movies;

        public SearchMoviesViewModel(ISearchMoviesService searchMoviesService)
        {
            Title = "Poster Horder";
            _searchMoviesService = searchMoviesService;
            IsBusy = false;
        }

        [RelayCommand]
        private async Task GetSearchResultAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                // New local list to add all movies without triggering UI update for each one
                List<Movie> moviesFromApi = new();
                // Reset list class property
                Movies = new();
                // Reset variable
                SearchResult searchResult = new();
                
                searchResult = await _searchMoviesService.GetMoviesSearchResultsFromAPIAsync(SearchString);

                if (searchResult.Results != null && searchResult.Results.Count > 0)
                {
                    foreach (var movie in searchResult.Results)
                    {
                        if(!string.IsNullOrEmpty(movie.PosterPath))
                        {
                            string fullPosterPath = ApiRequestStringBuilder.BuildApiPosterRequest(movie.PosterPath);
                            movie.PosterPath = fullPosterPath;
                            moviesFromApi.Add(movie);
                        }
                    }
                    // Point the _movies ObservableCollection to the locally saved list
                    Movies = new ObservableCollection<Movie>(moviesFromApi);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Sorry!", "Unable to get the requested Movie posters.", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task GoToBigPosterPageAsync(Movie movie)
        {
            if (movie is null || movie.PosterPath is null)
            {
                return;
            }

            await Shell.Current.GoToAsync(nameof(BigPosterPage), true,
                new Dictionary<string, object>
                {
                    { "Movie", movie }
                });
        }
    }
}
