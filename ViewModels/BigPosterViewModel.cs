using PosterHorder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterHorder.ViewModels
{
    [QueryProperty("Movie", "Movie")]
    public partial class BigPosterViewModel : BaseViewModel
    {
        private readonly ISavePosterService _savePosterService;

        public BigPosterViewModel()
        {
        }

        public BigPosterViewModel(ISavePosterService savePosterService)
        {
            _savePosterService = savePosterService;
        }

        [ObservableProperty]
        Movie movie;

        [RelayCommand]
        private async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task SavePosterToDeviceAsync()
        {
            await _savePosterService.SavePosterAsync(Movie.PosterPath, Movie.Title);
        }
    }
}
