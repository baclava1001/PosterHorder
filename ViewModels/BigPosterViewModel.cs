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
        public BigPosterViewModel()
        {
        }

        [ObservableProperty]
        Movie movie;

        [RelayCommand]
        private async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
