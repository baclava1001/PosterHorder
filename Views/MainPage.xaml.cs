using PosterHorder.ViewModels;

namespace PosterHorder
{
    public partial class MainPage : ContentPage
    {
        public MainPage(SearchMoviesViewModel searchMoviesViewModel)
        {
            InitializeComponent();
            this.BindingContext = searchMoviesViewModel;
        }
    }
}
