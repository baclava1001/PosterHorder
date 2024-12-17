using PosterHorder.ViewModels;

namespace PosterHorder.Views;

public partial class BigPosterPage : ContentPage
{
	public BigPosterPage(BigPosterViewModel bigPosterViewModel)
	{
		InitializeComponent();
		this.BindingContext = bigPosterViewModel;
	}
}