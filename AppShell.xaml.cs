namespace PosterHorder
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BigPosterPage), typeof(BigPosterPage));
        }
    }
}
