using PosterHorder.Helpers;
using PosterHorder.Models;
using PosterHorder.Services;

namespace PosterHorder.ViewModels
{
    public partial class SearchMoviesViewModel : BaseViewModel
    {
        private readonly ISearchMoviesService _searchMoviesService;
        
        [ObservableProperty]
        public string _searchString;

        [ObservableProperty]
        public ObservableCollection<Movie> _movies = new();

        public SearchMoviesViewModel(ISearchMoviesService searchMoviesService)
        {
            Title = "Poster Horder";
            _searchMoviesService = searchMoviesService;
            IsBusy = false;
        }

        [RelayCommand(CanExecute = nameof(IsNotBusy))]
        private async Task GetSearchResultAsync()
        {
            if (IsBusy)
                return;

            try
            {
                // Local list to add all movies
                List<Movie> moviesFromApi = new();
                IsBusy = true;
                var searchResult = await _searchMoviesService.GetMoviesSearchResultsFromAPIAsync(SearchString);

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
    }
}
