using PosterHorder.Models;
using PosterHorder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterHorder.ViewModels
{
    public partial class SearchMoviesViewModel : BaseViewModel
    {
        private readonly ISearchMoviesService _searchMoviesService;
        
        [ObservableProperty]
        public string _searchString;

        public ObservableCollection<Movie> _movies;

        public SearchMoviesViewModel(ISearchMoviesService searchMoviesService)
        {
            Title = "Poster Horder";
            _searchMoviesService = searchMoviesService;
        }

        [RelayCommand]
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

                if (searchResult.Results.Count > 0)
                {
                    foreach (var movie in searchResult.Results)
                    {
                        moviesFromApi.Add(movie);
                    }
                }
                // Point the _movies ObservableCollection to the locally saved list
                _movies = new ObservableCollection<Movie>(moviesFromApi);
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
